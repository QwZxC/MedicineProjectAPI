namespace MedicineProject.Domain.DTOs
{
    public record PatientDTO : UserDTO
    {
        public RiskFactorDTO RiskFactor { get; set; }

        public IllnessDTO Illness { get; set; }
        
        public long RiskFactorId { get; set; }

        public long HospitalId { get; set; }

        public long IllnessId { get; set; }

        public PatientDTO() { }
    }
}
