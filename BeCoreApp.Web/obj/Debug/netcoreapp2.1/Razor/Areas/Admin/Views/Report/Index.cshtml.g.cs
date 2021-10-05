#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0976cb925be63dbb1d74e1a04ab40e6d3ab8ca4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Report_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Report/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Report/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Report_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0976cb925be63dbb1d74e1a04ab40e6d3ab8ca4f", @"/Areas/Admin/Views/Report/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/admin-app/controllers/report/index.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/admin-app/controllers/report/index.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Report\Index.cshtml"
  
    ViewBag.Title = "Report";

    var isAdmin = User.IsInRole("Admin");

#line default
#line hidden
            DefineSection("Scripts", async() => {
                BeginContext(100, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(106, 89, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2fbd766fc8b40b683d490535aca8069", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 7 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Report\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(195, 113, true);
                WriteLiteral("\r\n    <script>\r\n        var reportObj = new ReportController();\r\n        reportObj.initialize();\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(311, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(329, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(335, 99, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "03978d0714f543a782f55bc14ae6aa9c", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#line 15 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Report\Index.cshtml"
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
                BeginContext(434, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(439, 1607, true);
            WriteLiteral(@"
<div class=""content d-flex flex-column flex-column-fluid"" id=""kt_content"">
    <div class=""container"" id=""kt_content_container"">
        <div class=""d-flex flex-wrap flex-stack pb-5"">
            <div class=""d-flex flex-wrap align-items-center my-1"">
                <div class=""d-flex align-items-center my-1"">
                    <input type=""text"" id=""FromDate"" class=""form-control form-control-white form-control-sm me-5"" placeholder=""From"">
                </div>
                <div class=""d-flex align-items-center my-1"">
                    <input type=""text"" id=""ToDate"" class=""form-control form-control-white form-control-sm me-5"" placeholder=""To"">
                </div>
                <a id=""btnSearch"" class=""btn btn-sm btn-icon btn-light btn-color-muted btn-active-success me-3"">
                    <span class=""svg-icon svg-icon-2 svg-icon-success"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none""><path d=""M21.7 18.9L18.");
            WriteLiteral(@"6 15.8C17.9 16.9 16.9 17.9 15.8 18.6L18.9 21.7C19.3 22.1 19.9 22.1 20.3 21.7L21.7 20.3C22.1 19.9 22.1 19.3 21.7 18.9Z"" fill=""black""></path><path opacity=""0.3"" d=""M11 20C6 20 2 16 2 11C2 6 6 2 11 2C16 2 20 6 20 11C20 16 16 20 11 20ZM11 4C7.1 4 4 7.1 4 11C4 14.9 7.1 18 11 18C14.9 18 18 14.9 18 11C18 7.1 14.9 4 11 4ZM8 11C8 9.3 9.3 8 11 8C11.6 8 12 7.6 12 7C12 6.4 11.6 6 11 6C8.2 6 6 8.2 6 11C6 11.6 6.4 12 7 12C7.6 12 8 11.6 8 11Z"" fill=""black""></path></svg>
                    </span>
                </a>
            </div>
        </div>
        <div class=""card mb-8"">

");
            EndContext();
            BeginContext(2726, 17827, true);
            WriteLiteral(@"
            <div class=""card-header border-0 pt-5"">
                <h3 class=""card-title align-items-start flex-column"">
                    <span class=""card-label fw-bolder fs-5 mb-1"">Members Statistics</span>
                </h3>
            </div>
            <div class=""card-body pt-1 pb-0"">
                <div class=""d-flex flex-wrap flex-sm-nowrap"">
                    <div class=""flex-grow-1"">
                        <div class=""d-flex flex-wrap justify-content-start"">
                            <div class=""d-flex flex-wrap"">
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-primary me-2"">
                                            <i class=""fa fa-users text-primary""></i>
                                        </span>
                                  ");
            WriteLiteral(@"      <div class=""fs-6 fw-bolder TotalMember"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Member</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-primary me-2"">
                                            <i class=""fa fa-users text-warning""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TodayMember"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Today Member</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed round");
            WriteLiteral(@"ed min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-success me-2"">
                                            <i class=""fa fa-users text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalMemberVerifyEmail"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Member Active</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-users text-danger""></i>
            ");
            WriteLiteral(@"                            </span>
                                        <div class=""fs-6 fw-bolder TotalMemberInVerifyEmail"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Member InActive</div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""card-header border-0 pt-5"">
                <h3 class=""card-title align-items-start flex-column"">
                    <span class=""card-label fw-bolder fs-5 mb-1"">Wallet BNB BEP20 Statistics</span>
                </h3>
            </div>
            <div class=""card-body pt-1 pb-0"">
                <div class=""d-flex flex-wrap flex-sm-nowrap"">
                    <div class=""flex-grow-1"">
                        <div class=""d-flex flex-wrap justify-content-start"">
                            <div class=""d-flex flex-wra");
            WriteLiteral(@"p"">
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-primary me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalBNBBEP20Deposit"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Deposit</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-success me-2"">
      ");
            WriteLiteral(@"                                      <i class=""fa fa-wallet text-danger""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalBNBBEP20Withdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Withdraw</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TodayBNBBEP20Deposit"">0</div>
                                    </div>
                                    <d");
            WriteLiteral(@"iv class=""fw-bold fs-6 text-gray-400"">Today Deposit</div>
                                </div>

                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-danger""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TodayBNBBEP20Withdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Today Withdraw</div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""card-header border-0 pt-5"">
            ");
            WriteLiteral(@"    <h3 class=""card-title align-items-start flex-column"">
                    <span class=""card-label fw-bolder fs-5 mb-1"">Wallet BNB Affiliate Statistics</span>
                </h3>
            </div>
            <div class=""card-body pt-1 pb-0"">
                <div class=""d-flex flex-wrap flex-sm-nowrap"">
                    <div class=""flex-grow-1"">
                        <div class=""d-flex flex-wrap justify-content-start"">
                            <div class=""d-flex flex-wrap"">
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-primary me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalBNBAffiliateDep");
            WriteLiteral(@"osit"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Deposit</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-success me-2"">
                                            <i class=""fa fa-wallet text-danger""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalBNBAffiliateWithdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Withdraw</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-");
            WriteLiteral(@"4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TodayBNBAffiliateDeposit"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Today Deposit</div>
                                </div>

                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-danger""></i>
                              ");
            WriteLiteral(@"          </span>
                                        <div class=""fs-6 fw-bolder TodayBNBAffiliateWithdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Today Withdraw</div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class=""card-header border-0 pt-5"">
                <h3 class=""card-title align-items-start flex-column"">
                    <span class=""card-label fw-bolder fs-5 mb-1"">Wallet Invest Statistics</span>
                </h3>
            </div>
            <div class=""card-body pt-1 pb-0"">
                <div class=""d-flex flex-wrap flex-sm-nowrap"">
                    <div class=""flex-grow-1"">
                        <div class=""d-flex flex-wrap justify-content-start"">
                            <div class=""d-flex flex-wrap"">
              ");
            WriteLiteral(@"                  <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-primary me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalInvestDeposit"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Deposit</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-success me-2"">
                           ");
            WriteLiteral(@"                 <i class=""fa fa-wallet text-danger""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalInvestWithdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Withdraw</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TodayInvestDeposit"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 te");
            WriteLiteral(@"xt-gray-400"">Today Deposit</div>
                                </div>

                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-danger""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TodayInvestWithdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Today Withdraw</div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""card-header border-0 pt-5"">
                <h3 class=""card-title a");
            WriteLiteral(@"lign-items-start flex-column"">
                    <span class=""card-label fw-bolder fs-5 mb-1"">Wallet Lock Statistics</span>
                </h3>
            </div>
            <div class=""card-body pt-1 pb-0"">
                <div class=""d-flex flex-wrap flex-sm-nowrap pb-6"">
                    <div class=""flex-grow-1"">
                        <div class=""d-flex flex-wrap justify-content-start"">
                            <div class=""d-flex flex-wrap"">
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-primary me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalLockDeposit"">0</div>
                        ");
            WriteLiteral(@"            </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Deposit</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-success me-2"">
                                            <i class=""fa fa-wallet text-danger""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TotalLockWithdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Total Withdraw</div>
                                </div>
                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                ");
            WriteLiteral(@"    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-success""></i>
                                        </span>
                                        <div class=""fs-6 fw-bolder TodayLockDeposit"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Today Deposit</div>
                                </div>

                                <div class=""border border-gray-300 border-dashed rounded min-w-125px py-3 px-4 me-3 mb-3"">
                                    <div class=""d-flex align-items-center"">
                                        <span class=""svg-icon svg-icon-3 svg-icon-danger me-2"">
                                            <i class=""fa fa-wallet text-danger""></i>
                                        </span>
                                    ");
            WriteLiteral(@"    <div class=""fs-6 fw-bolder TodayLockWithdraw"">0</div>
                                    </div>
                                    <div class=""fw-bold fs-6 text-gray-400"">Today Withdraw</div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
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