#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6b4f3a98bf71c588647ed540f35e040a965282a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6b4f3a98bf71c588647ed540f35e040a965282a", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b83049ebdbd3bb32eb4beb2922ec7798fbd0508", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/ecosystem/css/styles.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/ecosystem/js/jquery.1.9.1.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/ecosystem/js/prefixfree.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/ecosystem/js/scripts.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-app/controllers/home/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Dashboard";
    var seedRound = Model.ChartRounds.FirstOrDefault(x => x.Type == BeCoreApp.Data.Enums.ChartRoundType.SeedRound);
    var privateSale = Model.ChartRounds.FirstOrDefault(x => x.Type == BeCoreApp.Data.Enums.ChartRoundType.PrivateSale);
    var preSale = Model.ChartRounds.FirstOrDefault(x => x.Type == BeCoreApp.Data.Enums.ChartRoundType.PreSale);

#line default
#line hidden
            BeginContext(414, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(432, 152, true);
                WriteLiteral("\r\n    <style>\r\n        div#box-content p img {\r\n            width: 100% !important;\r\n            height: auto !important;\r\n        }\r\n    </style>\r\n    ");
                EndContext();
                BeginContext(584, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8e39ca0bc72743b18e146f4bb327dcc0", async() => {
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
                BeginContext(643, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(648, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(667, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(781, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(785, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0cdc7379405743e59bd159a9876bfbbd", async() => {
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
                BeginContext(839, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(845, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13b2b86a5564d1c9600b8865ed76066", async() => {
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
                BeginContext(901, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(907, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c47b528fb7847aab2626f102c4351ca", async() => {
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
                BeginContext(960, 103, true);
                WriteLiteral("\r\n\r\n    <script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script>\r\n\r\n    ");
                EndContext();
                BeginContext(1063, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb5b4df6e5db4690802f0683ed1b6167", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1124, 107, true);
                WriteLiteral("\r\n    <script>\r\n        var homeObj = new HomeController();\r\n        homeObj.initialize();\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(1234, 46, true);
            WriteLiteral("\r\n<input hidden id=\"SeedRoundDistributedToken\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1280, "\"", 1315, 1);
#line 34 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 1288, seedRound.DistributedToken, 1288, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1316, 38, true);
            WriteLiteral(" />\r\n<input hidden id=\"SeedRoundTotal\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1354, "\"", 1378, 1);
#line 35 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 1362, seedRound.Total, 1362, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1379, 53, true);
            WriteLiteral(" />\r\n\r\n<input hidden id=\"PrivateSaleDistributedToken\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1432, "\"", 1469, 1);
#line 37 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 1440, privateSale.DistributedToken, 1440, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1470, 40, true);
            WriteLiteral(" />\r\n<input hidden id=\"PrivateSaleTotal\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1510, "\"", 1536, 1);
#line 38 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 1518, privateSale.Total, 1518, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1537, 49, true);
            WriteLiteral(" />\r\n\r\n<input hidden id=\"PreSaleDistributedToken\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1586, "\"", 1619, 1);
#line 40 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 1594, preSale.DistributedToken, 1594, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1620, 36, true);
            WriteLiteral(" />\r\n<input hidden id=\"PreSaleTotal\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1656, "\"", 1678, 1);
#line 41 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
WriteAttributeValue("", 1664, preSale.Total, 1664, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1679, 307, true);
            WriteLiteral(@" />

<div class=""content d-flex flex-column flex-column-fluid"" id=""kt_content"">
    <div class=""container"" id=""kt_content_container"">
        <div class=""tradingview-widget-container"">
            <div class=""tradingview-widget-container__widget"" id=""ticker-tape"">
            </div>
        </div>
");
            EndContext();
            BeginContext(2461, 94, true);
            WriteLiteral("\r\n        <div class=\"card mb-5 mt-5 mb-xl-20\">\r\n            <div class=\"card-body p-lg-14\">\r\n");
            EndContext();
#line 63 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
                 if (Model.Notify != null)
                {

#line default
#line hidden
            BeginContext(2618, 112, true);
            WriteLiteral("                    <div class=\"text-center mt-3 mb-10\">\r\n                        <h3 class=\"fs-1 text-warning\">");
            EndContext();
            BeginContext(2731, 17, false);
#line 66 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
                                                 Write(Model.Notify.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2748, 35, true);
            WriteLiteral("</h3>\r\n                    </div>\r\n");
            EndContext();
            BeginContext(2785, 81, true);
            WriteLiteral("                    <div class=\"mt-7\" id=\"box-content\">\r\n                        ");
            EndContext();
            BeginContext(2867, 34, false);
#line 70 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
                   Write(Html.Raw(Model.Notify.MildContent));

#line default
#line hidden
            EndContext();
            BeginContext(2901, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 72 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2991, 152, true);
            WriteLiteral("                    <div class=\"text-center mt-5 mb-10\">\r\n                        <h3 class=\"fs-1 text-dark\">Updating</h3>\r\n                    </div>\r\n");
            EndContext();
#line 78 "D:\Projects\TTSwap\BeCoreApp.Web\Areas\Admin\Views\Home\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(3162, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(4902, 40, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n");
            EndContext();
            BeginContext(5032, 97, true);
            WriteLiteral("        <div id=\"divBody\" class=\"opening hide-UI view-2D zoom-large data-close controls-close\">\r\n");
            EndContext();
            BeginContext(5380, 29, true);
            WriteLiteral("            <div id=\"data\">\r\n");
            EndContext();
            BeginContext(5486, 607, true);
            WriteLiteral(@"                <a class=""mercury"" title=""AI"" href=""#ai"">AI</a>
                <a class=""venus"" title=""NFT"" href=""#nft"">NFT</a>
                <a class=""earth active"" title=""Game"" href=""#game"">Game</a>
                <a class=""mars"" title=""Swap"" href=""#swap"">Swap</a>
                <a class=""jupiter"" title=""Staking"" href=""#staking"">Staking</a>
                <a class=""saturn"" title=""Farming"" href=""#farming"">Farming</a>
                <a class=""uranus"" title=""DeFi"" href=""#defi"">DeFi</a>
                <a class=""neptune"" title=""Exchange"" href=""#exchange"">Exchange</a>
            </div>
");
            EndContext();
            BeginContext(6956, 4549, true);
            WriteLiteral(@"            <div id=""universe"" class=""scale-stretched"">
                <div id=""galaxy"">
                    <div id=""solar-system"" class=""earth"">
                        <div id=""mercury"" class=""orbit"">
                            <div class=""pos"">
                                <div class=""planet"">
                                    <dl class=""infos"">
                                        <dt>AI</dt>
                                        <dd><span>Ecosystem</span></dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div id=""venus"" class=""orbit"">
                            <div class=""pos"">
                                <div class=""planet"">
                                    <dl class=""infos"">
                                        <dt>NFT</dt>
                                        <dd><span>Ecosystem</span></dd>
                                    </dl>");
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <div id=""earth"" class=""orbit"">
                            <div class=""pos"">
                                <div class=""orbit"">
                                    <div class=""pos"">
                                        <div class=""moon""></div>
                                    </div>
                                </div>
                                <div class=""planet"">
                                    <dl class=""infos"">
                                        <dt>Game</dt>
                                        <dd>
                                            <span>Ecosystem</span>
                                        </dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div id=""mars"" class=""orbit"">
                     ");
            WriteLiteral(@"       <div class=""pos"">
                                <div class=""planet"">
                                    <dl class=""infos"">
                                        <dt>Swap</dt>
                                        <dd><span>Ecosystem</span></dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div id=""jupiter"" class=""orbit"">
                            <div class=""pos"">
                                <div class=""planet"">
                                    <dl class=""infos"">
                                        <dt>Staking</dt>
                                        <dd><span>Ecosystem</span></dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div id=""saturn"" class=""orbit"">
                            <div class=""pos"">
        ");
            WriteLiteral(@"                        <div class=""planet"">
                                    <div class=""ring""></div>
                                    <dl class=""infos"">
                                        <dt>Farming</dt>
                                        <dd><span>Ecosystem</span></dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div id=""uranus"" class=""orbit"">
                            <div class=""pos"">
                                <div class=""planet"">
                                    <dl class=""infos"">
                                        <dt>DeFi</dt>
                                        <dd><span>Ecosystem</span></dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div id=""neptune"" class=""orbit"">
                           ");
            WriteLiteral(@" <div class=""pos"">
                                <div class=""planet"">
                                    <dl class=""infos"">
                                        <dt>Exchange</dt>
                                        <dd><span>Ecosystem</span></dd>
                                    </dl>
                                </div>
                            </div>
                        </div>
                        <div id=""sun"">
");
            EndContext();
            BeginContext(11703, 142, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
