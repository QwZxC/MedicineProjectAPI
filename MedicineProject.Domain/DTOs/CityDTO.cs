using MedicineProject.DTOs.Base;
using MedicineProject.Models.WebMobileModels;

namespace MedicineProject.DTOs
{
    public record CityDTO : BaseDTO
    {
        public long RegionId { get; set; }

        public List<HospitalDTO> Hospitals { get; set; }

        public CityDTO() { }

        public CityDTO(City city)
        {
            Id = city.Id;
            Name = city.Name;
            RegionId = city.Region.Id;
        }
    }
}
