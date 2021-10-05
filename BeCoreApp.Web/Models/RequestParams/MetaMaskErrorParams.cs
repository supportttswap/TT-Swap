using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Web.Models.RequestParams
{
    public class MetaMaskErrorParams
    {
        public string TransactionHex { get; set; }
        public string ErrorCode { get; set; }
    }
}
