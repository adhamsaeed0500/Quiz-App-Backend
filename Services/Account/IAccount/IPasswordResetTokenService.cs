using Microsoft.AspNetCore.Identity;
using Quiz_App.Models;

namespace Quiz_App.Services.Account.IAccount
{
    public interface IPasswordResetTokenService
    {
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<bool> ValidatePasswordResetTokenAsync(ApplicationUser user , string token);
    }
}
