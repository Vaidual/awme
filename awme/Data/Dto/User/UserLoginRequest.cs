﻿using System.ComponentModel.DataAnnotations;

namespace awme.Data.Dto.User
{
    public class UserLoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
