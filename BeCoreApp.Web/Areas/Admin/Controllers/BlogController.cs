using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Blog;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Application.ViewModels.Product;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace BeCoreApp.Areas.Admin.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IBlogService _blogService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public BlogController(
            IBlogCategoryService blogCategoryService,
            IBlogService blogService,
            IHostingEnvironment hostingEnvironment)
        {
            _blogCategoryService = blogCategoryService;
            _blogService = blogService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            var tags = _blogService.GetListTagByType(CommonConstants.BlogTag);
            ViewBag.Tags = new SelectList(tags, "Id", "Name");
            return View();
        }

        public IActionResult AddEntity()
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            var tags = _blogService.GetListTagByType(CommonConstants.BlogTag);
            ViewBag.Tags = new SelectList(tags, "Id", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult GetAllBlogCategory()
        {
            var model = _blogCategoryService.GetTreeAll();
            return new ObjectResult(model);
        }

        #region AJAX API

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int blogCategoryId, int page, int pageSize)
        {
            var model = _blogService.GetAllPaging("", "", keyword, blogCategoryId, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult UpdateEntity(int id)
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            var model = _blogService.GetById(id);
            var tagIds = model.BlogTags.Select(x => x.TagId).ToArray();
            var tags = _blogService.GetListTagByType(CommonConstants.BlogTag);
            ViewBag.Tags = new SelectList(tags, "Id", "Name", tagIds);

            return View(model);
        }

        [HttpGet]
        public IActionResult GetBlogTags(int id)
        {
            var model = _blogService.GetById(id);
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(BlogViewModel blogVm)
        {
            try
            {
                var roleName = User.GetSpecificClaim("RoleName");
                if (roleName.ToLower() != "admin")
                    return Redirect("/logout");

                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.Values.SelectMany(v => v.Errors));
                else
                {
                    if (blogVm.Id == 0)
                        _blogService.Add(blogVm);
                    else
                        _blogService.Update(blogVm);

                    _blogService.Save();
                }

                return new OkObjectResult(new GenericResult(true));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(true, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);
            else
            {
                _blogService.Delete(id);
                _blogService.Save();
                return new OkObjectResult(id);
            }
        }
        #endregion
    }
}