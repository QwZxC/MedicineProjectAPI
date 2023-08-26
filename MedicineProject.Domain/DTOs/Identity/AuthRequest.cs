namespace MedicineProject.Domain.DTOs.Identity
{
    public record AuthRequest
    {
        /// <summary>
        /// Адресс электронной почты, через который происходит аутентификация
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль, через который происходит аутентификация
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Роль пользователя 
        /// </summary>
        public string Role { get; set; }
    }
}
