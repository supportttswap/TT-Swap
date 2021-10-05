using BeCoreApp.Data.Enums;
using System;

namespace BeCoreApp.Application.ViewModels.System
{
    public class TicketTransactionViewModel
    {
        public int Id { get; set; }

        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }

        public decimal Fee { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal AmountReceive { get; set; }

        public decimal Amount { get; set; }
        public string StrAmount { get; set; }

        public TicketTransactionUnit Unit { get; set; }
        public string UnitName { get; set; }

        public TicketTransactionType Type { get; set; }
        public string TypeName { get; set; }

        public TicketTransactionStatus Status { get; set; }
        public string StatusName { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Sponsor { get; set; }

        public Guid AppUserId { get; set; }
        public string AppUserName { get; set; }

        public AppUserViewModel AppUser { set; get; }
    }
}
