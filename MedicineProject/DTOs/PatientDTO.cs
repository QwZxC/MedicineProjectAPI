using MedicineProject.Models;
using System.Text.Json.Serialization;

namespace MedicineProject.DTOs
{
    public record PatientDTO : UserDTO
    {
        public RiskFactorDTO RiskFactor { get; set; }

        public IllnessDTO Illness { get; set; }
        
        public long RiskFactorId { get; set; }

        public long IllnessId { get; set; }

        public PatientDTO() { }

        public PatientDTO(Patient patient) : base(patient)
        {
            RiskFactor = new RiskFactorDTO(patient.RiskFactor);
            Illness = new IllnessDTO(patient.Illness);
            RiskFactorId = patient.RiskFactorId;
            IllnessId = patient.IllnessId;
        }

        public PatientDTO(long id, string name, string surname, string patronumic,
                          string email, string password, RiskFactorDTO riskFactor, 
                          IllnessDTO illness, long riskFactorId, long illnesId)
        { 
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronumic;
            Email = email;
            Password = password;
            RiskFactor = riskFactor;
            Illness = illness;
            RiskFactorId = riskFactorId;
            IllnessId = illnesId;
        }
    }
}
