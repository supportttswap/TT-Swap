using BeCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeCoreApp.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetAuthenticatorKey(AppUser user);
        Task<(IEnumerable<string> RecoveryCodes, bool IsSuccess)> VerifyTokenToEnableTwoFactorAsync(string otpCode, AppUser user, string tokenProvider);
        Task<bool> ConfirmPasswordToDisableTwoFactorAuthentication(string confirmPassword, AppUser user);
    }
}
