using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs
{
    public record DoctorDTO : BaseDTO
    {
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public long SpecialityId { get; set; }

        public long Doctor_HospitalId { get; set; }

        public SpecialityDTO Speciality { get; set; }

        public DoctorDTO()
        {

        }
    }
}
