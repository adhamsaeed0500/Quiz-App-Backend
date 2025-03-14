using Quiz_App.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Quiz_App.Services
{
    public interface IAuthservice
    {



        public  Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user);
    }
}
