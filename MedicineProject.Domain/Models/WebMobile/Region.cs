using MedicineProject.Domain.DTOs;
using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.WebMobile
{
    public class Region : BaseModel
    {
        public long CountyId { get; set; }

        public County County { get; set; }

        public List<City> Cities { get; set; } = new List<City>();

        public Region() { }
    }
}
