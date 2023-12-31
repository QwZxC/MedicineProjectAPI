﻿using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs.WebMobile
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
        /// Специальность доктора
        /// </summary>
        public SpecialityDTO Speciality { get; set; }

        public DoctorDTO()
        {

        }
    }
}
