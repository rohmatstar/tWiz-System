﻿using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Auths
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Token { get; set; }

        [Required]
        public DateTime TokenExpiration { get; set; }
    }
}