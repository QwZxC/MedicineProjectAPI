using MedicineProject.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineProject.Models
{
    public class Patient : User
    {
        [NotMapped]
        public RiskFactor RiskFactor { get; set; }

        [NotMapped]
        public Illness Illness { get; set; }

        public int RiskFactorId { get; set; }

        public int IllnessId { get; set; }

        public Patient()
        {

        }

        public Patient(PatientDTO patient) : 
            base(patient) 
        {
            RiskFactor = new RiskFactor(patient.RiskFactor);
            Illness = new Illness(patient.Illness);
            RiskFactorId = patient.RiskFactorId;
            IllnessId = patient.IllnessId;
        }
    }
}
