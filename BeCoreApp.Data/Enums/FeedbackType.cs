using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum FeedbackType
    {
        [Description("New")]
        New = 1,
        [Description("Watched")]
        Watched = 2,
        [Description("Responded")]
        Responded = 3
    }
}
