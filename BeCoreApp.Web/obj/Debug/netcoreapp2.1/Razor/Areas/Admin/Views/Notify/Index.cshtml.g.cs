#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Notify\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "906dce5e3b96f01af05afeb03b1376b9f6beb617"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Notify_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Notify/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Notify/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Notify_Index))]
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
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Notify\Index.cshtml"
using BeCoreApp.Data.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"906dce5e3b96f01af05afeb03b1376b9f6beb617", @"/Areas/Admin/Views/Notify/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Notify_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BeCoreApp.Application.ViewModels.System.NotifyViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/admin-app/controllers/notify/index.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-app/controllers/notify/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Notify\Index.cshtml"
  
    ViewBag.Title = "Notify";

#line default
#line hidden
            BeginContext(131, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(149, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(155, 99, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "834a129f648942899b58eb3a05beb762", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 8 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Notify\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(254, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(259, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(278, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(284, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f843301c7d86448189024cfa4a891448", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(347, 113, true);
                WriteLiteral("\r\n    <script>\r\n        var notifyObj = new NotifyController();\r\n        notifyObj.initialize();\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(463, 4035, true);
            WriteLiteral(@"
<div class=""content d-flex flex-column flex-column-fluid"" id=""kt_content"">
    <div class=""container"" id=""kt_content_container"">
        <div class=""d-flex flex-wrap flex-stack pb-7"">
            <div class=""d-flex flex-wrap align-items-center my-1"">
                <div class=""d-flex align-items-center position-relative my-1"">
                    <span class=""svg-icon svg-icon-3 position-absolute ms-3"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                <rect x=""0"" y=""0"" width=""24"" height=""24""></rect>
                                <path d=""M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.31");
            WriteLiteral(@"65825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3""></path>
                                <path d=""M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z"" fill=""#000000"" fill-rule=""nonzero""></path>
                            </g>
                        </svg>
                    </span>
                    <input type=""text"" id=""txt-search-keyword"" class=""form-control form-control-white form-control-sm w-150px ps-9"" placeholder=""Search"">
                </div>
            </div>
        </div>
        <div class=""card mb-5 mb-xl-10"">
            <div class=""card-header border-0 pt-5"">
                <div class=""card-toolbar"" data-bs-toggle=""tooltip"" d");
            WriteLiteral(@"ata-bs-placement=""top"" data-bs-trigger=""hover"">
                    <a href=""/admin/notify/addentity"" class=""btn btn-sm btn-success btn-active-success"">
                        <span class=""svg-icon svg-icon-3 svg-icon-success"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1""><g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd""><rect x=""0"" y=""0"" width=""24"" height=""24""></rect><path d=""M5,3 L6,3 C6.55228475,3 7,3.44771525 7,4 L7,20 C7,20.5522847 6.55228475,21 6,21 L5,21 C4.44771525,21 4,20.5522847 4,20 L4,4 C4,3.44771525 4.44771525,3 5,3 Z M10,3 L11,3 C11.5522847,3 12,3.44771525 12,4 L12,20 C12,20.5522847 11.5522847,21 11,21 L10,21 C9.44771525,21 9,20.5522847 9,20 L9,4 C9,3.44771525 9.44771525,3 10,3 Z"" fill=""#000000""></path><rect fill=""#000000"" opacity=""0.3"" transform=""translate(17.825568, 11.945519) rotate(-19.000000) translate(-17.825568, -11.945519)"" x=""16.3255682"" y=""2");
            WriteLiteral(@".94551858"" width=""3"" height=""18"" rx=""1""></rect></g></svg>
                        </span>
                        Create New
                    </a>
                </div>
            </div>
            <div class=""card-body py-3"">
                <div class=""table-responsive"">
                    <table class=""table table-row-dashed table-row-gray-300 align-middle gs-0 gy-4"">
                        <thead>
                            <tr class=""fw-bolder text-muted"">
                                <th class=""min-w-250px"">Title</th>
                                <th class=""min-w-70px"">Status</th>
                                <th class=""min-w-100px"">Create Date</th>
                                <th class=""min-w-90px"">Function</th>
                            </tr>
                        </thead>
                        <tbody id=""tbl-content""></tbody>
                    </table>
                </div>
                ");
            EndContext();
            BeginContext(4499, 37, false);
#line 62 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Notify\Index.cshtml"
           Write(await Component.InvokeAsync("Paging"));

#line default
#line hidden
            EndContext();
            BeginContext(4536, 3326, true);
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<script id=""table-template"" type=""x-tmpl-mustache"">
    <tr>
        <td>
            <div class=""d-flex align-items-center"">
                <div class=""d-flex justify-content-start flex-column"">
                    <a href=""#"" class=""text-dark fw-bolder text-hover-primary fs-6"">{{Name}}</a>
                </div>
            </div>
        </td>
        <td>
            <span class=""text-muted fw-bold text-muted d-block fs-7"">{{{Status}}}</span>
        </td>
        <td>
            <span class=""text-muted fw-bold text-muted d-block fs-7"">{{DateCreated}}</span>
        </td>
        <td>
            <a href=""/admin/notify/updateentity/{{Id}}"" class=""btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1"">
                <span class=""svg-icon svg-icon-3 svg-icon-warning"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                        <path");
            WriteLiteral(@" d=""M12.2674799,18.2323597 L12.0084872,5.45852451 C12.0004303,5.06114792 12.1504154,4.6768183 12.4255037,4.38993949 L15.0030167,1.70195304 L17.5910752,4.40093695 C17.8599071,4.6812911 18.0095067,5.05499603 18.0083938,5.44341307 L17.9718262,18.2062508 C17.9694575,19.0329966 17.2985816,19.701953 16.4718324,19.701953 L13.7671717,19.701953 C12.9505952,19.701953 12.2840328,19.0487684 12.2674799,18.2323597 Z"" fill=""#000000"" fill-rule=""nonzero"" transform=""translate(14.701953, 10.701953) rotate(-135.000000) translate(-14.701953, -10.701953)""></path>
                        <path d=""M12.9,2 C13.4522847,2 13.9,2.44771525 13.9,3 C13.9,3.55228475 13.4522847,4 12.9,4 L6,4 C4.8954305,4 4,4.8954305 4,6 L4,18 C4,19.1045695 4.8954305,20 6,20 L18,20 C19.1045695,20 20,19.1045695 20,18 L20,13 C20,12.4477153 20.4477153,12 21,12 C21.5522847,12 22,12.4477153 22,13 L22,18 C22,20.209139 20.209139,22 18,22 L6,22 C3.790861,22 2,20.209139 2,18 L2,6 C2,3.790861 3.790861,2 6,2 L12.9,2 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3""><");
            WriteLiteral(@"/path>
                    </svg>
                </span>
            </a>
            <a href=""#"" data-id=""{{Id}}"" class=""btn-delete btn btn-icon btn-bg-light btn-active-color-primary btn-sm"">
                <span class=""svg-icon svg-icon-3 svg-icon-danger"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                            <rect x=""0"" y=""0"" width=""24"" height=""24""></rect>
                            <path d=""M6,8 L6,20.5 C6,21.3284271 6.67157288,22 7.5,22 L16.5,22 C17.3284271,22 18,21.3284271 18,20.5 L18,8 L6,8 Z"" fill=""#000000"" fill-rule=""nonzero""></path>
                            <path d=""M14,4.5 L14,4 C14,3.44771525 13.5522847,3 13,3 L11,3 C10.4477153,3 10,3.44771525 10,4 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424");
            WriteLiteral(",6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z\" fill=\"#000000\" opacity=\"0.3\"></path>\r\n                        </g>\r\n                    </svg>\r\n                </span>\r\n            </a>\r\n        </td>\r\n    </tr>\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BeCoreApp.Application.ViewModels.System.NotifyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
