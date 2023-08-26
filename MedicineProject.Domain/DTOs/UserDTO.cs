using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs
{
    public record UserDTO : BaseDTO
    {
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string? Patronymic { get; set; }
        
        /// <summary>
        /// Электронный адрес пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Access-токен пользователя
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// RefreshToken-токен пользователя
        /// </summary>
        public string RefreshToken { get; set; }

        public UserDTO()
        {

        }
    }
}
