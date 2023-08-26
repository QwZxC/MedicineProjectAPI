using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.DTOs
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
