using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.DTOs.WebMobile
{
    public record SpecialityDTO : BaseDTO
    {
        public string Name { get; set; }

        public SpecialityDTO() { }

        public SpecialityDTO(Speciality speciality)
        {
            Id = speciality.Id;
            Name = speciality.Name;
        }
    }
}
