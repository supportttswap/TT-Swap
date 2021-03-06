#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Views\EmailTemplate\_VerifyAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb8b23a866423e76fe55b353635853473f980d14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmailTemplate__VerifyAccount), @"mvc.1.0.view", @"/Views/EmailTemplate/_VerifyAccount.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EmailTemplate/_VerifyAccount.cshtml", typeof(AspNetCore.Views_EmailTemplate__VerifyAccount))]
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
#line 1 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using BeCoreApp.Extensions;

#line default
#line hidden
#line 3 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using BeCoreApp.Models;

#line default
#line hidden
#line 4 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using BeCoreApp.Application.ViewModels.Product;

#line default
#line hidden
#line 5 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using BeCoreApp.Application.ViewModels.Blog;

#line default
#line hidden
#line 6 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using BeCoreApp.Models.AccountViewModels;

#line default
#line hidden
#line 7 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using BeCoreApp.Models.ManageViewModels;

#line default
#line hidden
#line 8 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using BeCoreApp.Data.Entities;

#line default
#line hidden
#line 9 "D:\Projects\TTSwap\BeCoreApp.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb8b23a866423e76fe55b353635853473f980d14", @"/Views/EmailTemplate/_VerifyAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e9687c970b0a85b48325f199cadb19b9d1a74bb", @"/Views/_ViewImports.cshtml")]
    public class Views_EmailTemplate__VerifyAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Views\EmailTemplate\_VerifyAccount.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(42, 1631, true);
            WriteLiteral(@"<style>
    html, body {
        padding: 0;
        margin: 0;
    }
</style>

<div style=""font-family:Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7"">
    <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""border-collapse:collapse;margin:0 auto; padding:0; max-width:600px"">
        <tbody>
            <tr>
                <td align=""center"" valign=""center"" style=""text-align:center; padding: 40px"">
                    <a href=""https://tt-swap.net"" rel=""noopener"" target=""_blank"">
                        <img src=""https://tt-swap.net/client-side/icd/img/ICDlogo3.png"" style=""height: 65px"" alt=""logo"">
                    </a>
                </td>
            </tr>
            <tr>
                <td align=""left"" valign=""center"">
                    <div style=""text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff");
            WriteLiteral(@"; border-radius: 6px"">
                        <div style=""padding-bottom: 30px; font-size: 17px;"">
                            <strong>Welcome to TT-SWAP!</strong>
                        </div>
                        <div style=""padding-bottom: 30px"">
                            To activate your account, please click on the button below to verify your email address.
                            Once activated, you???ll have full access to our  function:
                        </div>
                        <div style=""padding-bottom: 40px; text-align:center;"">
                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1673, "\"", 1686, 1);
#line 33 "D:\Projects\TTSwap\BeCoreApp.Web\Views\EmailTemplate\_VerifyAccount.cshtml"
WriteAttributeValue("", 1680, Model, 1680, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1687, 2034, true);
            WriteLiteral(@" rel=""noopener"" style=""text-decoration:none;
                                                        display:inline-block;text-align:center;
                                                        padding:0.75575rem 1.3rem;font-size:0.925rem;
                                                        line-height:1.5;border-radius:0.35rem;
                                                        color:#ffffff;background-color:#04C8C8;
                                                        border:0px;margin-right:0.75rem!important;
                                                        font-weight:600!important;outline:none!important;
                                                        vertical-align:middle"" target=""_blank"">
                                Confirm Email
                            </a>
                        </div>
                        <div style=""border-bottom: 1px solid #eeeeee; margin: 15px 0""></div>
                        <div style=""padding: 20px; word-wrap: break-all;ma");
            WriteLiteral(@"rgin-bottom: 20px;background: #f5f5f5;border-radius: 10px;"">
                            <p style=""margin-bottom: 10px;"">Stay connected:</p>

                            <a href=""https://www.facebook.com/tt-swap.net"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/facebook.png"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a href=""https://twitter.com/ic_defi"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/twitter.png"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a href=""https://www.reddit.com/r/TT-Swap_Crypto/"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/reddit.png"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3721, "\"", 3756, 3);
            WriteAttributeValue("", 3728, "https://medium.com/", 3728, 19, true);
            WriteAttributeValue("", 3747, "@", 3747, 1, true);
            WriteAttributeValue("", 3749, "tt-swap", 3749, 7, true);
            EndWriteAttribute();
            BeginContext(3757, 2100, true);
            WriteLiteral(@" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/medium.png"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a href=""https://t.me/joinchat/4CxzKmewFko0ODll"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/telegram.jpg"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a href=""https://t.me/tt-swap"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/telegram.jpg"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a href=""https://www.linkedin.com/company/tt-swap"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/linkedin.png"" style=""height: 35px;margin-right:5px"">
                    ");
            WriteLiteral(@"        </a>
                            <a href=""https://www.youtube.com/channel/UCHefl6x6Dc3hEiIRwPH-oXQ"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/youtube.png"" style=""height: 35px;margin-right:5px"">
                            </a>
                        </div>
                        <div style=""padding-bottom: 10px"">
                            Kind regards,
                            <br>The TT-SWAP Team.
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align=""center"" valign=""center"" style=""font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;"">
                    <p>27 Old Gloucester Street, London, United Kingdom, WC1N 3AX</p>
                    <p>
                        Copyright ?? <a href=""https://tt-swap.net"" rel=""noopener"" target=""_blank"">TT-SWAP</a>.
                    </p>
                </td>
     ");
            WriteLiteral("       </tr>\r\n        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
