#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Shared\Components\SubHeader\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "156753c3b4925fae2115f93fa764226670769800"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_SubHeader_Default), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/SubHeader/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/Components/SubHeader/Default.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared_Components_SubHeader_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"156753c3b4925fae2115f93fa764226670769800", @"/Areas/Admin/Views/Shared/Components/SubHeader/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Components_SubHeader_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 714, true);
            WriteLiteral(@"<div class=""m-subheader "">
    <div class=""d-flex align-items-center"">
        <div class=""mr-auto"">
            <ul class=""m-subheader__breadcrumbs m-nav m-nav--inline"">
                <li class=""m-nav__item m-nav__item--home"">
                    <a href=""/Admin/Home/Index"" class=""m-nav__link m-nav__link--icon"">
                        <i class=""m-nav__link-icon la la-home""></i>
                    </a>
                </li>
                <li class=""m-nav__separator"">
                    -
                </li>
                <li class=""m-nav__item"">
                    <a href="""" class=""m-nav__link"">
                        <span class=""m-nav__link-text"">
                            ");
            EndContext();
            BeginContext(715, 17, false);
#line 16 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Shared\Components\SubHeader\Default.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(732, 86, true);
            WriteLiteral("\r\n                        </span>\r\n                    </a>\r\n                </li>\r\n\r\n");
            EndContext();
            BeginContext(1623, 35, true);
            WriteLiteral("            </ul>\r\n        </div>\r\n");
            EndContext();
            BeginContext(5745, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
