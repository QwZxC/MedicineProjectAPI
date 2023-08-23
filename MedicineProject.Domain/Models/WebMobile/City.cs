using MedicineProject.Domain.DTOs;
using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.WebMobile
{
    public class City : BaseModel
    {
        public Region Region { get; set; }

        public long RegionId { get; set; }

        public List<Hospital> Hospitals { get; set; } = new List<Hospital>();

        public City() { }

        public City(CityDTO city)
        {
            Name = city.Name;
        }
    }
}
