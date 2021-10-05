using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Report;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Data.IRepositories;
using BeCoreApp.Infrastructure.Interfaces;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Implementation
{
    public class ReportService : IReportService
    {
        private readonly ITicketTransactionRepository _ticketTransactionRepository;
        private readonly IWalletBNBAffiliateTransactionRepository _walletBNBAffiliateTransactionRepository;
        private readonly IWalletBNBBEP20TransactionRepository _walletBNBBEP20TransactionRepository;
        private readonly IWalletInvestTransactionRepository _walletInvestTransactionRepository;
        private readonly IWalletLockTransactionRepository _walletLockTransactionRepository;
        private readonly IBlockChainService _blockChainService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public ReportService(
            IWalletBNBAffiliateTransactionRepository walletBNBAffiliateTransactionRepository,
            IWalletBNBBEP20TransactionRepository walletBNBBEP20TransactionRepository,
            IWalletInvestTransactionRepository walletInvestTransactionRepository,
            IWalletLockTransactionRepository walletLockTransactionRepository,
            UserManager<AppUser> userManager,
            IBlockChainService blockChainService,
            ITicketTransactionRepository ticketTransactionRepository,
            IUnitOfWork unitOfWork)
        {
            _walletBNBAffiliateTransactionRepository = walletBNBAffiliateTransactionRepository;
            _walletBNBBEP20TransactionRepository = walletBNBBEP20TransactionRepository;
            _walletInvestTransactionRepository = walletInvestTransactionRepository;
            _walletLockTransactionRepository = walletLockTransactionRepository;
            _blockChainService = blockChainService;
            _userManager = userManager;
            _ticketTransactionRepository = ticketTransactionRepository;
            _unitOfWork = unitOfWork;
        }

        public ReportViewModel GetReportInfo(string startDate, string endDate)
        {
            DateTime now = DateTime.Now.Date;

            var appUsers = _userManager.Users;

            var model = new ReportViewModel();
            model.TotalMember = appUsers.Count();
            model.TodayMember = appUsers.Count(x => x.DateCreated.Date == now);
            model.TotalMemberInVerifyEmail = appUsers.Count(x => x.EmailConfirmed == false);
            model.TotalMemberVerifyEmail = appUsers.Count(x => x.EmailConfirmed == true);


            #region BNBBEP20
            var bnbBEP20Transactions = _walletBNBBEP20TransactionRepository.FindAll();

            model.TodayBNBBEP20Deposit = bnbBEP20Transactions
                .Where(x => x.Type == WalletBNBBEP20TransactionType.Deposit
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            model.TodayBNBBEP20Withdraw = bnbBEP20Transactions
                .Where(x => x.Type == WalletBNBBEP20TransactionType.Withdraw
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                DateTime start = DateTime.Parse(startDate);
                bnbBEP20Transactions = bnbBEP20Transactions.Where(x => x.DateCreated.Date >= start);
            }

            if (!string.IsNullOrWhiteSpace(endDate))
            {
                DateTime end = DateTime.Parse(endDate);
                bnbBEP20Transactions = bnbBEP20Transactions.Where(x => x.DateCreated.Date <= end);
            }


            model.TotalBNBBEP20Deposit = bnbBEP20Transactions
                .Where(x => x.Type == WalletBNBBEP20TransactionType.Deposit).Sum(x => x.Amount);

            model.TotalBNBBEP20Withdraw = bnbBEP20Transactions
                .Where(x => x.Type == WalletBNBBEP20TransactionType.Withdraw).Sum(x => x.Amount);
            #endregion

            #region BNBAffiliate
            var bnbAffiliateTransactions = _walletBNBAffiliateTransactionRepository.FindAll();

            model.TodayBNBAffiliateDeposit = bnbAffiliateTransactions
                .Where(x => x.Type == WalletBNBAffiliateTransactionType.Deposit
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            model.TodayBNBAffiliateWithdraw = bnbAffiliateTransactions
                .Where(x => x.Type == WalletBNBAffiliateTransactionType.Withdraw
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                DateTime start = DateTime.Parse(startDate);
                bnbAffiliateTransactions = bnbAffiliateTransactions.Where(x => x.DateCreated.Date >= start);
            }

            if (!string.IsNullOrWhiteSpace(endDate))
            {
                DateTime end = DateTime.Parse(endDate);
                bnbAffiliateTransactions = bnbAffiliateTransactions.Where(x => x.DateCreated.Date <= end);
            }

            model.TotalBNBAffiliateDeposit = bnbAffiliateTransactions
               .Where(x => x.Type == WalletBNBAffiliateTransactionType.Deposit).Sum(x => x.Amount);

            model.TotalBNBAffiliateWithdraw = bnbAffiliateTransactions
                .Where(x => x.Type == WalletBNBAffiliateTransactionType.Withdraw).Sum(x => x.Amount);
            #endregion

            #region Invest
            var investTransactions = _walletInvestTransactionRepository.FindAll();

            model.TodayInvestDeposit = investTransactions
                .Where(x => x.Type == WalletInvestTransactionType.Deposit
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            model.TodayInvestWithdraw = investTransactions
                .Where(x => x.Type == WalletInvestTransactionType.Withdraw
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                DateTime start = DateTime.Parse(startDate);
                investTransactions = investTransactions.Where(x => x.DateCreated.Date >= start);
            }

            if (!string.IsNullOrWhiteSpace(endDate))
            {
                DateTime end = DateTime.Parse(endDate);
                investTransactions = investTransactions.Where(x => x.DateCreated.Date <= end);
            }

            model.TotalInvestDeposit = investTransactions
                .Where(x => x.Type == WalletInvestTransactionType.Deposit).Sum(x => x.Amount);

            model.TotalInvestWithdraw = investTransactions
                .Where(x => x.Type == WalletInvestTransactionType.Withdraw).Sum(x => x.Amount);
            #endregion

            #region Lock
            var lockTransactions = _walletLockTransactionRepository.FindAll();

            model.TodayLockDeposit = lockTransactions
                .Where(x => x.Type == WalletLockTransactionType.Deposit
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            model.TodayLockWithdraw = lockTransactions
                .Where(x => x.Type == WalletLockTransactionType.Withdraw
                && x.DateCreated.Date == now).Sum(x => x.Amount);

            if (!string.IsNullOrWhiteSpace(startDate))
            {
                DateTime start = DateTime.Parse(startDate);
                lockTransactions = lockTransactions.Where(x => x.DateCreated.Date >= start);
            }

            if (!string.IsNullOrWhiteSpace(endDate))
            {
                DateTime end = DateTime.Parse(endDate);
                lockTransactions = lockTransactions.Where(x => x.DateCreated.Date <= end);
            }

            model.TotalLockDeposit = lockTransactions
                .Where(x => x.Type == WalletLockTransactionType.Deposit).Sum(x => x.Amount);

            model.TotalLockWithdraw = lockTransactions
                .Where(x => x.Type == WalletLockTransactionType.Withdraw).Sum(x => x.Amount);

            #endregion

            return model;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
