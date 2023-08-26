namespace MedicineProject.Domain.DTOs.Identity
{
    public record AuthResponse
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Username { get; set; } = null!;
        
        /// <summary>
        /// Адрес электронной почты пользователя
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Access-токен пользователя
        /// </summary>
        public string Token { get; set; } = null!;

        /// <summary>
        /// RefreshToken-токен пользователя
        /// </summary>
        public string RefreshToken { get; set; } = null!;
        
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public string Role { get; set; } = null!;
    }
}
