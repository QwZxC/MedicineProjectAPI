using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record DoctorDTO : UserDTO
    {
        public long SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        public DoctorDTO()
        {

        }

        public DoctorDTO(Doctor doctor) : base(doctor) 
        {
            SpecialityId = doctor.SpecialityId;
            Speciality = doctor.Speciality;
        }
    }
}
