using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs.Desktop
{
    public record IllnessDTO : BaseDTO
    {
        /// <summary>
        /// Описание заболевания
        /// </summary>
        public string Description { get; set; }

        public IllnessDTO() { }
    }
}
