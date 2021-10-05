using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Application.ViewModels.System;
using BeCoreApp.Application.ViewModels.Valuesshare;
using BeCoreApp.Data.Entities;
using BeCoreApp.Extensions;
using BeCoreApp.Models.AccountViewModels;
using BeCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nethereum.Util;
using Newtonsoft.Json;

namespace BeCoreApp.Areas.Admin.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AddressUtil _addressUtil = new AddressUtil();
        public ProfileController(
            UserManager<AppUser> userManager,
            IBlogService blogService,
            IUserService userService)
        {
            _blogService = blogService;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.GetSpecificClaim("UserId");
            var model = await _userService.GetById(userId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AppUserViewModel profileVm)
        {
            try
            {
                var userId = User.GetSpecificClaim("UserId");
                var appUser = await _userManager.FindByIdAsync(userId);
                if (appUser == null)
                    return new OkObjectResult(new GenericResult(false, "Account does not exist"));

                if (!string.IsNullOrWhiteSpace(appUser.BNBBEP20PublishKey))
                    return new OkObjectResult(new GenericResult(false, "BEP20 Address is exist"));

                if (!_addressUtil.IsChecksumAddress(profileVm.BNBBEP20PublishKey)
                                        || !_addressUtil.IsValidAddressLength(profileVm.BNBBEP20PublishKey))
                {
                    return new OkObjectResult(new GenericResult(false, "Address not in standard format BEP20."));
                }

                appUser.BNBBEP20PublishKey = profileVm.BNBBEP20PublishKey;

                var result = await _userManager.UpdateAsync(appUser);
                if (result.Succeeded)
                    return new OkObjectResult(new GenericResult(true, "Profile has been successfully updated"));
                else
                    return new OkObjectResult(new GenericResult(false, "Profile update failed"));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new GenericResult(false, ex.Message));
            }
        }
    }
}