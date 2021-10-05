using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using BeCoreApp.Application.Implementation;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.BlockChain;
using BeCoreApp.Application.ViewModels.BotTelegram;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Application.ViewModels.Valuesshare;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using BeCoreApp.Models.AccountViewModels;
using BeCoreApp.Services;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Newtonsoft.Json;


namespace BeCoreApp.Areas.Admin.Controllers
{
    public class WalletController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlockChainService _blockChainService;
        private readonly ITransactionService _transactionService;
        private readonly ITRONService _tronService;
        private readonly ILogger<WalletController> _logger;
        private readonly AddressUtil _addressUtil = new AddressUtil();
        private readonly IWalletBNBBEP20TransactionService _walletBNBBEP20TransactionService;
        private readonly ITicketTransactionService _ticketTransactionService;
        private readonly IBotTelegramService _botSrv;
        private readonly IEmailSender _emailSender;
        public WalletController(
            ITicketTransactionService ticketTransactionService,
            IWalletBNBBEP20TransactionService walletBNBBEP20TransactionService,
            ILogger<WalletController> logger,
            ITRONService tronService,
            ITransactionService transactionService,
            UserManager<AppUser> userManager,
            IUserService userService,
            IBotTelegramService botSrv,
            IEmailSender emailSender,
            IBlockChainService blockChainService)
        {
            _ticketTransactionService = ticketTransactionService;
            _walletBNBBEP20TransactionService = walletBNBBEP20TransactionService;
            _logger = logger;
            _tronService = tronService;
            _transactionService = transactionService;
            _userManager = userManager;
            _blockChainService = blockChainService;
            _userService = userService;
            _botSrv = botSrv;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.GetSpecificClaim("UserId");
            var appUser = await _userService.GetById(userId);

            return View(new WalletViewModel
            {
                AuthenticatorCode = appUser.AuthenticatorCode,
                Enabled2FA = appUser.Enabled2FA,
                MainPublishKey = appUser.MainPublishKey
            });
        }

