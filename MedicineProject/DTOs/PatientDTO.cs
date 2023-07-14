using MedicineProject.Models;
using System.Text.Json.Serialization;

namespace MedicineProject.DTOs
{
    public record PatientDTO : UserDTO
    {
        public RiskFactorDTO RiskFactor { get; set; }

        public IllnessDTO Illness { get; set; }
        
        public int RiskFactorId { get; set; }

        public int IllnessId { get; set; }

        public PatientDTO() { }

        public PatientDTO(Patient patient) : base(patient)
        {
            RiskFactor = new RiskFactorDTO(patient.RiskFactor);
            Illness = new IllnessDTO(patient.Illness);
            RiskFactorId = patient.RiskFactorId;
            IllnessId = patient.IllnessId;
        }

        public PatientDTO(int id, string name, string surname, string patronumic,
                          string email, string password, RiskFactorDTO riskFactor, 
                          IllnessDTO illness, int riskFactorId, int illnesId)
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
