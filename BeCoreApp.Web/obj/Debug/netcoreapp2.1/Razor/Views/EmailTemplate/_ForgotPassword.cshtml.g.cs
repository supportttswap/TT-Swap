#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Views\EmailTemplate\_ForgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ede45b0a42f7a0b9b7e1b4073464cdf8903546a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EmailTemplate__ForgotPassword), @"mvc.1.0.view", @"/Views/EmailTemplate/_ForgotPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EmailTemplate/_ForgotPassword.cshtml", typeof(AspNetCore.Views_EmailTemplate__ForgotPassword))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ede45b0a42f7a0b9b7e1b4073464cdf8903546a3", @"/Views/EmailTemplate/_ForgotPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e9687c970b0a85b48325f199cadb19b9d1a74bb", @"/Views/_ViewImports.cshtml")]
    public class Views_EmailTemplate__ForgotPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Views\EmailTemplate\_ForgotPassword.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(42, 1630, true);
            WriteLiteral(@"
<style>
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
                            <strong>Hi!</strong>
                        </div>
                        <div style=""padding-bottom: 30px"">
                            You are receiving this email because we received a password reset request for your account. 
                            To proceed with the password reset please click on the button below:
                        </div>
                        <div style=""padding-bottom: 40px; text-align:center;"">
                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1672, "\"", 1685, 1);
#line 33 "D:\Projects\TTSwap\BeCoreApp.Web\Views\EmailTemplate\_ForgotPassword.cshtml"
WriteAttributeValue("", 1679, Model, 1679, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1686, 2027, true);
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
                            <a href=""https://twitter.com/TT_Swap"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/twitter.png"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a href=""https://www.reddit.com/r/TT_Swap/"" target=""_blank"" style=""text-decoration:none"">
                                <img src=""https://tt-swap.net/img-icon/reddit.png"" style=""height: 35px;margin-right:5px"">
                            </a>
                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3713, "\"", 3748, 3);
            WriteAttributeValue("", 3720, "https://medium.com/", 3720, 19, true);
            WriteAttributeValue("", 3739, "@", 3739, 1, true);
            WriteAttributeValue("", 3741, "tt-swap", 3741, 7, true);
            EndWriteAttribute();
            BeginContext(3749, 2129, true);
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
                        Copyright ©
                        <a href=""https://tt-swap.net"" rel=""noopener"" target=""_blank"">TT-SWAP</a>.
                    </p>
   ");
            WriteLiteral("             </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
