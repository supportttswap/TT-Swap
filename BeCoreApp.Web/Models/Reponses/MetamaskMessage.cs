using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Web.Models.Reponses
{
    public class MetamaskMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Value { get; set; }
        public string TransactionHex { get; set; }
        public string Gas { get; set; }
        public string GasPrice { get; set; }
    }
}
