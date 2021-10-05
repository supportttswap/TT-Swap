using System;
using System.Collections.Generic;
using System.Text;

namespace BeCoreApp.Application.ViewModels.BotTelegram
{
    public class ComisionMessageParam
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public string AddressTo { get; set; }
        public string AddressFrom { get; set; }
        public DateTime RecievedAt { get; set; }
        public decimal Rate { get; set; }
    }
}
