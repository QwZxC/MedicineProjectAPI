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

        public long RiskFactorId { get; set; }

        public long IllnessId { get; set; }

        public Patient()
        {

        }
    }
}
