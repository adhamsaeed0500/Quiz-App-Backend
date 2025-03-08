using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz_App.Dtos;
using Quiz_App.Models;

namespace Quiz_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager; 
            _configuration = configuration;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(model.Password != model.ConfirmPassword)
            {

                ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match");
                return BadRequest(ModelState);
            }

            var userEixst = await _userManager.FindByEmailAsync(model.Email);

            if(userEixst != null)
            {
                return BadRequest("User Alreadsy Exist");
            }


            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = model.Password
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
            return Ok("User created successfully");












        }
        

    }
}
