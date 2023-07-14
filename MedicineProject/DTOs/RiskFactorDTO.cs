using MedicineProject.DTOs.Base;
using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record RiskFactorDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RiskFactorDTO() { }

        public RiskFactorDTO(RiskFactor riskFactor)
        {
            Id = riskFactor.Id;
            Name = riskFactor.Name;
            Description = riskFactor.Description;
        }
    }
}
