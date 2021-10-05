using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum WalletInvestTransactionType
    {
        [Description("Deposit")]
        Deposit = 1,
        [Description("Withdraw")]
        Withdraw = 2,
        [Description("Deposit Private Sale")]
        DepositPrivateSale = 3,
        [Description("Airdrop")]
        Airdrop = 4,
        [Description("Win Lucky Round")]
        WinLuckyRound = 5
    }
}