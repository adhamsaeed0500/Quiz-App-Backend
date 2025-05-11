using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Quiz_App.Dtos;
using Quiz_App.Models;
using Quiz_App.Services.Account;
using Quiz_App.Services.Account.IAccount;
using Quiz_App.Services.Email;
using System.ComponentModel.DataAnnotations;
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
        private readonly IEmailSender _emailSender;
        private readonly IPasswordResetTokenService _passwordResetTokenService;

        

        public AccountController(AuthService authService,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IEmailSender emailSender,
            IPasswordResetTokenService passwordResetTokenService)
        {
            _userManager = userManager; 
            _configuration = configuration;
            _authService = authService;
            _emailSender = emailSender;
            _passwordResetTokenService = passwordResetTokenService;
        }


        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Register([FromBody]RegisterDto model)
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
        public async Task<IActionResult> Login([FromBody] LoginDto model)
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

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([EmailAddress] [FromBody] [Required]  string Email)
        {
            var frontEndResetPasswordURl = _configuration.GetSection("FrontEnd");
            if (Email is null)
            {
                return BadRequest("invalid Email");
            }

            var user = await _userManager.FindByEmailAsync(Email);

            if(user is null)
            {
                return BadRequest("invalid Email");
            }
            //
            //Generate Token 
            var token = _passwordResetTokenService.GeneratePasswordResetTokenAsync(user);


            string emailSubject = "Reset Password";

            string emailMessage = $"click on the link to resrt password {frontEndResetPasswordURl["ResertPasswordUrl"]} , Key ={token}";

           await _emailSender.SendEmailAsync(Email, emailSubject, emailMessage);

            return Ok("If your email is registered, you will receive a password reset link.");

        }
        [HttpPost("ResretPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(resetPassword.Email);

            if (user is null)
                return BadRequest("invalid email");

            // verify Token 
            var verfied = await _passwordResetTokenService.ValidatePasswordResetTokenAsync(user, resetPassword.Token);

            if (verfied is false)
                return BadRequest("Invalid password reset token");

            var resetedUser = await _userManager.ResetPasswordAsync(user, resetPassword.Token ,resetPassword.NewPassword);

            if (!resetedUser.Succeeded)
            {              
                return BadRequest(resetedUser.Errors);
            }
            return Ok("Password has been reset successfully.");
        }








    }
}
