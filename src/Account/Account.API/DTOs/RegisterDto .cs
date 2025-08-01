﻿using System.ComponentModel.DataAnnotations;

namespace Acccount.APi.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage = "The password and confirmation password do not match ")]
        public string ConfirmPassword { get; set; }
            


    }
}
