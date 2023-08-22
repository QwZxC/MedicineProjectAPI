using MedicineProject.Domain.DTOs;

namespace MedicineProject.Domain.DTOs
{
    public record DoctorDTO : UserDTO
    {
        public long SpecialityId { get; set; }

        public long Doctor_HospitalId { get; set; }

        public SpecialityDTO Speciality { get; set; }

        public DoctorDTO()
        {

        }
    }
}
