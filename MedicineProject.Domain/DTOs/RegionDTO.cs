using MedicineProject.Domain.DTOs;
using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.DTOs
{
    public record RegionDTO : BaseDTO
    {
        public long CountyId { get; set; }
        
        public List<CityDTO> Cities { get; set; } = new List<CityDTO>();

        public RegionDTO() { }

        public RegionDTO(Region region)
        {
            Id = region.Id;
            Name = region.Name;
            CountyId = region.County.Id;
        }
    }
}
