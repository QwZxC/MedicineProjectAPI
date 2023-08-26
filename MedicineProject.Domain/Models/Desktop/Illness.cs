using MedicineProject.Domain.DTOs.Desktop;
using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.DesktopModels
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
