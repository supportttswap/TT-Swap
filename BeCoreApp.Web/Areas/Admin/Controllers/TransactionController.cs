using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.BlockChain;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace BeCoreApp.Areas.Admin.Controllers
{
    public class TransactionController : BaseController
    {
        public readonly ITransactionService _transactionService;
        public readonly IWalletBNBBEP20TransactionService _walletBNBBEP20TransactionService;
        public readonly IWalletBNBAffiliateTransactionService _walletBNBAffiliateTransactionService;
        public readonly IWalletInvestTransactionService _walletInvestTransactionService;
        public readonly IWalletLockTransactionService _walletLockTransactionService;
        private readonly UserManager<AppUser> _userManager;

        public TransactionController(
            IWalletLockTransactionService walletLockTransactionService,
            IWalletInvestTransactionService walletInvestTransactionService,
            IWalletBNBAffiliateTransactionService walletBNBAffiliateTransactionService,
            IWalletBNBBEP20TransactionService walletBNBBEP20TransactionService,
            UserManager<AppUser> userManager,
            ITransactionService transactionService
            )
        {
            _walletLockTransactionService = walletLockTransactionService;
            _walletInvestTransactionService = walletInvestTransactionService;
            _walletBNBAffiliateTransactionService = walletBNBAffiliateTransactionService;
            _walletBNBBEP20TransactionService = walletBNBBEP20TransactionService;
            _userManager = userManager;
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            string appUserId = string.Empty;

            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() == "customer")
            {
                appUserId = User.GetSpecificClaim("UserId");
            }

            var model = _transactionService.GetAllPaging(keyword, appUserId, page, pageSize);
            return new OkObjectResult(model);
        }

        public IActionResult WalletBNBBEP20()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllWalletbnbbep20Paging(string keyword, int page, int pageSize)
        {
            string appUserId = string.Empty;

            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() == "customer")
            {
                appUserId = User.GetSpecificClaim("UserId");
            }

            var model = _walletBNBBEP20TransactionService.GetAllPaging(keyword, appUserId, page, pageSize);
            return new OkObjectResult(model);
        }

        public IActionResult WalletBNBAffiliate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllWalletBNBAffiliatePaging(string keyword, int page, int pageSize)
        {
            string appUserId = string.Empty;

            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() == "customer")
            {
                appUserId = User.GetSpecificClaim("UserId");
            }

            var model = _walletBNBAffiliateTransactionService.GetAllPaging(keyword, appUserId, page, pageSize);
            return new OkObjectResult(model);
        }

        public IActionResult WalletInvest()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllWalletInvestPaging(string keyword, int page, int pageSize)
        {
            string appUserId = string.Empty;

            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() == "customer")
            {
                appUserId = User.GetSpecificClaim("UserId");
            }

            var model = _walletInvestTransactionService.GetAllPaging(keyword, appUserId, page, pageSize);
            return new OkObjectResult(model);
        }

        public IActionResult WalletLock()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllWalletLockPaging(string keyword, int page, int pageSize)
        {
            string appUserId = string.Empty;

            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() == "customer")
            {
                appUserId = User.GetSpecificClaim("UserId");
            }

            var model = _walletLockTransactionService.GetAllPaging(keyword, appUserId, page, pageSize);
            return new OkObjectResult(model);
        }
    }
}