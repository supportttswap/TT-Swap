#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Support\BlogDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdd753ea36e4f8a93980435548537d1a3df8f96d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Support_BlogDetail), @"mvc.1.0.view", @"/Areas/Admin/Views/Support/BlogDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Support/BlogDetail.cshtml", typeof(AspNetCore.Areas_Admin_Views_Support_BlogDetail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdd753ea36e4f8a93980435548537d1a3df8f96d", @"/Areas/Admin/Views/Support/BlogDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Support_BlogDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BeCoreApp.Application.ViewModels.Blog.BlogViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Support\BlogDetail.cshtml"
  
    ViewBag.Title = "News Detail";

#line default
#line hidden
            BeginContext(103, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(121, 143, true);
                WriteLiteral("\r\n    <style>\r\n        #box-mild-content p img {\r\n            max-width: 100%;\r\n            height: auto !important;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            DefineSection("Scripts", async() => {
                BeginContext(284, 8, true);
                WriteLiteral("\r\n    \r\n");
                EndContext();
            }
            );
            BeginContext(295, 401, true);
            WriteLiteral(@"
<div class=""content d-flex flex-column flex-column-fluid"" id=""kt_content"">
    <div class=""container"" id=""kt_content_container"">
        <div class=""card"">
            <div class=""card-body p-lg-17"">
                <div class=""mb-18"">
                    <div class=""mb-10"">
                        <div class=""text-center mb-15"">
                            <h3 class=""fs-1 text-dark mb-5"">");
            EndContext();
            BeginContext(697, 10, false);
#line 25 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Support\BlogDetail.cshtml"
                                                       Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(707, 106, true);
            WriteLiteral("</h3>\r\n                            <div class=\"fs-5 text-muted fw-bold\">\r\n                                ");
            EndContext();
            BeginContext(814, 17, false);
#line 27 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Support\BlogDetail.cshtml"
                           Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(831, 206, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"fs-6 fw-bold text-gray-600\" id=\"box-mild-content\">\r\n                        ");
            EndContext();
            BeginContext(1038, 27, false);
#line 32 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Support\BlogDetail.cshtml"
                   Write(Html.Raw(Model.MildContent));

#line default
#line hidden
            EndContext();
            BeginContext(1065, 108, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BeCoreApp.Application.ViewModels.Blog.BlogViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591