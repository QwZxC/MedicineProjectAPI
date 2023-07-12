using MedicineProject.DTOs.Base;
using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record SpecialityDTO : BaseDTO
    {
        public string Name { get; set; }

        public SpecialityDTO(Speciality speciality)
        {
            Id = speciality.Id;
            Name = speciality.Name;
        }
    }
}
