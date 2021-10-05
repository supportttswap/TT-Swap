using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum KYCType
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Reject")]
        Reject = 2,
        [Description("Approval")]
        Approval = 3,
        [Description("Lock")]
        Lock = 4
    }
}
