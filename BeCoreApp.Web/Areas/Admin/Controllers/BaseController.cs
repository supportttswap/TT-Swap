using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BeCoreApp.Data.Entities;
using BeCoreApp.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BeCoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public virtual async Task<bool> VerifyCode(string authenticatorCode, UserManager<AppUser> userManager, AppUser appUser = null)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            appUser = appUser ?? await userManager.FindByIdAsync(userId);

            if (!appUser.TwoFactorEnabled) return true;

            return await userManager.VerifyTwoFactorTokenAsync(appUser, TokenOptions.DefaultAuthenticatorProvider, authenticatorCode);
        }
    }
}