using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.Models.DesktopModels;

namespace MedicineProject.Domain.DTOs.Desktop
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
