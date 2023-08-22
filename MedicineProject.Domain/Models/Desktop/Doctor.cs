using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Domain.Models.Desktop
{
    public class Doctor : IdentityUser<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public Doctor() 
        { 

        }
    }
}
