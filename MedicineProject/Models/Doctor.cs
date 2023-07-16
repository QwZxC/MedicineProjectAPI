using MedicineProject.DTOs;

namespace MedicineProject.Models
{
    public class Doctor : User
    {
        public long SpecialityId { get; set; }
        
        public Speciality Speciality { get; set; }

        public Doctor()
        {

        }
    }
}
