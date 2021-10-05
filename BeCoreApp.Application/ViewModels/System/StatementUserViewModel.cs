using BeCoreApp.Application.ViewModels.Blog;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Application.ViewModels.Valuesshare;
using BeCoreApp.Data.Enums;
using System;
using System.Collections.Generic;

namespace BeCoreApp.Application.ViewModels.System
{
    public class StatementUserViewModel
    {
        public StatementUserViewModel()
        {
            AppUsers = new List<AppUserViewModel>();
        }

        public int TotalMember { get; set; }

        public decimal TotalMainBalance { get; set; }

        public decimal TotalBNBAffiliateBalance { get; set; }

        public decimal TotalLockBalance { get; set; }

        public decimal TotalInvestBalance { get; set; }

        public decimal TotalTTSAffiliateBalance { get; set; }

        public decimal TotalTTSCommissionBalance { get; set; }

        public List<AppUserViewModel> AppUsers { set; get; }
    }
}
