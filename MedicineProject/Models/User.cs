using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models
{
    public abstract class User : BaseModel
    {
        public string Surname { get; set; }

        public string? Patronymic { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public User() { }
        
        public User(UserDTO personDTO)
        {
            Id = personDTO.Id;
            Name = personDTO.Name;
            Surname = personDTO.Surname;
            Patronymic = personDTO.Patronymic;
            Email = personDTO.Email;
            Password = personDTO.Password;
        }
    }
}
