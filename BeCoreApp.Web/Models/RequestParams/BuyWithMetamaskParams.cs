using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeCoreApp.Web.Models.RequestParams
{
    public class BuyWithMetamaskParams
    {
        public decimal BNBAmount { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