        public class WithdrawBNBBEP20ViewModel
        {
            public decimal Amount { get; set; }
            public string AddressTo { get; set; }
            public string Password { get; set; }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WithdrawWalletBNBBEP20([FromBody] WithdrawBNBBEP20ViewModel model, [FromQuery] string authenticatorCode)
        {
            try
            {
                var userId = User.GetSpecificClaim("UserId");

                var appUser = await _userManager.FindByIdAsync(userId);

                if (appUser == null)
                {
                    return new OkObjectResult(new GenericResult(false, "Account does not exist"));
                }

                if (CommonConstants.MemberAccessDenied.Count(x => x.Email.ToLower() == appUser.Email.ToLower()) > 0)
                {
                    return new OkObjectResult(new GenericResult(false, "Account access denied!!!!"));
                }

                var isMatched = await _userManager.CheckPasswordAsync(appUser, model.Password);

                if (!isMatched)
                {
                    return new OkObjectResult(new GenericResult(false, "Wrong password"));
                }

                if (appUser.TwoFactorEnabled)
                {
                    var isValid = await VerifyCode(authenticatorCode, _userManager, appUser);

                    if (!isValid) return new OkObjectResult(new GenericResult(false, "Invalid authenticator code"));
                }

                if (model.Amount < 0.05m)
                {
                    return new OkObjectResult(new GenericResult(false, "Minimum withdraw 0.05 BNB"));
                }

                if (model.Amount > appUser.MainBalance)
                {
                    return new OkObjectResult(new GenericResult(false,
                        "Your balance is not enough to make a transaction"));
                }

                model.AddressTo = _addressUtil.ConvertToChecksumAddress(model.AddressTo);
                if (!_addressUtil.IsChecksumAddress(model.AddressTo) || !_addressUtil.IsValidAddressLength(model.AddressTo))
                {
                    return new OkObjectResult(new GenericResult(false,
                        "Received wallet address is not in standard format BEP20"));
                }

                appUser.MainBalance -= model.Amount;
                var resultMainBalanceUpdate = await _userManager.UpdateAsync(appUser);
                if (resultMainBalanceUpdate.Succeeded)
                {
                    //Start Adjust Code Fee
                    decimal fee = 0.01m;
                    decimal feeAmount = model.Amount * fee;
                    decimal amountReceive = model.Amount - feeAmount;
                    //End Adjust Code Fee

                    var ticketTransaction = new TicketTransactionViewModel
                    {
                        Fee = fee,
                        FeeAmount = feeAmount,
                        AmountReceive = amountReceive,
                        Amount = model.Amount,
                        AddressTo = model.AddressTo,
                        AddressFrom = CommonConstants.BEP20PAYAFFILIATEPuKey,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        AppUserId = appUser.Id,
                        Unit = TicketTransactionUnit.BNB,
                        Status = TicketTransactionStatus.Pending,
                        Type = TicketTransactionType.WithdrawBNBBEP20
                    };
                    _ticketTransactionService.Add(ticketTransaction);
                    _ticketTransactionService.Save();

                    try
                    {
                        var usd = _blockChainService.GetCurrentPrice("BNB", "USD");

                        var parameters = new WithdrawMessageParam
                        {
                            Amount = amountReceive,
                            WithDrawTime = DateTime.Now,
                            Email = appUser.Email,
                            UserId = appUser.Sponsor,
                            Wallet = model.AddressTo,
                            Currency = TicketTransactionUnit.BNB.ToString(),
                            Rate = usd,
                            Fee = feeAmount,
                        };

                        if (appUser.ReferralId.HasValue)
                        {
                            var refferal = await _userManager.FindByIdAsync(appUser.ReferralId.ToString());

                            parameters.SponsorEmail = refferal.Email;
                            parameters.SponsorId = refferal.Sponsor;
                        }

                        var message = _botSrv.BuildReportWITHDRAWMessage(parameters);

                        await _botSrv.SendMessageAsyncWithSendingBalance(ActionType.Withdraw, message, CommonConstants.WithdrawGroup);
                    }
                    catch (Exception ex)
                    {
                    }

                    return new OkObjectResult(new GenericResult(true, "Create request withdraw from Wallet BNB BEP20 successful"));
                }
                else
                {
                    return new OkObjectResult(new GenericResult(false,
                        resultMainBalanceUpdate.Errors.FirstOrDefault().Description));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("WalletController_WithdrawWalletBNBBEP20: {0}", ex.Message);
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }

        public class WithdrawBNBAffiliateViewModel
        {
            public decimal Amount { get; set; }
            public string AddressTo { get; set; }
            public string Password { get; set; }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WithdrawWalletBNBAffiliate([FromBody] WithdrawBNBAffiliateViewModel model, [FromQuery] string authenticatorCode)
        {
            try
            {
                var userId = User.GetSpecificClaim("UserId");

                var appUser = await _userManager.FindByIdAsync(userId);
                if (appUser == null)
                {
                    return new OkObjectResult(new GenericResult(false, "Account does not exist"));
                }

                if (CommonConstants.MemberAccessDenied.Count(x => x.Email.ToLower() == appUser.Email.ToLower()) > 0)
                {
                    return new OkObjectResult(new GenericResult(false, "Account access denied!!!!"));
                }

                if (appUser.TwoFactorEnabled)
                {
                    var isValid = await VerifyCode(authenticatorCode, _userManager, appUser);

                    if (!isValid) return new OkObjectResult(new GenericResult(false, "Invalid authenticator code"));
                }

                var isMatched = await _userManager.CheckPasswordAsync(appUser, model.Password);

                if (!isMatched)
                {
                    return new OkObjectResult(new GenericResult(false, "Wrong password"));
                }

                if (model.Amount < 0.05m)
                {
                    return new OkObjectResult(new GenericResult(false, "Minimum withdraw 0.05 BNB"));
                }

                if (model.Amount > appUser.BNBAffiliateBalance)
                {
                    return new OkObjectResult(new GenericResult(false,
                        "Your balance is not enough to make a transaction"));
                }

                model.AddressTo = _addressUtil.ConvertToChecksumAddress(model.AddressTo);
                if (!_addressUtil.IsChecksumAddress(model.AddressTo)
                    || !_addressUtil.IsValidAddressLength(model.AddressTo))
                {
                    return new OkObjectResult(new GenericResult(false,
                        "Received wallet address is not in standard format BEP20"));
                }

                appUser.BNBAffiliateBalance -= model.Amount;
                var resultBNBAffiliateBalanceUpdate = await _userManager.UpdateAsync(appUser);
                if (resultBNBAffiliateBalanceUpdate.Succeeded)
                {
                    //Start Adjust Code Fee
                    decimal fee = 0.01m;
                    decimal feeAmount = model.Amount * fee;
                    decimal amountReceive = model.Amount - feeAmount;
                    //End Adjust Code Fee

                    var ticketTransaction = new TicketTransactionViewModel
                    {
                        Fee = fee,
                        FeeAmount = feeAmount,
                        AmountReceive = amountReceive,
                        Amount = model.Amount,
                        AddressTo = model.AddressTo,
                        AddressFrom = CommonConstants.BEP20PAYAFFILIATEPuKey,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        AppUserId = appUser.Id,
                        Unit = TicketTransactionUnit.BNB,
                        Status = TicketTransactionStatus.Pending,
                        Type = TicketTransactionType.WithdrawBNBAffiliate
                    };
                    _ticketTransactionService.Add(ticketTransaction);
                    _ticketTransactionService.Save();

                    try
                    {
                        var usd = _blockChainService.GetCurrentPrice("BNB", "USD");

                        var parameters = new WithdrawMessageParam
                        {
                            Amount = amountReceive,
                            WithDrawTime = DateTime.Now,
                            Email = appUser.Email,
                            UserId = appUser.Sponsor,
                            Wallet = model.AddressTo,
                            Currency = TicketTransactionUnit.BNB.ToString(),
                            Rate = usd,
                            Fee = feeAmount,
                        };

                        if (appUser.ReferralId.HasValue)
                        {
                            var refferal = await _userManager.FindByIdAsync(appUser.ReferralId.ToString());

                            parameters.SponsorEmail = refferal.Email;
                            parameters.SponsorId = refferal.Sponsor;
                        }

                        var message = _botSrv.BuildReportWITHDRAWMessage(parameters);

                        await _botSrv.SendMessageAsyncWithSendingBalance(ActionType.Withdraw, message, CommonConstants.WithdrawGroup);
                    }
                    catch (Exception ex)
                    {

                    }

                    return new OkObjectResult(new GenericResult(true,
                        "Create request withdraw from Wallet BNB Affiliate successful"));
                }
                else
                {
                    return new OkObjectResult(new GenericResult(false,
                        resultBNBAffiliateBalanceUpdate.Errors.FirstOrDefault().Description));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("WalletController_WithdrawWalletBNBAffiliate: {0}", ex.Message);
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }

        public class WithdrawInvestViewModel
        {
            public decimal Amount { get; set; }
            public string AddressTo { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WithdrawWalletInvest([FromBody] WithdrawInvestViewModel model, [FromQuery] string authenticatorCode)
        {
            try
            {

                var userId = User.GetSpecificClaim("UserId");

                var appUser = await _userManager.FindByIdAsync(userId);
                if (appUser == null)
                {
                    return new OkObjectResult(new GenericResult(false, "Account does not exist"));
                }

                if (CommonConstants.MemberAccessDenied.Count(x => x.Email.ToLower() == appUser.Email.ToLower()) > 0)
                {
                    return new OkObjectResult(new GenericResult(false, "Account access denied!!!!"));
                }

                var isMatched = await _userManager.CheckPasswordAsync(appUser, model.Password);

                if (!isMatched)
                {
                    return new OkObjectResult(new GenericResult(false, "Wrong password"));
                }

                if (appUser.TwoFactorEnabled)
                {
                    var isValid = await VerifyCode(authenticatorCode, _userManager, appUser);

                    if (!isValid) return new OkObjectResult(new GenericResult(false, "Invalid authenticator code"));
                }

                if (model.Amount < 50)
                {
                    return new OkObjectResult(new GenericResult(false, "Minimum withdraw 50 TT-SWAP"));
                }

                if (model.Amount > appUser.InvestBalance)
                {
                    return new OkObjectResult(new GenericResult(false,
                        "Your balance is not enough to make a transaction"));
                }

                model.AddressTo = _addressUtil.ConvertToChecksumAddress(model.AddressTo);
                if (!_addressUtil.IsChecksumAddress(model.AddressTo)
                    || !_addressUtil.IsValidAddressLength(model.AddressTo))
                {
                    return new OkObjectResult(new GenericResult(false,
                        "Received wallet address is not in standard format BEP20"));
                }

                appUser.InvestBalance -= model.Amount;
                var resultInvestBalanceUpdate = await _userManager.UpdateAsync(appUser);
                if (resultInvestBalanceUpdate.Succeeded)
                {
                    //Start Adjust Code Fee
                    decimal fee = 0.02m;
                    decimal feeAmount = model.Amount * fee;
                    decimal amountReceive = model.Amount - feeAmount;
                    //End Adjust Code Fee

                    var ticketTransaction = new TicketTransactionViewModel
                    {
                        Fee = fee,
                        FeeAmount = feeAmount,
                        AmountReceive = amountReceive,
                        Amount = model.Amount,
                        AddressTo = model.AddressTo,
                        AddressFrom = CommonConstants.BEP20EXCHANGEPuKey,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        AppUserId = appUser.Id,
                        Unit = TicketTransactionUnit.TTS,
                        Status = TicketTransactionStatus.Pending,
                        Type = TicketTransactionType.WithdrawInvest
                    };
                    _ticketTransactionService.Add(ticketTransaction);
                    _ticketTransactionService.Save();

                    try
                    {
                        var usd = _blockChainService.GetCurrentPrice("BNB", "USD");

                        var parameters = new WithdrawMessageParam
                        {
                            Amount = amountReceive,
                            WithDrawTime = DateTime.Now,
                            Email = appUser.Email,
                            UserId = appUser.Sponsor,
                            Wallet = model.AddressTo,
                            Currency = TicketTransactionUnit.TTS.GetDescription(),
                            Rate = 0,
                            Fee = feeAmount,
                        };

                        if (appUser.ReferralId.HasValue)
                        {
                            var refferal = await _userManager.FindByIdAsync(appUser.ReferralId.ToString());

                            parameters.SponsorEmail = refferal.Email;
                            parameters.SponsorId = refferal.Sponsor;
                        }

                        var message = _botSrv.BuildReportWITHDRAWMessage(parameters);

                        await _botSrv.SendMessageAsyncWithSendingBalance(ActionType.Withdraw, message, CommonConstants.WithdrawGroup);
                    }
                    catch (Exception ex)
                    {

                    }

                    return new OkObjectResult(new GenericResult(true,
                        "Create request withdraw from Wallet Invest successful"));
                }
                else
                {
                    return new OkObjectResult(new GenericResult(false,
                        resultInvestBalanceUpdate.Errors.FirstOrDefault().Description));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("WalletController_WithdrawWalletInvest: {0}", ex.Message);
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }

        [HttpGet]
        public IActionResult GetAllTicketTransactionPaging(string keyword, int page, int pageSize)
        {
            string appUserId = string.Empty;

            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() == "customer")
            {
                appUserId = User.GetSpecificClaim("UserId");
            }

            var model = _ticketTransactionService.GetAllPaging(keyword, appUserId, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetWalletBlance()
        {
            try
            {
                var userId = User.GetSpecificClaim("UserId");

                var appUser = await _userManager.FindByIdAsync(userId);

                if (CommonConstants.MemberAccessDenied.Count(x => x.Email.ToLower() == appUser.Email.ToLower()) == 0)
                {
                    decimal mainBalance = await _blockChainService
                        .GetEtherBalance(appUser.MainPublishKey, CommonConstants.BEP20Url);

                    if (mainBalance >= 0.01m)
                    {
                        decimal balanceTransfer = Math.Round(mainBalance - 0.001m, 4);

                        var transactionDepositBNB = await _blockChainService
                            .SendEthAsync(appUser.MainPrivateKey, CommonConstants.BEP20SYSTEMPuKey,
                            balanceTransfer, CommonConstants.BEP20Url);

                        if (transactionDepositBNB.HasErrors() != true)
                        {
                            appUser.MainBalance += mainBalance;
                            var resultUpdateUser = await _userManager.UpdateAsync(appUser);
                            if (resultUpdateUser.Succeeded)
                            {
                                var walletBNBBEP20Transaction = new WalletBNBBEP20TransactionViewModel
                                {
                                    AppUserId = appUser.Id,
                                    AddressFrom = appUser.MainPublishKey,
                                    AddressTo = CommonConstants.BEP20SYSTEMPuKey,

                                    Fee = 0,
                                    FeeAmount = 0,
                                    AmountReceive = mainBalance,
                                    Amount = mainBalance,

                                    TransactionHash = transactionDepositBNB.TransactionHash,
                                    Type = WalletBNBBEP20TransactionType.Deposit,
                                    DateCreated = DateTime.Now
                                };
                                _walletBNBBEP20TransactionService.Add(walletBNBBEP20Transaction);
                                _walletBNBBEP20TransactionService.Save();
                            }

                            try
                            {
                                //Report Deposit
                                var usd = _blockChainService.GetCurrentPrice("BNB", "USD");

                                var parameters = new DepositMessageParam
                                {
                                    Amount = balanceTransfer,
                                    DepositeTime = DateTime.Now,
                                    Email = appUser.Email,
                                    UserId = appUser.Sponsor,
                                    Wallet = appUser.MainPublishKey,
                                    Currency = TicketTransactionUnit.BNB.ToString(),
                                    Rate = usd,
                                };

                                if (appUser.ReferralId.HasValue)
                                {
                                    var refferal = await _userManager.FindByIdAsync(appUser.ReferralId.ToString());

                                    parameters.SponsorEmail = refferal.Email;
                                    parameters.SponsorId = refferal.Sponsor;
                                }

                                var message = _botSrv.BuildReportDEPOSITMessage(parameters);

                                await _botSrv.SendMessageAsyncWithSendingBalance(ActionType.Deposit, message, CommonConstants.DepositGroup);

                                var emailMessage = _emailSender.BuildReportDEPOSITMessage(parameters);

                                await _emailSender.TrySendEmailAsync(appUser.Email, $"Deposit confirmed {DateTime.UtcNow.ToTTSFormatTime()}(UTC)", emailMessage);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }

                var model = new WalletViewModel()
                {
                    TTSAffiliateBalance = appUser.TTSAffiliateBalance,
                    TTSCommissionBalance = appUser.TTSCommissionBalance,
                    BNBAffiliateBalance = appUser.BNBAffiliateBalance,
                    LockBalance = appUser.LockBalance,
                    InvestBalance = appUser.InvestBalance,
                    MainBalance = appUser.MainBalance,
                    MainPrivateKey = appUser.MainPublishKey,
                    StakingBalance = appUser.StakingBalance,
                    StakingInterest = appUser.StakingInterest
                };

                return new OkObjectResult(new GenericResult(true, model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }
    }
}