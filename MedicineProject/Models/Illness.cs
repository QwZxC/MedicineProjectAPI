using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models
{
    public class Illness : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Illness() { }

        public Illness(IllnessDTO illness)
        {
            Name = illness.Name;
            Description = illness.Description;
        }
    }
}
