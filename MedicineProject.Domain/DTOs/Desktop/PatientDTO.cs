namespace MedicineProject.Domain.DTOs.Desktop
{
    public record PatientDTO
    {
        /// <summary>
        /// Фамилия пациента
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество пациента не обязательный параметр
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Фактор риска у пациента
        /// </summary>
        public RiskFactorDTO RiskFactor { get; set; }

        /// <summary>
        /// Заболевание пациента
        /// </summary>
        public IllnessDTO Illness { get; set; }

        /// <summary>
        /// Внешний ключ записи фактора риска пациента
        /// </summary>
        public long RiskFactorId { get; set; }

        /// <summary>
        /// Внешний ключ записи заболевания пациента
        /// </summary>
        public long IllnessId { get; set; }

        public PatientDTO() { }
    }
}
