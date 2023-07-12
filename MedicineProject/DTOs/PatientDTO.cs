using MedicineProject.Models;
using System.Text.Json.Serialization;

namespace MedicineProject.DTOs
{
    public record PatientDTO : UserDTO
    {
        public RiskFactor RiskFactor { get; set; }

        public Illness Illness { get; set; }
        
        
        public int RiskFactorId { get; set; }

        public int IllnesId { get; set; }

        public PatientDTO(Patient patient) : base(patient)
        {
            RiskFactor = patient.RiskFactor;
            Illness = patient.Illness;
            RiskFactorId = patient.RiskFactorId;
            IllnesId = patient.IllnesId;
        }

        [JsonConstructor]
        public PatientDTO(int id, string name, string surname, string patronumic,
                          string email, string password, bool isActive, 
                          RiskFactor riskFactor, Illness illness, int riskFactorId, int illnesId)
        { 
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronumic;
            Email = email;
            Password = password;
            IsActive = isActive;
            RiskFactor = riskFactor;
            Illness = illness;
            RiskFactorId = riskFactorId;
            IllnesId = illnesId;
        }
    }
}
