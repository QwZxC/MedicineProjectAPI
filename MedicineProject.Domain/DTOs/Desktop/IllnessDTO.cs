using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.Models.DesktopModels;

namespace MedicineProject.Domain.DTOs.Desktop
{
    public record IllnessDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IllnessDTO() { }

        public IllnessDTO(Illness illness)
        {
            Id = illness.Id;
            Name = illness.Name;
            Description = illness.Description;
        }
    }
}
