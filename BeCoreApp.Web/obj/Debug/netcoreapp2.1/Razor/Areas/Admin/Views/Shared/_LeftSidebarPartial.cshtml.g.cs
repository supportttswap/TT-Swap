#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Shared\_LeftSidebarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8829fbb57e8de7812b5cdbbb19193931f0a08d10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__LeftSidebarPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_LeftSidebarPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/_LeftSidebarPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared__LeftSidebarPartial))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp;

#line default
#line hidden
#line 3 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp.Models;

#line default
#line hidden
#line 4 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp.Models.AccountViewModels;

#line default
#line hidden
#line 5 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp.Models.ManageViewModels;

#line default
#line hidden
#line 6 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp.Application.ViewModels.System;

#line default
#line hidden
#line 7 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp.Application.ViewModels.BlockChain;

#line default
#line hidden
#line 8 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp.Application.ViewModels.Valuesshare;

#line default
#line hidden
#line 9 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\_ViewImports.cshtml"
using BeCoreApp.Data.Entities;

#line default
#line hidden
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Shared\_LeftSidebarPartial.cshtml"
using BeCoreApp.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8829fbb57e8de7812b5cdbbb19193931f0a08d10", @"/Areas/Admin/Views/Shared/_LeftSidebarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__LeftSidebarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Shared\_LeftSidebarPartial.cshtml"
  
    //string classActive = "";
    //string path = @Context.Request.Path;
    //string url = path.Substring(7);
    //int sbIndex = url.IndexOf("/");
    //string controllerName = url.ToLower();
    //if (sbIndex > 0)
    //    controllerName = controllerName.Substring(0, sbIndex);

#line default
#line hidden
            BeginContext(368, 300, true);
            WriteLiteral(@"
<div class=""app-sidebar__overlay"" data-toggle=""sidebar""></div>
<aside class=""app-sidebar toggle-sidebar"">
    <div class=""app-sidebar__user"">
        <div class=""user-info"">
            <a href=""#"" class="""">
                <span class=""app-sidebar__user-name font-weight-semibold text-green"">");
            EndContext();
            BeginContext(669, 33, false);
#line 18 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Shared\_LeftSidebarPartial.cshtml"
                                                                                Write(User.GetSpecificClaim("UserName"));

#line default
#line hidden
            EndContext();
            BeginContext(702, 63, true);
            WriteLiteral("</span><br>\r\n            </a>\r\n        </div>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(766, 38, false);
#line 22 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Shared\_LeftSidebarPartial.cshtml"
Write(await Component.InvokeAsync("SideBar"));

#line default
#line hidden
            EndContext();
            BeginContext(804, 12, true);
            WriteLiteral("\r\n</aside>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591