using MedicineProject.DTOs.Base;
using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record SpecialityDTO : BaseDTO
    {
        public string Name { get; set; }

        public List<Doctor> Doctors { get; set; }

        public SpecialityDTO() { }

        public SpecialityDTO(Speciality speciality)
        {
            Id = speciality.Id;
            Name = speciality.Name;
            Doctors = speciality.Doctors;
        }
    }
}
