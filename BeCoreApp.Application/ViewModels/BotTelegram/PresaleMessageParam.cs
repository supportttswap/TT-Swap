using System;
using System.Collections.Generic;
using System.Text;

namespace BeCoreApp.Application.ViewModels.BotTelegram
{
    public class PresaleMessageParam
    {
        public decimal AmountBNB { get; set; }
        public decimal AmountTTS { get; set; }
        public string UserWallet { get; set; }
        public string SystemWallet { get; set; }
        public DateTime DepositAt{ get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
