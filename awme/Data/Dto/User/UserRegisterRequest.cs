﻿using System.ComponentModel.DataAnnotations;

namespace awme.Data.Dto.User
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
