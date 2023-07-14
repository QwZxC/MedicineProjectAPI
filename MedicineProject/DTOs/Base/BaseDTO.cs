using System.ComponentModel.DataAnnotations;

namespace MedicineProject.DTOs.Base
{
    public record BaseDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
