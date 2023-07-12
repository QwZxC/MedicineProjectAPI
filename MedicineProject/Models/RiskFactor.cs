using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models
{
    public class RiskFactor : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

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
