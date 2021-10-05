using BeCoreApp.Application.ViewModels.Blog;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Application.ViewModels.Game;
using BeCoreApp.Application.ViewModels.Valuesshare;
using BeCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace BeCoreApp.Application.ViewModels.System
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            Roles = new List<string>();
            Transactions = new List<TransactionViewModel>();
            Supports = new List<SupportViewModel>();
            WalletBNBBEP20Transactions = new List<WalletBNBBEP20TransactionViewModel>();
            TicketTransactions = new List<TicketTransactionViewModel>();
            WalletBNBAffiliateTransactions = new List<WalletBNBAffiliateTransactionViewModel>();
            WalletInvestTransactions = new List<WalletInvestTransactionViewModel>();
            WalletLockTransactions = new List<WalletLockTransactionViewModel>();
            LuckyRoundHistories = new List<LuckyRoundHistoryViewModel>();
        }

        public Guid? Id { set; get; }
        public Guid? ReferralId { get; set; }
        public string Sponsor { get; set; }
        public bool IsSystem { get; set; }
        public string Email { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool EmailConfirmed { get; set; }
        public bool Enabled2FA { get; set; }
        public string AuthenticatorCode { get; set; }
        public string ReferalLink { get; set; }

        public string BNBBEP20PublishKey { get; set; }

        public string MainPrivateKey { get; set; }
        public string MainPublishKey { get; set; }
        public decimal MainBalance { get; set; }

        public decimal BNBAffiliateBalance { get; set; }

        public decimal InvestBalance { get; set; }

        public decimal LockBalance { get; set; }

        public decimal TTSCommissionBalance { get; set; }

        public decimal TTSAffiliateBalance { get; set; }

        public decimal StakingBalance { get; set; }
        public decimal StakingInterest { get; set; }

        public int TicketBalance { get; set; }

        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string ByCreated { get; set; }
        public string ByModified { get; set; }

        public List<string> Roles { get; set; }
        public List<TransactionViewModel> Transactions { set; get; }
        public List<SupportViewModel> Supports { set; get; }
        public List<TicketTransactionViewModel> TicketTransactions { set; get; }
        public List<WalletBNBBEP20TransactionViewModel> WalletBNBBEP20Transactions { set; get; }
        public List<WalletBNBAffiliateTransactionViewModel> WalletBNBAffiliateTransactions { set; get; }
        public List<WalletInvestTransactionViewModel> WalletInvestTransactions { set; get; }
        public List<WalletLockTransactionViewModel> WalletLockTransactions { set; get; }
        public List<LuckyRoundHistoryViewModel> LuckyRoundHistories { get; set; }
    }
}
