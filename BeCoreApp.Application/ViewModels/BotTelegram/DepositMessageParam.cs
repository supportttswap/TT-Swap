using System;
using System.Collections.Generic;
using System.Text;

namespace BeCoreApp.Application.ViewModels.BotTelegram
{
    public class DepositMessageParam
    {
        public string Email { get; set; }
        public int? UserId { get; set; }
        public string SponsorEmail { get; set; }
        public int? SponsorId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal AmountUSD { get; set; }
        public decimal Rate { get; set; }
        public string Wallet { get; set; }
        public DateTime DepositeTime { get; set; }
    }
}
