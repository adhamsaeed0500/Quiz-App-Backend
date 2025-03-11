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

            

            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if(userExists != null)
            {
                return BadRequest(new { error = "A user with this email already exists" });
            }


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
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return BadRequest(ModelState);           
            }      
            return Ok(new { message = "User created successfully", userId = user.Id });
        }


        

    }
}
