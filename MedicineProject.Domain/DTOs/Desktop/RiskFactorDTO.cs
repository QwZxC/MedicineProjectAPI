using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs.Desktop
{
    public record RiskFactorDTO : BaseDTO
    {
        /// <summary>
        /// Описание фактора риска
        /// </summary>
        public string Description { get; set; }

        public RiskFactorDTO() { }
    }
}
