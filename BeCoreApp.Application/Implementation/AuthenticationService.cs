using BeCoreApp.Application.Interfaces;
using BeCoreApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetAuthenticatorKey(AppUser user)
        {
            var authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            if (string.IsNullOrEmpty(authenticatorKey))
            {
                await _userManager.ResetAuthenticatorKeyAsync(user);
                authenticatorKey = await _userManager.GetAuthenticatorKeyAsync(user);
            }
            return authenticatorKey;
        }

        public async Task<(IEnumerable<string> RecoveryCodes, bool IsSuccess)> VerifyTokenToEnableTwoFactorAsync(string otpCode, AppUser user, string tokenProvider)
        {
            
            var isLockedOut = await _userManager.IsLockedOutAsync(user);

            if (isLockedOut) return (null, false);

            var isValidOtp = await _userManager.VerifyTwoFactorTokenAsync(user, tokenProvider, otpCode);
            if (!isValidOtp) return (null, false);

            //TODO: should send revocery code to user's email or phone

            //current table AppUserTokens has wrong design, it should have 3 primary key.

            //if (await _userManager.CountRecoveryCodesAsync(user) != 0) return (null, true);

            //var recoveryCode = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 5);

            //return (recoveryCode, true);

            await _userManager.SetTwoFactorEnabledAsync(user, true);

            return (null, true);
        }

        public async Task<bool> ConfirmPasswordToDisableTwoFactorAuthentication(string confirmPassword, AppUser user)
        {
            var isPasswordMatched = await _userManager.CheckPasswordAsync(user, confirmPassword);
            if (!isPasswordMatched)
            {
                return false;
            }

            var isLockedOut = await _userManager.IsLockedOutAsync(user);

            if (!isLockedOut)
            {
                 await _userManager.SetTwoFactorEnabledAsync(user, false);

                return true;
            }

            return false;
        }
    }
}
