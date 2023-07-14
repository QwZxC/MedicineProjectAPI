using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models
{
    public class Speciality : BaseModel
    {
        public string Name { get; set; }
        
        public List<Doctor> Doctors { get; set; }

        public Speciality()
        {

        }

        public Speciality(SpecialityDTO speciality) 
        {
            Name = speciality.Name;
        }
    }
}
