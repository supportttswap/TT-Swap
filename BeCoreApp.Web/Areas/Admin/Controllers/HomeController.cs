using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Data.Entities;
using BeCoreApp.Data.Enums;
using BeCoreApp.Extensions;
using BeCoreApp.Models;
using BeCoreApp.Utilities.Constants;
using BeCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BeCoreApp.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IChartRoundService _chartRoundService;
        private readonly INotifyService _notifyService;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(
            IChartRoundService chartRoundService,
            UserManager<AppUser> userManager,
            INotifyService notifyService
            )
        {
            _chartRoundService = chartRoundService;
            _userManager = userManager;
            _notifyService = notifyService;
        }

        public IActionResult Index()
        {
            var roleName = User.GetSpecificClaim("RoleName");
            if (roleName.ToLower() == "admin")
                return Redirect("/admin/report/index");

            var model = new HomeViewModel();
            model.Notify = _notifyService.GetDashboard();
            model.ChartRounds = _chartRoundService.GetAll();
            return View(model);
        }
    }
}