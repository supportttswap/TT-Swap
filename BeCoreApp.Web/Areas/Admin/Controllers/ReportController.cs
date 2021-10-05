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
using BeCoreApp.Application.ViewModels.Report;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace BeCoreApp.Areas.Admin.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        public ReportController(
            IReportService reportService,
            UserManager<AppUser> userManager,
            IUserService userService
            )
        {
            _reportService = reportService;
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() != "admin")
                return Redirect("/login");

            return View();
        }

        [HttpGet]
        public IActionResult GetReportInfo(string fromDate, string toDate)
        {
            var model = _reportService.GetReportInfo(fromDate, toDate);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(int refIndex, string keyword, int page, int pageSize)
        {
            var userId = User.GetSpecificClaim("UserId");
            var model = _userService.GetCustomerReferralPagingAsync(userId, refIndex, keyword, page, pageSize);
            return new OkObjectResult(model);
        }
    }
}