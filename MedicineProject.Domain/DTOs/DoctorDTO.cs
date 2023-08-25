using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.DTOs.WebMobile;

namespace MedicineProject.Domain.DTOs
{
    public record DoctorDTO : BaseDTO
    {
        /// <summary>
        /// Фамилия доктора
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество доктора не обязательный параметр
        /// </summary>
        public string? Patronymic { get; set; }
        
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

        public DoctorDTO()
        {

        }
    }
}
