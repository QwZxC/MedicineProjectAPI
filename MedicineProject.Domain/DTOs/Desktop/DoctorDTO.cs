using MedicineProject.Domain.DTOs.WebMobile;

namespace MedicineProject.Domain.DTOs.Desktop
{
    public record DoctorDTO : UserDTO
    {
        /// <summary>
        /// Id больницы к которой прикреплён доктор
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// Id специальности доктора
        /// </summary>
        public long SpecialityId { get; set; }

        /// <summary>
        /// Список заявок у доктора
        /// </summary>
        public List<AppointmentDTO> Appointments { get; set; }

        /// <summary>
        /// Специальность доктора
        /// </summary>
        public SpecialityDTO Speciality { get; set; }

        public DoctorDTO() { }

    }
}
