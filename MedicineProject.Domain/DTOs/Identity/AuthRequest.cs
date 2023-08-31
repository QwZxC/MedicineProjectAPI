﻿using System.ComponentModel.DataAnnotations;

namespace MedicineProject.Domain.DTOs.Identity
{
    public record AuthRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
