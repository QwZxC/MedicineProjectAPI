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

        public int IllnesId { get; set; }

        public Patient()
        {

        }

        public Patient(PatientDTO patient) : 
            base(patient) 
        {
            RiskFactor = patient.RiskFactor;
            Illness = patient.Illness;
            RiskFactorId = patient.RiskFactorId;
            IllnesId = patient.IllnesId;
        }
    }
}
