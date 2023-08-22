using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Domain.Models.WebMobile
{
    public class Patient : IdentityUser<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? RefreshToken { get; set; }

        public List<Appointment> Appointments { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public Patient() 
        { 

        }
    }
}
