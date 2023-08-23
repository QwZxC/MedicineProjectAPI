using MedicineProject.Domain.DTOs;
using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.DesktopModels
{
    public class RiskFactor : BaseModel
    {
        public string Description { get; set; }

        public List<Patient> Patients { get; set; }

        public RiskFactor()
        {

        }

        public RiskFactor(RiskFactorDTO riskFactor)
        {
            Name = riskFactor.Name;
            Description = riskFactor.Description;
        }
    }
}
