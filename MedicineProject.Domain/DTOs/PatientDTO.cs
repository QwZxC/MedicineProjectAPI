using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs
{
    public record PatientDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public PatientDTO() { }
    }
}
