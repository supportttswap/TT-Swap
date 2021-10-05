using BeCoreApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeCoreApp.Extensions;
using System.Security.Claims;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Application.ViewModels.System;

namespace BeCoreApp.Areas.Admin.Components
{
    public class LatestBlogViewComponent : ViewComponent
    {
        IBlogService _blogService;
        public LatestBlogViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = _blogService.GetLatestBlogs(4);
            return View(blogs);
        }
    }
}
