using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum WalletBNBAffiliateTransactionType
    {
        [Description("Deposit")]
        Deposit = 1,
        [Description("Withdraw")]
        Withdraw = 2,
        [Description("Pay Private Sale")]
        PayPrivateSale = 3
    }
}
