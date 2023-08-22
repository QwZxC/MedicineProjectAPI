using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineProject.Domain.Models.DesktopModels
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

        public Patient()
        {

        }
    }
}
