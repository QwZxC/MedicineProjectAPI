using MedicineProject.DTOs.Base;
using MedicineProject.Models;
using System.Text.Json.Serialization;

namespace MedicineProject.DTOs
{
    public abstract record UserDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        [JsonConstructor]
        public UserDTO()
        {

        }

        [JsonConstructor]
        public UserDTO(User person)
        {
            Id = person.Id;
            Name = person.Name;
            Surname = person.Surname;
            Patronymic = person.Patronymic;
            Email = person.Email;
        }
    }
}
