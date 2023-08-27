using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.DTOs
{
    public record CountyDTO : BaseDTO
    {
        public List<RegionDTO> RegionDTOs { get; set; } = new List<RegionDTO>();

        public CountyDTO() { }

        public CountyDTO(County county) 
        {
            Id = county.Id;
            Name = county.Name;
        }
    }
}
