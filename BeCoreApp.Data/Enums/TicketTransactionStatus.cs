using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum TicketTransactionStatus
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Rejected")]
        Rejected = 2,
        [Description("Approved")]
        Approved = 3,
    }
}
