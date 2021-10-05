using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum WalletLockTransactionType
    {
        [Description("Deposit")]
        Deposit = 1,
        [Description("Withdraw")]
        Withdraw = 2,
        [Description("Deposit Private Sale")]
        DepositPrivateSale = 3
    }
}