using MedicineProject.DTOs.Base;
using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record RegionDTO : BaseDTO
    {
        public long CountyId { get; set; }
        
        public List<CityDTO> Cities { get; set; }

        public RegionDTO() { }

        public RegionDTO(Region region)
        {
            Id = region.Id;
            Name = region.Name;
            CountyId = region.County.Id;
        }
    }
}
