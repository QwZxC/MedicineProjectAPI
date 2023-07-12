using MedicineProject.DTOs.Base;
using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record IllnessDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IllnessDTO(Illness illness)
        {
            Id = illness.Id;
            Name = illness.Name;
            Description = illness.Description;
        }
    }
}
