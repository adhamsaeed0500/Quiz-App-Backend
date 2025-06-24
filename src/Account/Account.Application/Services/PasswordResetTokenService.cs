using Account.Application.Interfaces;
using Account.Domain;
using Microsoft.AspNetCore.Identity;

namespace Acccount.Application.Services
{
    public class PasswordResetTokenService : IPasswordResetTokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataProtectorTokenProvider<ApplicationUser> _dataProtectorTokenProvider;

        public PasswordResetTokenService(
            UserManager<ApplicationUser> userManager,
            DataProtectorTokenProvider<ApplicationUser> dataProtectorTokenProvider)
        {
            _userManager = userManager;
            _dataProtectorTokenProvider = dataProtectorTokenProvider;
        }
        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<bool> ValidatePasswordResetTokenAsync(ApplicationUser user, string token)
        {
            return await _userManager.VerifyUserTokenAsync(user,
                _userManager.Options.Tokens.PasswordResetTokenProvider,
                "ResetPassword",
                token);
        }
    }
}
