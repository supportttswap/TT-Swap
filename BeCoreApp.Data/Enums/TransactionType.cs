using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum TransactionType
    {
        [Description("Airdrop")]
        Airdrop = 0,
        [Description("Buy TT-SWAP")]
        BuyTTS = 1,
        [Description("Sell TT-SWAP")]
        SellTTS = 2,
        [Description("Affiliate Buy TT-SWAP")]
        AffiliateBuyTTS = 3,
        [Description("Pay Private Sale")]
        PayPrivateSale = 4,
    }
}
