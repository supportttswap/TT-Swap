#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Notify\_AddEditModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d951fb2b8c2c5c08b80827c370219eb5373a0afe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Notify__AddEditModal), @"mvc.1.0.view", @"/Areas/Admin/Views/Notify/_AddEditModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Notify/_AddEditModal.cshtml", typeof(AspNetCore.Areas_Admin_Views_Notify__AddEditModal))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d951fb2b8c2c5c08b80827c370219eb5373a0afe", @"/Areas/Admin/Views/Notify/_AddEditModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Notify__AddEditModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmMaintainance"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 739, true);
            WriteLiteral(@"<div id=""modal-add-edit"" class=""modal fade"" tabindex=""-1"" data-backdrop=""static""  aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title badge badge-secondary-light"" id=""exampleModalLabel"">
                    Th??m & c???p nh???t b??i vi???t
                </h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">
                        &times;
                    </span>
                </button>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(739, 5490, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a5ae5ee399a4565b1825e451e9b8a1c", async() => {
                BeginContext(766, 781, true);
                WriteLiteral(@"

                    <div class=""form-group"">
                        <input type=""hidden"" id=""hidId"" value=""0"" />
                        <label for=""txtName"" class=""form-control-label""> T??n B??i Vi???t</label>
                        <input type=""text"" id=""txtName"" class=""form-control"">
                    </div>

                    <div class=""form-group"">
                        <label for=""ddlBlogCategoryId"" class=""form-control-label"">Lo???i B??i Vi???t</label>
                        <input id=""ddlBlogCategoryId"" class=""form-control"" name=""ddlBlogCategoryId"" value="""">
                    </div>

                    <div class=""form-group"">
                        <label for=""txtName"" class=""form-control-label"">Ch??? ????? (Tags)</label>
                        ");
                EndContext();
                BeginContext(1548, 105, false);
#line 30 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Notify\_AddEditModal.cshtml"
                   Write(Html.DropDownList("Tags", null, new { id = "ddlTags", multiple = true, @class = "form-control select2" }));

#line default
#line hidden
                EndContext();
                BeginContext(1653, 4569, true);
                WriteLiteral(@"
                    </div>

                    <div class=""form-group"">
                        <label for=""txtImage"" class=""form-control-label""> ???nh b??a</label>
                        <div class=""input-group"">
                            <input type=""text"" id=""txtImage"" class=""form-control"" />
                            <input type=""file"" id=""fileInputImage"" style=""display:none"" />
                            <span class=""input-group-btn"">
                                <input type=""button"" id=""btnSelectImg"" class=""btn btn-default"" value=""Browser"" />
                            </span>
                        </div>
                    </div>

                    <div class=""form-group"">
                        <label for=""txtDescription"" class=""form-control-label""> T??m t???t</label>
                        <textarea id=""txtDescription"" rows=""4"" class=""form-control""></textarea>
                    </div>

                    <div class=""form-group"">
                        <label for=""");
                WriteLiteral(@"txtName"" class=""form-control-label"">Link Gi???i Thi???u</label>
                        <input type=""text"" id=""txtReferralLink"" class=""form-control"">
                    </div>

                    <div class=""form-group"">
                        <label for=""txtName"" class=""form-control-label"">Link Quy T???t</label>
                        <input type=""text"" id=""txtReferralLinkRule"" class=""form-control"">
                    </div>

                    <div class=""form-group"">
                        <label for=""txtVideo"" class=""form-control-label""> Video</label>
                        <textarea id=""txtVideo"" rows=""2"" class=""form-control""></textarea>
                    </div>

                    <div class=""form-group"">
                        <label for=""txtComment"" class=""form-control-label""> Comment</label>
                        <textarea id=""txtComment"" rows=""2"" class=""form-control""></textarea>
                    </div>

                    <div class=""form-group"">
                     ");
                WriteLiteral(@"   <label for=""txtShare"" class=""form-control-label""> Share</label>
                        <textarea id=""txtShare"" rows=""2"" class=""form-control""></textarea>
                    </div>

                    <div class=""form-group"">
                        <label for=""txtLike"" class=""form-control-label""> Like</label>
                        <textarea id=""txtLike"" rows=""2"" class=""form-control""></textarea>
                    </div>

                    <div class=""form-group"">
                        <label for=""txtContent"" class=""form-control-label""> T???ng quan</label>
                        <textarea id=""txtContent"" rows=""20"" class=""form-control""></textarea>
                    </div>

                    <div class=""form-group"">
                        <label for=""txtSeoPageTitle"" class=""form-control-label""> Seo Page Title</label>
                        <input type=""text"" id=""txtSeoPageTitle"" class=""form-control"">
                    </div>

                    <div class=""form-group"">
   ");
                WriteLiteral(@"                     <label for=""txtSeoKeywords"" class=""form-control-label""> Seo Keywords</label>
                        <input type=""text"" id=""txtSeoKeywords"" class=""form-control"">
                    </div>

                    <div class=""form-group"">
                        <label for=""txtSeoDescription"" class=""form-control-label""> Seo Description</label>
                        <input type=""text"" id=""txtSeoDescription"" class=""form-control"">
                    </div>

                    <div class=""form-group"">
                        <label class=""custom-control custom-checkbox"">
                            <input type=""checkbox"" class=""custom-control-input"" checked=""checked"" id=""ckStatus"">
                            <span class=""custom-control-label"">Tr???ng th??i</span>
                        </label>

                        <label class=""custom-control custom-checkbox"">
                            <input type=""checkbox"" class=""custom-control-input"" checked=""checked"" id=""ckHot"">
   ");
                WriteLiteral(@"                         <span class=""custom-control-label"">B??i vi???t hot</span>
                        </label>

                        <label class=""custom-control custom-checkbox"">
                            <input type=""checkbox"" class=""custom-control-input"" checked=""checked"" id=""ckShowHome"">
                            <span class=""custom-control-label"">Hi???n th??? trang ch???</span>
                        </label>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6229, 319, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" id=""btnCancel"" class=""btn btn-secondary"" data-dismiss=""modal"">H???y</button>
                <button type=""button"" id=""btnSave"" class=""btn btn-success"">L??u</button>
            </div>
        </div>
    </div>
</div>");
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
