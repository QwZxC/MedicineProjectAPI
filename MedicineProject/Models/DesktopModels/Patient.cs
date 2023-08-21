using MedicineProject.DTOs;
using MedicineProject.Models.WebMobileModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineProject.Models.DesktopModels
{
    public class Patient
    {
        [NotMapped]
        public RiskFactor RiskFactor { get; set; }

        [NotMapped]
        public Illness Illness { get; set; }

        public long RiskFactorId { get; set; }

        public long IllnessId { get; set; }

        public long HospitalId { get; set; }

        public Hospital Hospital { get; set; }

        public Patient()
        {

        }
    }
}
