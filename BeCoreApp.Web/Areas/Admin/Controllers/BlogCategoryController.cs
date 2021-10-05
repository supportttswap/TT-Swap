using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.Blog;
using BeCoreApp.Application.ViewModels.Common;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeCoreApp.Areas.Admin.Controllers
{
    public class BlogCategoryController : BaseController
    {
        public IBlogCategoryService _blogCategoryService;
        public IFunctionService _functionService;

        public BlogCategoryController(IBlogCategoryService blogCategoryService,
            IFunctionService functionService)
        {
            _blogCategoryService = blogCategoryService;
            _functionService = functionService;
        }

        public IActionResult Index()
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            List<EnumModel> enums = ((MenuFrontEndType[])Enum.GetValues(typeof(MenuFrontEndType)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();

            ViewBag.Type = new SelectList(enums, "Value", "Name");

            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _blogCategoryService.GetTreeAll();
            return new ObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllFunction()
         => new ObjectResult(_functionService.GetTreeAll(Status.Active));

        [HttpPost]
        public IActionResult UpdateParentId(int id, int? parentId)
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            _blogCategoryService.UpdateParentId(id, parentId);
            _blogCategoryService.Save();
            return new ObjectResult(true);
        }

        public IActionResult AddEntity()
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            List<EnumModel> enums = ((MenuFrontEndType[])Enum.GetValues(typeof(MenuFrontEndType)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();

            ViewBag.Type = new SelectList(enums, "Value", "Name");

            return View();
        }

        [HttpGet]
        public IActionResult UpdateEntity(int id)
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/logout");

            var model = _blogCategoryService.GetById(id);
            List<EnumModel> enums = ((MenuFrontEndType[])Enum.GetValues(typeof(MenuFrontEndType)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();

            ViewBag.Type = new SelectList(enums, "Value", "Name", (int)model.Type);

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(BlogCategoryViewModel blogCategoryVm)
        {
            try
            {
                var roleName = User.GetSpecificClaim("RoleName");
                if (roleName.ToLower() != "admin")
                    return Redirect("/logout");

                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(ModelState.Values.SelectMany(v => v.Errors));

                if (blogCategoryVm.Id == 0)
                    _blogCategoryService.Add(blogCategoryVm);
                else
                {
                    _blogCategoryService.Update(blogCategoryVm);
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

            _blogCategoryService.Delete(id);
            _blogCategoryService.Save();

            return new OkObjectResult(id);
        }
    }
}