#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Views\Shared\_Layout - Copy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7435d081a5cbb8e21b31e1adc6d7410f28d9784d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout___Copy), @"mvc.1.0.view", @"/Views/Shared/_Layout - Copy.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Layout - Copy.cshtml", typeof(AspNetCore.Views_Shared__Layout___Copy))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7435d081a5cbb8e21b31e1adc6d7410f28d9784d", @"/Views/Shared/_Layout - Copy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e9687c970b0a85b48325f199cadb19b9d1a74bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout___Copy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-side/icd/img/ICDLogo1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-side/icd/css/fontawesome.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-side/icd/css/main.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-side/icd/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-side/icd/js/jquery-2.2.4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-side/icd/js/scripts.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-side/dashlot-admin/HTML/assets/plugins/sweet-alert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-side/dashlot-admin/HTML/assets/plugins/notify/js/rainbow.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin-side/dashlot-admin/HTML/assets/plugins/notify/js/jquery.growl.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-app/shared/be.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/client-app/controllers/feedback/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 37, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"ru\">\r\n\r\n");
            EndContext();
            BeginContext(37, 6476, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83be1a8354ba4655b4690ad4ab6fd1bd", async() => {
                BeginContext(43, 2015, true);
                WriteLiteral(@"
    <title>IC DeFi | ICD Token - Automatic Decentralized Financial Transactions</title>
    <meta name=""theme-color"" content=""#000"">

    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">

    <meta name=""title"" content=""IC DeFi | ICD Token - Automatic Decentralized Financial Transactions"">
    <meta name=""keywords"" content=""ICD Token, ICD Coin, IC DeFi"">
    <meta name=""description"" content=""ICD is an easy-to-use platform that allows investors to profit from the arbitrage of trading types based on data from the top 10 largest decentralized Exchanges."">

    <meta name=""robots"" content=""index, follow"">
    <meta http-equiv=""Content-Type"" charset=""utf-8"" content=""text/html; charset=utf-8"">
    <meta name=""language"" content=""English"">

    <!-- Open Graph / Facebook -->
    <meta property=""og:type"" content=""website"">
    <meta property=""og:url"" content=""https://icdefi.org/"">
    <meta property=""og:ti");
                WriteLiteral(@"tle"" content=""IC DeFi | ICD Token - Automatic Decentralized Financial Transactions"">
    <meta property=""og:description"" content=""ICD is an easy-to-use platform that allows investors to profit from the arbitrage of trading types based on data from the top 10 largest decentralized Exchanges."">
    <meta property=""og:image"" content=""https://icdefi.org/uploaded/images/20210803/icd-new1.jpg"">

    <!-- Twitter -->
    <meta property=""twitter:card"" content=""summary_large_image"">
    <meta property=""twitter:url"" content=""https://icdefi.org/"">
    <meta property=""twitter:title"" content=""IC DeFi | ICD Token - Automatic Decentralized Financial Transactions"">
    <meta property=""twitter:description"" content=""ICD is an easy-to-use platform that allows investors to profit from the arbitrage of trading types based on data from the top 10 largest decentralized Exchanges."">
    <meta property=""twitter:image"" content=""https://icdefi.org/uploaded/images/20210803/icd-new1.jpg"">

    ");
                EndContext();
                BeginContext(2058, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "883253fb5c0c4b94885be5e1bc42783c", async() => {
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
                BeginContext(2117, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(2125, 74, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "49e7c24da8ef45aba9e6537acd0b3bdd", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2199, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2205, 65, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0d9f4ca74a8447b59edd240bc381e7ca", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2270, 229, true);
                WriteLiteral("\r\n\r\n    <link href=\"/admin-side/dashlot-admin/HTML/assets/plugins/sweet-alert/sweetalert.css\" rel=\"stylesheet\">\r\n    <link href=\"/admin-side/dashlot-admin/HTML/assets/plugins/notify/css/jquery.growl.css\" rel=\"stylesheet\">\r\n\r\n    ");
                EndContext();
                BeginContext(2500, 40, false);
#line 41 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Shared\_Layout - Copy.cshtml"
Write(RenderSection("Styles", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(2540, 1543, true);
                WriteLiteral(@"

    <!-- Load google font
    ================================================== -->
    <script type=""text/javascript"">
        WebFontConfig = {
            google: { families: ['Catamaran:300,400,600,700', 'Raleway:100,700', 'Roboto:700,900'] }
        };
        (function () {
            var wf = document.createElement('script');
            wf.src = '/client-side/icd/js/webfont.js';
            wf.type = 'text/javascript';
            wf.async = 'true';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(wf, s);
        })();

    </script>

    <!-- Load other scripts
    ================================================== -->
    <script type=""text/javascript"">
        var _html = document.documentElement;
        _html.className = _html.className.replace(""no-js"", ""js"");
    </script>

    <!-- Google Tag Manager -->
    <script>
    (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({
                'g");
                WriteLiteral(@"tm.start':
                    new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
                j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
                    'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-K32TGHX');</script>
    <!-- End Google Tag Manager -->

    <script type=""application/ld+json"">
        {
        """);
                EndContext();
                BeginContext(4084, 44, true);
                WriteLiteral("@context\": \"https://schema.org/\",\r\n        \"");
                EndContext();
                BeginContext(4129, 187, true);
                WriteLiteral("@type\": \"Website\",\r\n        \"name\": \"IC DeFi | ICD Token - Automatic Decentralized Financial Transactions\",\r\n        \"url\": \"https://icdefi.org/\",\r\n        \"potentialAction\": {\r\n        \"");
                EndContext();
                BeginContext(4317, 255, true);
                WriteLiteral("@type\": \"SearchAction\",\r\n        \"target\": \"https://icdefi.org/search?q={search_term_string}\",\r\n        \"query-input\": \"required name=search_term_string\"\r\n        }\r\n        }\r\n    </script>\r\n\r\n    <script type=\"application/ld+json\">\r\n        {\r\n        \"");
                EndContext();
                BeginContext(4573, 43, true);
                WriteLiteral("@context\": \"https://schema.org\",\r\n        \"");
                EndContext();
                BeginContext(4617, 55, true);
                WriteLiteral("@type\": \"FAQPage\",\r\n        \"mainEntity\": [{\r\n        \"");
                EndContext();
                BeginContext(4673, 101, true);
                WriteLiteral("@type\": \"Question\",\r\n        \"name\": \"What is an ICD Token?\",\r\n        \"acceptedAnswer\": {\r\n        \"");
                EndContext();
                BeginContext(4775, 286, true);
                WriteLiteral(@"@type"": ""Answer"",
        ""text"": ""ICD Token – The powerful NFT platform coin is a top priority for the development of global artificial intelligence in decentralized financial trading operating on the Ethereum Blockchain network (BEP-20).
        ""
        }
        },{
        """);
                EndContext();
                BeginContext(5062, 108, true);
                WriteLiteral("@type\": \"Question\",\r\n        \"name\": \"How Does the ICD Token Work?\",\r\n        \"acceptedAnswer\": {\r\n        \"");
                EndContext();
                BeginContext(5171, 223, true);
                WriteLiteral("@type\": \"Answer\",\r\n        \"text\": \"NFT ICD Token ecosystem is relegating the underlying infrastructure of the NFT DeFi platform to advanced algorithms powered by advanced smart contracts\"\r\n        }\r\n        },{\r\n        \"");
                EndContext();
                BeginContext(5395, 102, true);
                WriteLiteral("@type\": \"Question\",\r\n        \"name\": \"What Is the IC AI Bot?\",\r\n        \"acceptedAnswer\": {\r\n        \"");
                EndContext();
                BeginContext(5498, 331, true);
                WriteLiteral(@"@type"": ""Answer"",
        ""text"": ""The IC AI Bot is a groundbreaking artificial intelligence system designed specifically with the goal of making traders maximally enhance and keep the profits of financial exchanges""
        }
        }]
        }
    </script>

    <script type=""application/ld+json"">
        {
        """);
                EndContext();
                BeginContext(5830, 43, true);
                WriteLiteral("@context\": \"https://schema.org\",\r\n        \"");
                EndContext();
                BeginContext(5874, 529, true);
                WriteLiteral(@"@type"": ""Project"",
        ""name"": ""The NFT ICD Token ecosystem"",
        ""alternateName"": ""ICD DeFi Token"",
        ""url"": ""https://icdefi.org/"",
        ""logo"": ""https://icdefi.org/client-side/icd/img/ICDlogo3.png"",
        ""sameAs"": [
        ""https://www.facebook.com/icdefi.org"",
        ""hhttps://twitter.com/ic_defi"",
        ""https://www.instagram.com/ic_defi/"",
        ""https://www.youtube.com/channel/UCHefl6x6Dc3hEiIRwPH-oXQ"",
        ""https://www.linkedin.com/company/icdefi"",
        ""https://medium.com/");
                EndContext();
                BeginContext(6404, 102, true);
                WriteLiteral("@icdefi\",\r\n        \"https://www.reddit.com/r/ICDeFi_Crypto/\",\r\n        ]\r\n        }\r\n    </script>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6513, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(6517, 1352, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58b76b0522024dec93de3ae37012abcb", async() => {
                BeginContext(6523, 384, true);
                WriteLiteral(@"

    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src=""https://www.googletagmanager.com/ns.html?id=GTM-K32TGHX""
                height=""0"" width=""0"" style=""display:none;visibility:hidden""></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->

    <div class=""preloader"" id=""preloader""></div>

    <div class=""wrapper"">
        ");
                EndContext();
                BeginContext(6908, 34, false);
#line 157 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Shared\_Layout - Copy.cshtml"
   Write(await Html.PartialAsync("_Header"));

#line default
#line hidden
                EndContext();
                BeginContext(6942, 12, true);
                WriteLiteral("\r\n\r\n        ");
                EndContext();
                BeginContext(6955, 12, false);
#line 159 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Shared\_Layout - Copy.cshtml"
   Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(6967, 12, true);
                WriteLiteral("\r\n\r\n        ");
                EndContext();
                BeginContext(6980, 34, false);
#line 161 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Shared\_Layout - Copy.cshtml"
   Write(await Html.PartialAsync("_Footer"));

#line default
#line hidden
                EndContext();
                BeginContext(7014, 20, true);
                WriteLiteral("\r\n    </div>\r\n\r\n    ");
                EndContext();
                BeginContext(7034, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18bb643d8e0246e0894053740aa4c33b", async() => {
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
                BeginContext(7092, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7098, 64, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d11c6fc70c524dc281f476e0ea7fc963", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7162, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7168, 59, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab873d1eaaa64beebab17575b5f2d75b", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7227, 39, true);
                WriteLiteral("\r\n\r\n    <!-- Notifications js -->\r\n    ");
                EndContext();
                BeginContext(7266, 100, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78fc8ad932a04804863341adbabffb15", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7366, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7372, 91, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2559e548b4ff4f46bb875c28e60be0d7", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7463, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(7469, 96, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "345236498dda4f5699fea9302b387e9a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7565, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(7573, 49, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52c2bf1c76644935be18dc7a3534dbbd", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7622, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(7630, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d2c84de744042dcb787e0c4b1e4c6b1", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7696, 122, true);
                WriteLiteral("\r\n    <script>\r\n        var feedbackObj = new FeedbackController;\r\n        feedbackObj.initialize()\r\n    </script>\r\n\r\n    ");
                EndContext();
                BeginContext(7819, 41, false);
#line 181 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Shared\_Layout - Copy.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
                EndContext();
                BeginContext(7860, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7869, 9, true);
            WriteLiteral("\r\n</html>");
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
