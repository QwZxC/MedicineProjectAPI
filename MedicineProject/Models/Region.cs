using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models
{
    public class Region : BaseModel
    {
        public long CountyId { get; set; }

        public County County { get; set; }

        public List<City> Cities { get; set; } = new List<City>();

        public Region() { }
        
        public Region(RegionDTO region)
        {
            Name = region.Name;
        }
    }
}
