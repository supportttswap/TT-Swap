#pragma checksum "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52398f396c809e87f6aaf65b48a82c1b990a8f76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_BlogCategory), @"mvc.1.0.view", @"/Views/Blog/BlogCategory.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Blog/BlogCategory.cshtml", typeof(AspNetCore.Views_Blog_BlogCategory))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52398f396c809e87f6aaf65b48a82c1b990a8f76", @"/Views/Blog/BlogCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e9687c970b0a85b48325f199cadb19b9d1a74bb", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_BlogCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BeCoreApp.Models.BlogViewModels.CatalogViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
  
    Layout = "_LayoutBlog";
    //ViewData["Title"] = Model.Data.CurrentPage == 1 ? Model.BlogCategory.Name : Model.BlogCategory.Name + " - Page " + Model.Data.CurrentPage;
    //ViewData["MetaKeyword"] = Model.Data.CurrentPage == 1 ? Model.BlogCategory.SeoKeywords : Model.BlogCategory.SeoKeywords + " - Page " + Model.Data.CurrentPage;
    //ViewData["MetaDescription"] = Model.Data.CurrentPage == 1 ? Model.BlogCategory.SeoDescription : Model.BlogCategory.SeoDescription + " - Page " + Model.Data.CurrentPage;

#line default
#line hidden
            DefineSection("Styles", async() => {
                BeginContext(597, 855, true);
                WriteLiteral(@"
    <style>
        img {
            max-width: 100%;
        }

        .news {
            padding-top: 130px;
            padding-bottom: 130px;
        }

        a.new {
            background-color: #151414;
            display: block;
            color: #51475a;
            margin: 20px 0 35px;
        }
        .news-carousel__item-body {
            padding: 20px 20px 20px 20px;
        }

        .news-carousel__item-body > p {
            line-height: 30px;
            margin-bottom: 20px;
            color: #aab2cd;
            overflow: hidden;
            display: -webkit-box;
            text-overflow: ellipsis;
            -webkit-box-orient: vertical;
            -webkit-line-clamp: 3;
            height: 90px;
            width: 100%;
            position: relative;
        }
    </style>
");
                EndContext();
            }
            );
            DefineSection("Scripts", async() => {
                BeginContext(1472, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(1479, 376, true);
            WriteLiteral(@"
<section class=""news"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col"">
                <div class=""section-header section-header--animated section-header--center section-header--medium-margin"">
                    <h2>New events</h2>
                </div>
            </div>
        </div>
        <div class=""row news__list"">
");
            EndContext();
#line 58 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
             foreach (var item in Model.Data.Results)
            {
                var url = $"{item.SeoAlias}-b.{item.Id}.html";

#line default
#line hidden
            BeginContext(1989, 78, true);
            WriteLiteral("                <div class=\"col-lg-4 col-md-6 col-12\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2067, "\"", 2078, 1);
#line 62 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
WriteAttributeValue("", 2074, url, 2074, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2079, 127, true);
            WriteLiteral(" class=\"news-carousel__item\">\r\n                        <div class=\"news-carousel__item-body\">\r\n                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2206, "\"", 2223, 1);
#line 64 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
WriteAttributeValue("", 2212, item.Image, 2212, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2224, 107, true);
            WriteLiteral(" />\r\n\r\n                            <h3 class=\"news-carousel__item-title\">\r\n                                ");
            EndContext();
            BeginContext(2332, 9, false);
#line 67 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
                           Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2341, 102, true);
            WriteLiteral("\r\n                            </h3>\r\n                            <p>\r\n                                ");
            EndContext();
            BeginContext(2444, 16, false);
#line 70 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
                           Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(2460, 136, true);
            WriteLiteral("\r\n                            </p>\r\n                            <div class=\"news-carousel__item-data\">\r\n                                ");
            EndContext();
            BeginContext(2597, 40, false);
#line 73 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
                           Write(item.DateModified.ToString("MM-dd-yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(2637, 120, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </a>\r\n                </div>\r\n");
            EndContext();
#line 78 "D:\Projects\TTSwap\BeCoreApp.Web\Views\Blog\BlogCategory.cshtml"
            }

#line default
#line hidden
            BeginContext(2772, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2923, 40, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BeCoreApp.Models.BlogViewModels.CatalogViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591