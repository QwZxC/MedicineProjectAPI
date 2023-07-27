using MedicineProject.DTOs.Base;
using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record CountyDTO : BaseDTO
    {
        public List<RegionDTO> RegionDTOs { get; set; }

        public CountyDTO() { }

        public CountyDTO(County county) 
        {
            Id = county.Id;
            Name = county.Name;
        }
    }
}
