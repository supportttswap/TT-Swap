using BeCoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeCoreApp.Application.ViewModels.System
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string TransactionHash { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }

        public decimal Amount { get; set; }
        public string StrAmount { get; set; }

        public TransactionUnit Unit { get; set; }
        public string UnitName { get; set; }

        public TransactionType Type { get; set; }

        public string TypeName { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid AppUserId { get; set; }
        public string Sponsor { get; set; }
        public string AppUserName { get; set; }

        public decimal PriceBNB { get; set; }

        public AppUserViewModel AppUser { set; get; }
    }
}
