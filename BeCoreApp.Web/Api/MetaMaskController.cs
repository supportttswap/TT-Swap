using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Extensions;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Web.Models.Reponses;
using BeCoreApp.Web.Models.RequestParams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Web.Api
{
    [Produces("application/json")]
    [Route("[Controller]/[action]")]
    [ApiController]
    public class MetaMaskController : Controller
    {
        private readonly IBotTelegramService _botTelegramService;
        private readonly IMetamaskTransactionRepository _metamaskTransaction;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlockChainService _blockChain;
        private readonly ILogger<MetaMaskController> _logger;

        static AsyncRetryPolicy _policy = Policy
           .Handle<Exception>()
           .WaitAndRetryAsync(new[] {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(4),
                TimeSpan.FromSeconds(8)
               });

        public MetaMaskController(IBotTelegramService botTelegramService,
                                  IMetamaskTransactionRepository metamaskTransaction,
                                  IUnitOfWork unitOfWork,
                                  IBlockChainService blockChain,
                                  ILogger<MetaMaskController> logger)
        {
            _botTelegramService = botTelegramService;
            _metamaskTransaction = metamaskTransaction;
            _unitOfWork = unitOfWork;
            _blockChain = blockChain;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InitializeTransactionMetaMask([FromBody] BuyWithMetamaskParams model)
        {
            try
            {
                _logger.LogInformation($"Start call InitializeTransactionMetaMask with param: ", model);

                //var balance = await _blockChain.GetEtherBalance(model.Address, CommonConstants.BEP20Url);
                ////check balance
                //if (model.BNBAmount > balance)
                //{
                //    return BadRequest(new GenericResult(false, "Amount exceeds your balance!"));
                //}

                decimal priceBNBBep20 = _blockChain.GetCurrentPrice("BNB", "USD");
                if (priceBNBBep20 == 0)
                    return BadRequest(new GenericResult(false, "There is a problem loading the currency value!"));

                var TTSAmount = ConculateTTSAmount(model.BNBAmount, priceBNBBep20);

                var transaction = new MetamaskTransaction()
                {
                    Id = Guid.NewGuid(),
                    BNBAmount = model.BNBAmount,
                    TTSAmount = TTSAmount,
                    AddressFrom = model.Address,
                    AddressTo = CommonConstants.BEP20SYSTEMPuKey,
                    DateCreated = DateTime.Now,
                    MetaMaskState = MetaMaskState.Requested,
                    Type = MetaMaskTransactionType.Presale
                };

                _metamaskTransaction.Add(transaction);
                _unitOfWork.Commit();

                var convertor = new Nethereum.Hex.HexConvertors.HexUTF8StringConvertor();

                var message = new MetamaskMessage
                {
                    TransactionHex = convertor.ConvertToHex(transaction.Id.ToString()),
                    From = model.Address,
                    To = CommonConstants.BEP20SYSTEMPuKey,
                    Value = model.BNBAmount,
                    Gas = "0x61a8",//25000
                    GasPrice = "0x2540be400"
                };

                _logger.LogInformation($"Finish call InitializeTransactionMetaMask");
                return Ok(new GenericResult(true, message));
            }
            catch (Exception e)
            {
                return BadRequest(new GenericResult(false, e.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> VerifyMetaMaskRequest([FromBody] string transactionHash)
        {
            try
            {
                _logger.LogInformation($"Start call VerifyMetaMaskRequest with transaction hash: {transactionHash}");

                var transactionReceipt = await _policy.ExecuteAsync<TransactionReceipt>(async () =>
                {
                    var result = await _blockChain.GetTransactionReceiptByTransactionID(transactionHash, CommonConstants.BEP20Url);
                    if (result == null)
                    {
                        throw new ArgumentNullException();
                    }

                    return result;
                });


                var transaction = await _blockChain.GetTransactionByTransactionID(transactionHash, CommonConstants.BEP20Url);

                var uft8Convertor = new Nethereum.Hex.HexConvertors.HexUTF8StringConvertor();

                var transactionId = uft8Convertor.ConvertFromHex(transaction.Input);

                var metamaskTransaction = _metamaskTransaction.FindById(Guid.Parse(transactionId));

                if (transactionReceipt.Status.Value != 1)
                {
                    metamaskTransaction.DateUpdated = DateTime.Now;
                    metamaskTransaction.MetaMaskState = MetaMaskState.Failed;

                    _logger.LogError($"VerifyMetaMaskRequest: TransactionReceipt's status was failed: {transactionReceipt.Status.Value}");

                    return BadRequest(new GenericResult(false, "Your transction was invalid. Please Contact administrator for support!"));
                }

                //compare transaction with blockchain transaction
                if (metamaskTransaction.MetaMaskState != MetaMaskState.Requested)
                {
                    metamaskTransaction.DateUpdated = DateTime.Now;
                    metamaskTransaction.MetaMaskState = MetaMaskState.Failed;

                    _logger.LogError($"VerifyMetaMaskRequest: MetaMaskState was not matched: {metamaskTransaction.MetaMaskState}");

                    return BadRequest(new GenericResult(false, "Your transction was invalid. Please Contact administrator for support!"));
                }

                var b = "aAbBaSSSSSsCCC".ToLower();
                //compare transaction with blockchain transaction
                if (metamaskTransaction.AddressFrom.ToLower() != transaction.From.ToLower() || metamaskTransaction.AddressTo.ToLower() != transaction.To.ToLower())
                {
                    metamaskTransaction.DateUpdated = DateTime.Now;
                    metamaskTransaction.MetaMaskState = MetaMaskState.Failed;

                    _logger.LogError($"VerifyMetaMaskRequest: Transaction's infor was not matched: ", transaction);

                    return BadRequest(new GenericResult(false, "Your transction was invalid. Please Contact administrator for support!"));
                }

                var balance = Web3.Convert.FromWei(transaction.Value);
                //compare amount
                if (balance != metamaskTransaction.BNBAmount)
                {
                    metamaskTransaction.DateUpdated = DateTime.Now;
                    metamaskTransaction.MetaMaskState = MetaMaskState.Failed;

                    _logger.LogError($"VerifyMetaMaskRequest: Transaction's balance was not matched: {balance}");

                    return BadRequest(new GenericResult(false, "Your transction was invalid. Please Contact administrator for support!"));
                }

                var depositMessage = _botTelegramService.BuildReportDepositPresaleMessage(new Application.ViewModels.BotTelegram.PresaleMessageParam
                {
                    AmountBNB = balance,
                    DepositAt = DateTime.Now,
                    AmountTTS = metamaskTransaction.TTSAmount,
                    UserWallet = metamaskTransaction.AddressFrom,
                    SystemWallet = metamaskTransaction.AddressTo
                });

                await _botTelegramService.SendMessageAsyncWithSendingBalance(Application.Implementation.ActionType.Deposit, depositMessage, CommonConstants.DepositGroup);

                metamaskTransaction.MetaMaskState = MetaMaskState.Confirmed;
                metamaskTransaction.BNBTransactionHash = transactionHash;

                //send TTS
                var TTSTransactionHash = await _blockChain
                           .SendERC20Async(CommonConstants.BEP20EXCHANGEPrKey,
                           metamaskTransaction.AddressFrom,
                           CommonConstants.BEP20TTSContract, metamaskTransaction.TTSAmount,
                           CommonConstants.BEP20TTSDP, CommonConstants.BEP20Url);

                if (!string.IsNullOrWhiteSpace(TTSTransactionHash))
                {
                    metamaskTransaction.TTSAmount = metamaskTransaction.TTSAmount;
                    metamaskTransaction.TTSTransactionHash = TTSTransactionHash;

                    var receivedMessage = _botTelegramService.BuildReportReceivePresaleMessage(new Application.ViewModels.BotTelegram.PresaleMessageParam
                    {
                        AmountBNB = balance,
                        ReceivedAt = DateTime.Now,
                        AmountTTS = metamaskTransaction.TTSAmount,
                        UserWallet = metamaskTransaction.AddressFrom,
                        SystemWallet = CommonConstants.BEP20EXCHANGEPuKey
                    });

                    await _botTelegramService.SendMessageAsyncWithSendingBalance(Application.Implementation.ActionType.Deposit, receivedMessage, CommonConstants.WithdrawGroup);
                }

                metamaskTransaction.DateUpdated = DateTime.Now;

                _unitOfWork.Commit();

                _logger.LogInformation($"End call VerifyMetaMaskRequest with transaction hash: {TTSTransactionHash}");

                return Ok(new GenericResult(true, "Successed to Buy TTS"));
            }
            catch (Exception e)
            {
                _logger.LogError("Internal Error", e);

                return BadRequest(new GenericResult(false, "Somethings went wrong! Please Contact administrator for support."));
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateErrorMetaMask([FromBody] MetaMaskErrorParams model)
        {
            var convertor = new Nethereum.Hex.HexConvertors.HexUTF8StringConvertor();

            var transactionId = convertor.ConvertFromHex(model.TransactionHex);

            var result = _metamaskTransaction.FindById(Guid.Parse(transactionId));

            switch (model.ErrorCode)
            {
                case "4001":
                    result.MetaMaskState = MetaMaskState.Rejected;
                    break;
                case "-32603":
                    result.MetaMaskState = MetaMaskState.Failed;
                    break;
                default:
                    result.MetaMaskState = MetaMaskState.Failed;
                    break;
            }

            _unitOfWork.Commit();
            return Ok(new GenericResult(true, "Successed to update."));
        }

        [HttpGet("{amount}")]
        public async Task<IActionResult> GetAmountTTSPerBNB(decimal amount)
        {
            decimal priceBNBBep20 = _blockChain.GetCurrentPrice("BNB", "USD");
            if (priceBNBBep20 == 0)
                return new OkObjectResult(new GenericResult(false, "There is a problem loading the currency value!"));

            decimal amountTTS = ConculateTTSAmount(amount, priceBNBBep20);

            return Ok(new GenericResult(true, amountTTS));
        }

        private decimal ConculateTTSAmount(decimal bnbAmount, decimal priceBNBBep20)
        {
            decimal priceTTS = 0.12M;
            var amountUSD = Math.Round(bnbAmount * priceBNBBep20, 2);
            return Math.Round(amountUSD / priceTTS, 2);
        }
    }
}
