using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Quiz_App.Dtos;
using Quiz_App.Models;
using Quiz_App.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quiz_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;

        

        public AccountController(AuthService authService,UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager; 
            _configuration = configuration;
            _authService = authService;
        }


        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            // these will be handled in the configure service in program.cs

            //var userExists = await _userManager.FindByEmailAsync(model.Email);

           // if(userExists != null)
           // {
              //  return BadRequest(new { error = "A user with this email already exists" });
          //  }


            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,            
            };
                

            var result = await _userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
                return BadRequest(ModelState);           
            }      
            return Ok(new { message = "User created successfully", userId = user.Id});
        }
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists == null && !await _userManager.CheckPasswordAsync(userExists,model.Password))
            {
                return Unauthorized(new { message = "Invalid email or password" });           
                         
            }


            var token = await _authService.GenerateJwtToken(userExists);

            return Ok(new {

                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
            });
        
        }










    }
}
