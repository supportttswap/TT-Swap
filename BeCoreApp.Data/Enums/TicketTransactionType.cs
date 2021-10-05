using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum TicketTransactionType
    {
        [Description("Withdraw Lock")]
        WithdrawLock = 1,
        [Description("Withdraw Invest")]
        WithdrawInvest = 2,
        [Description("Withdraw BNB BEP20")]
        WithdrawBNBBEP20 = 3,
        [Description("Withdraw BNB Affiliate")]
        WithdrawBNBAffiliate = 4,
        [Description("Withdraw TT-SWAP Commission")]
        WithdrawTTSCommission = 5,
        [Description("Withdraw TT-SWAP Affiliate")]
        WithdrawTTSAffiliate = 6
    }
}
