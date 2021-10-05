using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum ChartRoundType
    {
        [Description("Seed Round")]
        SeedRound = 1,
        [Description("Private Sale")]
        PrivateSale = 2,
        [Description("PreSale")]
        PreSale = 3
    }
}