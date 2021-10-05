using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.BlockChain;
using BeCoreApp.Application.ViewModels.BotTelegram;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Application.ViewModels.Valuesshare;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
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
    public class ExchangeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlockChainService _blockChainService;
        private readonly IWalletInvestTransactionService _walletInvestTransactionService;
        private readonly IWalletLockTransactionService _walletLockTransactionService;
        private readonly IWalletBNBAffiliateTransactionService _walletBNBAffiliateTransactionService;
        private readonly IWalletBNBBEP20TransactionService _walletBNBBEP20TransactionService;
        private readonly ITransactionService _transactionService;
        private readonly ILogger<ExchangeController> _logger;
        private readonly AddressUtil _addressUtil = new AddressUtil();
        private readonly IEmailSender _emailSender;
        private readonly IChartRoundService _chartRoundService;
        public ExchangeController(
            IWalletBNBBEP20TransactionService walletBNBBEP20TransactionService,
            IWalletBNBAffiliateTransactionService walletBNBAffiliateTransactionService,
            IChartRoundService chartRoundService,
            IWalletInvestTransactionService walletInvestTransactionService,
            IWalletLockTransactionService walletLockTransactionService,
            ILogger<ExchangeController> logger,
            ITransactionService transactionService,
            UserManager<AppUser> userManager,
            IUserService userService,
            IEmailSender emailSender,
            IBlockChainService blockChainService)
        {
            _walletBNBAffiliateTransactionService = walletBNBAffiliateTransactionService;
            _walletBNBBEP20TransactionService = walletBNBBEP20TransactionService;
            _chartRoundService = chartRoundService;
            _walletInvestTransactionService = walletInvestTransactionService;
            _walletLockTransactionService = walletLockTransactionService;
            _logger = logger;
            _transactionService = transactionService;
            _userManager = userManager;
            _blockChainService = blockChainService;
            _userService = userService;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult CaculationTTSByBNB(string modelJson)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<ExchangeTTSViewModel>(modelJson);

                decimal priceTTS = 0.1M;

                decimal priceBNBBep20 = _blockChainService.GetCurrentPrice("BNB", "USD");
                if (priceBNBBep20 == 0)
                    return new OkObjectResult(new GenericResult(false, "There is a problem loading the currency value!"));

                var amountUSD = Math.Round(model.OrderBNB * priceBNBBep20, 2);

                decimal amountTTS = Math.Round(amountUSD / priceTTS, 2);

                decimal amountTTSPercent = amountTTS / 2;

                decimal amountTTSInvest = amountTTSPercent;

                decimal amountTTSLock = amountTTSPercent + (amountTTSPercent * 0.1m);

                decimal TTSRecevice = amountTTSInvest + amountTTSLock;

                model.AmountTTS = Math.Round(TTSRecevice, 2);

                return new OkObjectResult(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("ExchangeController_CaculationTTSByBNB: {0}", ex.Message);
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWalletBlanceByType(int type)
        {
            var userId = User.GetSpecificClaim("UserId");
            var appUser = await _userService.GetById(userId);
            decimal bnbBalance = 0;
            if (type == 1)
            {
                bnbBalance = appUser.MainBalance;
            }
            if (type == 2)
            {
                bnbBalance = appUser.BNBAffiliateBalance;
            }

            return new OkObjectResult(bnbBalance);
        }

        [HttpGet]
        public async Task<IActionResult> GetWalletBlance()
        {
            var userId = User.GetSpecificClaim("UserId");
            var appUser = await _userService.GetById(userId);
            var model = new WalletViewModel()
            {
                MainBalance = appUser.MainBalance,
            };

            return new OkObjectResult(model);
        }


        private async Task SendComisionMail(TransactionViewModel vm)
        {
            try
            {
                var appUser = await _userManager.FindByIdAsync(vm.AppUserId.ToString());
                if (appUser != null)
                {
                    var parameters = new ComisionMessageParam
                    {
                        Amount = vm.Amount,
                        RecievedAt = DateTime.Now,
                        AddressTo = vm.AddressTo,
                        Unit = vm.Unit.ToString(),
                        Rate = vm.Unit == TransactionUnit.BNB ? vm.PriceBNB : 0,
                        AddressFrom = vm.AddressFrom
                    };

                    var message = _emailSender.BuildReportCommisionMessage(parameters);

                    await _emailSender.TrySendEmailAsync(appUser.Email, $"Commission received {DateTime.UtcNow.ToTTSFormatTime()}(UTC)", message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to Send Commision Mail");
            }
        }
    }
}