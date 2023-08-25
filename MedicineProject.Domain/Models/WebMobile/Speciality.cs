using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.WebMobile
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
