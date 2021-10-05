using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum WalletBNBBEP20TransactionType
    {
        [Description("Deposit")]
        Deposit = 1,
        [Description("Withdraw")]
        Withdraw = 2,
        [Description("Pay Private Sale")]
        PayPrivateSale = 3,
        [Description("Win Lucky Round")]
        WinLuckyRound = 4,
    }
}
