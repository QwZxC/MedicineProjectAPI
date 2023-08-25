using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs
{
    public record PatientDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public RiskFactorDTO RiskFactor { get; set; }

        public IllnessDTO Illness { get; set; }
        
        public long RiskFactorId { get; set; }

        public long HospitalId { get; set; }

        public long IllnessId { get; set; }

        public PatientDTO() { }
    }
}
