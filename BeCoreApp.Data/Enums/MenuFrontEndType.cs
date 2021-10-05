using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeCoreApp.Data.Enums
{
    public enum MenuFrontEndType
    {
        [Description("None")]
        None = -1,
        [Description("Home")]
        Home = 1,
        [Description("Blog")]
        Blog = 2,
        [Description("Contact")]
        Contact = 3,
        [Description("Product")]
        Product = 4
    }
}
