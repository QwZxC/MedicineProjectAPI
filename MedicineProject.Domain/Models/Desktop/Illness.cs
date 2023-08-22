using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models.DesktopModels
{
    public class Illness : BaseModel
    {
        public string Description { get; set; }

        public List<Patient> Patients { get; set; }

        public Illness() { }

        public Illness(IllnessDTO illness)
        {
            Name = illness.Name;
            Description = illness.Description;
        }
    }
}
