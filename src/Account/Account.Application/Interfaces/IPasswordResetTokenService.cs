using Account.Domain;
using Microsoft.AspNetCore.Identity;

namespace Account.Application.Interfaces
{
    public interface IPasswordResetTokenService
    {
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<bool> ValidatePasswordResetTokenAsync(ApplicationUser user , string token);
    }
}
