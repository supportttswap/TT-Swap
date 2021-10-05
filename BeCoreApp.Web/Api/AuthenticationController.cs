using BeCoreApp.Application.Implementation;
using BeCoreApp.Application.Interfaces;
using BeCoreApp.Data.Entities;
using BeCoreApp.Utilities.Dtos;
using BeCoreApp.Utilities.Extensions;
using BeCoreApp.Web.Models.RequestParams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BeCoreApp.Web.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("[Controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _srv;
        private readonly UserManager<AppUser> _userManager;
        //private readonly BotTelegramService _telegramBotSrv;

        public AuthenticationController(
            IAuthenticationService srv,
            UserManager<AppUser> userManager
            //BotTelegramService telegramBotSrv
            )
        {
            _srv = srv;
            _userManager = userManager;
            //_telegramBotSrv = telegramBotSrv;
        }

        [HttpPost("VerifyAuthenticatorCode/{verifyCode}")]
        public async Task<IActionResult> VerifyAuthenticatorCode([FromBody] string password,string verifyCode)
        {
            try
            {
                if(password.IsMissing() || verifyCode.IsMissing())
                {
                    return BadRequest(new GenericResult(false, "Please enter password and authenticator code"));
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var appUser = await _userManager.FindByIdAsync(userId);

                var isMatch = await _userManager.CheckPasswordAsync(appUser, password);

                if (!isMatch) return BadRequest(new GenericResult(false, "Wrong password"));

                var reuslt = await _userManager.VerifyTwoFactorTokenAsync(appUser, TokenOptions.DefaultAuthenticatorProvider, verifyCode);

                if (reuslt) return Ok(new GenericResult(true, "Valid Code"));

                return BadRequest(new GenericResult(false, "InValid Code"));
            }
            catch (Exception e)
            {
                return BadRequest(new GenericResult(false, "Something went wrong!!"));
            }
        }

        [HttpGet("EnableAuthentication/{verifyCode}")]
        public async Task<IActionResult> EnableAuthentication(string verifyCode)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appUser = await _userManager.FindByIdAsync(userId);

            var result = await _srv.VerifyTokenToEnableTwoFactorAsync(verifyCode, appUser, TokenOptions.DefaultAuthenticatorProvider);

            if (result.IsSuccess) return Ok(new GenericResult(true, "Successed to enable two-factor authentication"));

            return BadRequest("Code was invalid");
        }

        [HttpPost("Disable2FA")]
        public async Task<IActionResult> Disable2FA([FromBody] Disable2FAParams model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appUser = await _userManager.FindByIdAsync(userId);

            var result = await _srv.ConfirmPasswordToDisableTwoFactorAuthentication(model.Password, appUser);

            if (result) return Ok(new GenericResult(true, "Successed to disable 2FA"));

            return BadRequest("Failed to disable 2FA");
        }
    }
}
