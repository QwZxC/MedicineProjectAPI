using MedicineProject.Domain.Models.Base;
using MedicineProject.Domain.DTOs;

namespace MedicineProject.Domain.Models.WebMobile
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
