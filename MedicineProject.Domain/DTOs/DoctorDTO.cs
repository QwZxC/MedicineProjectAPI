using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.DTOs.WebMobile;

namespace MedicineProject.Domain.DTOs
{
    public record DoctorDTO : BaseDTO
    {
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public long HospitalId { get; set; }

        public long SpecialityId { get; set; }

        public List<AppointmentDTO> Appointments { get; set; }

        public SpecialityDTO Speciality { get; set; }

        public DoctorDTO()
        {

        }
    }
}
