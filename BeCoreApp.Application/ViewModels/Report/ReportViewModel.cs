using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeCoreApp.Application.ViewModels.Report
{
    public class ReportViewModel
    {
        public ReportViewModel()
        {
        }

        public int TotalMember { get; set; }
        public int TodayMember { get; set; }
        public int TotalMemberVerifyEmail { get; set; }
        public int TotalMemberInVerifyEmail { get; set; }

        public decimal TotalBNBBEP20Deposit { get; set; }
        public decimal TotalBNBBEP20Withdraw { get; set; }
        public decimal TodayBNBBEP20Deposit { get; set; }
        public decimal TodayBNBBEP20Withdraw { get; set; }

        public decimal TotalBNBAffiliateDeposit { get; set; }
        public decimal TotalBNBAffiliateWithdraw { get; set; }
        public decimal TodayBNBAffiliateDeposit { get; set; }
        public decimal TodayBNBAffiliateWithdraw { get; set; }

        public decimal TotalInvestDeposit { get; set; }
        public decimal TotalInvestWithdraw { get; set; }
        public decimal TodayInvestDeposit { get; set; }
        public decimal TodayInvestWithdraw { get; set; }

        public decimal TotalLockDeposit { get; set; }
        public decimal TotalLockWithdraw { get; set; }
        public decimal TodayLockDeposit { get; set; }
        public decimal TodayLockWithdraw { get; set; }
    }
}