#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7314fd235ada55c039bccb9a4f03ef9f45b27cb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Blog_UpdateEntity), @"mvc.1.0.view", @"/Areas/Admin/Views/Blog/UpdateEntity.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Blog/UpdateEntity.cshtml", typeof(AspNetCore.Areas_Admin_Views_Blog_UpdateEntity))]
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
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
using BeCoreApp.Data.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7314fd235ada55c039bccb9a4f03ef9f45b27cb8", @"/Areas/Admin/Views/Blog/UpdateEntity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Blog_UpdateEntity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BeCoreApp.Application.ViewModels.Blog.BlogViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jQuery-EasyUI/themes/icon.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/admin-app/controllers/blog/index.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jQuery-EasyUI/jquery.easyui.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-app/controllers/blog/update.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
  
    ViewBag.Title = "Update Blog";

#line default
#line hidden
            BeginContext(132, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(150, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(242, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(246, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4736361db4074fb7ab16c9181e255442", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(314, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(320, 97, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1e6650bb3a3741eda80aebb3ee1ef7e0", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 10 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
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
                BeginContext(417, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(422, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(441, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(447, 64, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3a594aecb07544fea0942ec2e43cf689", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(511, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(517, 62, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "099b1428c14f4360a2c3a806b2be0036", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(579, 119, true);
                WriteLiteral("\r\n    <script>\r\n        var blogUpdate = new BlogUpdateController();\r\n        blogUpdate.initialize();\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(701, 233, true);
            WriteLiteral("\r\n<div class=\"content d-flex flex-column flex-column-fluid\" id=\"kt_content\">\r\n    <div class=\"container\" id=\"kt_content_container\">\r\n        <div class=\"card mb-5 mb-xl-10\">\r\n            <div class=\"card-body py-3\">\r\n                ");
            EndContext();
            BeginContext(934, 5280, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2238b6012b504c13866aeae23ead098b", async() => {
                BeginContext(953, 53, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" id=\"hidId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1006, "\"", 1023, 1);
#line 27 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
WriteAttributeValue("", 1014, Model.Id, 1014, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1024, 352, true);
                WriteLiteral(@" />

                    <div class=""d-flex flex-column mb-8 fv-row"">
                        <label class=""d-flex align-items-center fs-6 fw-bold mb-2"">
                            <span class=""required"">Title</span>
                        </label>
                        <input type=""text"" class=""form-control form-control-solid"" id=""txtName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1376, "\"", 1395, 1);
#line 33 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
WriteAttributeValue("", 1384, Model.Name, 1384, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1396, 307, true);
                WriteLiteral(@" />
                    </div>

                    <div class=""d-flex flex-column mb-8 fv-row"">
                        <label class=""d-flex align-items-center fs-6 fw-bold mb-2"">Category</label>
                        <input type=""text"" class=""form-control form-control-solid"" id=""ddlBlogCategoryId""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1703, "\"", 1732, 1);
#line 38 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
WriteAttributeValue("", 1711, Model.BlogCategoryId, 1711, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1733, 197, true);
                WriteLiteral("/>\r\n                    </div>\r\n\r\n                    <div class=\"d-flex flex-column mb-8\">\r\n                        <label class=\"required fs-6 fw-bold mb-2\">Tags</label>\r\n                        ");
                EndContext();
                BeginContext(1931, 113, false);
#line 43 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
                   Write(Html.DropDownList("Tags",null, new { id = "ddlTags", multiple = true, @class = "form-select form-select-solid" }));

#line default
#line hidden
                EndContext();
                BeginContext(2044, 355, true);
                WriteLiteral(@"
                    </div>

                    <div class=""d-flex flex-column mb-8"">
                        <label for=""txtImage"" class=""d-flex align-items-center fs-6 fw-bold mb-2"">Image</label>
                        <div class=""input-group"">
                            <input type=""text"" id=""txtImage"" class=""form-control form-control-solid""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2399, "\"", 2419, 1);
#line 49 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
WriteAttributeValue("", 2407, Model.Image, 2407, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2420, 610, true);
                WriteLiteral(@"/>
                            <input type=""file"" id=""fileInputImage"" style=""display:none"" />
                            <span class=""input-group-btn"">
                                <input type=""button"" id=""btnSelectImg"" class=""btn btn-success"" value=""Browser"" />
                            </span>
                        </div>
                    </div>

                    <div class=""d-flex flex-column mb-8"">
                        <label class=""fs-6 fw-bold mb-2"">Description</label>
                        <textarea class=""form-control form-control-solid"" id=""txtDescription"" rows=""3"">");
                EndContext();
                BeginContext(3031, 17, false);
#line 59 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
                                                                                                  Write(Model.Description);

#line default
#line hidden
                EndContext();
                BeginContext(3048, 275, true);
                WriteLiteral(@"</textarea>
                    </div>

                    <div class=""d-flex flex-column mb-8"">
                        <label class=""fs-6 fw-bold mb-2"">Content</label>
                        <textarea class=""form-control form-control-solid"" id=""txtContent"" rows=""3"">");
                EndContext();
                BeginContext(3324, 17, false);
#line 64 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
                                                                                              Write(Model.MildContent);

#line default
#line hidden
                EndContext();
                BeginContext(3341, 319, true);
                WriteLiteral(@"</textarea>
                    </div>

                    <div class=""d-flex flex-column mb-8 fv-row"">
                        <label class=""d-flex align-items-center fs-6 fw-bold mb-2"">Seo Page Title</label>
                        <input type=""text"" class=""form-control form-control-solid"" id=""txtSeoPageTitle""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3660, "\"", 3687, 1);
#line 69 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
WriteAttributeValue("", 3668, Model.SeoPageTitle, 3668, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3688, 306, true);
                WriteLiteral(@" />
                    </div>
                    <div class=""d-flex flex-column mb-8 fv-row"">
                        <label class=""d-flex align-items-center fs-6 fw-bold mb-2"">Seo Keywords</label>
                        <input type=""text"" class=""form-control form-control-solid"" id=""txtSeoKeywords""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3994, "\"", 4020, 1);
#line 73 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
WriteAttributeValue("", 4002, Model.SeoKeywords, 4002, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4021, 312, true);
                WriteLiteral(@" />
                    </div>
                    <div class=""d-flex flex-column mb-8 fv-row"">
                        <label class=""d-flex align-items-center fs-6 fw-bold mb-2"">Seo Description</label>
                        <input type=""text"" class=""form-control form-control-solid"" id=""txtSeoDescription""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4333, "\"", 4362, 1);
#line 77 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
WriteAttributeValue("", 4341, Model.SeoDescription, 4341, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4363, 403, true);
                WriteLiteral(@" />
                    </div>

                    <div class=""mb-15 fv-row"">
                        <div class=""d-flex flex-stack"">
                            <div class=""d-flex"">
                                <label class=""form-check form-check-custom form-check-solid me-10"">
                                    <input class=""form-check-input h-20px w-20px"" type=""checkbox"" id=""ckStatus"" ");
                EndContext();
                BeginContext(4768, 46, false);
#line 84 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
                                                                                                            Write(Model.Status == Status.Active ? "checked" : "");

#line default
#line hidden
                EndContext();
                BeginContext(4815, 347, true);
                WriteLiteral(@" />
                                    <span class=""form-check-label fw-bold"">Status</span>
                                </label>
                                <label class=""form-check form-check-custom form-check-solid me-10"">
                                    <input class=""form-check-input h-20px w-20px"" type=""checkbox"" id=""ckHot"" ");
                EndContext();
                BeginContext(5164, 38, false);
#line 88 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
                                                                                                         Write(Model.HotFlag == true ? "checked" : "");

#line default
#line hidden
                EndContext();
                BeginContext(5203, 349, true);
                WriteLiteral(@" />
                                    <span class=""form-check-label fw-bold"">Hot</span>
                                </label>
                                <label class=""form-check form-check-custom form-check-solid me-10"">
                                    <input class=""form-check-input h-20px w-20px"" type=""checkbox"" id=""ckShowHome"" ");
                EndContext();
                BeginContext(5554, 39, false);
#line 92 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Blog\UpdateEntity.cshtml"
                                                                                                              Write(Model.HomeFlag == true ? "checked" : "");

#line default
#line hidden
                EndContext();
                BeginContext(5594, 613, true);
                WriteLiteral(@" />
                                    <span class=""form-check-label fw-bold"">Show Home</span>
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class=""text-center"">
                        <a href=""/admin/blog/index"" class=""btn btn-light me-3"">Cancel</a>
                        <button type=""button"" id=""btnSave"" class=""btn btn-primary"">
                            <span class=""indicator-label"">Submit</span>
                        </button>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6214, 56, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
