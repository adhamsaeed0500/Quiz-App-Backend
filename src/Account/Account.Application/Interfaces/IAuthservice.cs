using Account.Domain;
using System.IdentityModel.Tokens.Jwt;

namespace Account.Application.Interfaces
{
    public interface IAuthservice
    {
        public Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user);
    }
}
