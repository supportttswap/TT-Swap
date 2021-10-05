using BeCoreApp.Data.Enums;
using BeCoreApp.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeCoreApp.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public int? Sponsor { get; set; }
        public Guid? ReferralId { get; set; }

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

        public bool IsSystem { get; set; } = false;
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string ByCreated { get; set; }
        public string ByModified { get; set; }

        public virtual ICollection<CustomerTransaction> CustomerTransactions { set; get; }
        public virtual ICollection<Support> Supports { set; get; }
        public virtual ICollection<TicketTransaction> TicketTransactions { set; get; }
        public virtual ICollection<WalletBNBBEP20Transaction> WalletBNBBEP20Transactions { set; get; }
        public virtual ICollection<WalletBNBAffiliateTransaction> WalletBNBAffiliateTransactions { set; get; }
        public virtual ICollection<WalletInvestTransaction> WalletInvestTransactions { set; get; }
        public virtual ICollection<WalletLockTransaction> WalletLockTransactions { set; get; }
        public virtual ICollection<LuckyRoundHistory> LuckyRoundHistories { get; set; }
    }
}