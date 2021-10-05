using System;
using System.Collections.Generic;
using System.Text;

namespace BeCoreApp.Application.ViewModels.BlockChain
{
    public class WalletViewModel
    {
        public string AuthenticatorCode { get; set; }
        public bool Enabled2FA { get; set; }
        public string MainPrivateKey { get; set; }
        public string MainPublishKey { get; set; }
        public decimal MainBalance { get; set; }

        public decimal BNBAffiliateBalance { get; set; }

        public decimal InvestBalance { get; set; }

        public decimal LockBalance { get; set; }

        public decimal TTSCommissionBalance { get; set; }
        public decimal TTSAffiliateBalance { get; set; }

        public decimal StakingBalance { get; set; }
        public decimal StakingInterest { get; set; }
    }
}
