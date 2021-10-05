using System;
using System.Linq;
using System.Threading.Tasks;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Game;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using BeCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nethereum.Util;

namespace BeCoreApp.Areas.Admin.Controllers
{
    public class GameController : BaseController
    {
        private readonly IWalletInvestTransactionService _walletInvestTransactionService;
        private readonly IWalletBNBAffiliateTransactionService _walletBNBAffiliateTransactionService;
        private readonly IWalletBNBBEP20TransactionService _walletBNBBEP20TransactionService;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBlockChainService _blockChainService;
        private readonly ITransactionService _transactionService;
        private readonly ITRONService _tronService;
        private readonly ILogger<WalletController> _logger;
        private readonly AddressUtil _addressUtil = new AddressUtil();
        private readonly ILuckyRoundHistoryService _luckyRoundHistoryService;
        private readonly ILuckyRoundService _luckyRoundService;
        public GameController(
            IWalletInvestTransactionService walletInvestTransactionService,
            IWalletBNBAffiliateTransactionService walletBNBAffiliateTransactionService,
            IWalletBNBBEP20TransactionService walletBNBBEP20TransactionService,
            ILuckyRoundHistoryService luckyRoundHistoryService,
            ILuckyRoundService luckyRoundService,
            ILogger<WalletController> logger,
            ITRONService tronService,
            ITransactionService transactionService,
            UserManager<AppUser> userManager,
            IUserService userService,
            IBlockChainService blockChainService)
        {
            _walletInvestTransactionService = walletInvestTransactionService;
            _walletBNBAffiliateTransactionService = walletBNBAffiliateTransactionService;
            _walletBNBBEP20TransactionService = walletBNBBEP20TransactionService;
            _luckyRoundHistoryService = luckyRoundHistoryService;
            _luckyRoundService = luckyRoundService;
            _logger = logger;
            _tronService = tronService;
            _transactionService = transactionService;
            _userManager = userManager;
            _blockChainService = blockChainService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LuckyRound()
        {
            return View();
        }
    }
}