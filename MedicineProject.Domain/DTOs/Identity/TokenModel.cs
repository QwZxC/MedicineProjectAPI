﻿namespace MedicineProject.DTOs.Identity
{
    public record TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
