using MedicineProject.DTOs.Base;
using MedicineProject.Models;
using System.Text.Json.Serialization;

namespace MedicineProject.DTOs
{
    public record UserDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string UserToken { get; set; }

        [JsonConstructor]
        public UserDTO()
        {

        }

        [JsonConstructor]
        public UserDTO(Patient person)
        {
            Id = person.Id;
            Name = person.Name;
            Surname = person.Surname;
            Patronymic = person.Patronymic;
            Email = person.Email;
        }
    }
}
