using MedicineProject.Models.Base;
using MedicineProject.DTOs;

namespace MedicineProject.Models.WebMobileModels
{
    public class County : BaseModel
    {
        public List<Region> Regions { get; set; }

        public County() { }

        public County(CountyDTO county)
        {
            Name = county.Name;
        }
    }
}
