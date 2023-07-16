﻿using MedicineProject.DTOs;
using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Models
{
    public class User : IdentityUser<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public User() 
        { 

        }
    }
}
