using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.WebMobile
{
    public class County : BaseModel
    {
        public List<Region> Regions { get; set; }

        public County() { }
    }
}
