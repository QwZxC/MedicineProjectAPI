using MedicineProject.DTOs;
using MedicineProject.Models.Base;
using MedicineProject.Models.DesktopModels;

namespace MedicineProject.Models.WebMobileModels
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
