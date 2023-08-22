using System.ComponentModel.DataAnnotations;

namespace MedicineProject.DTOs.Base
{
    public record BaseDTO
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
