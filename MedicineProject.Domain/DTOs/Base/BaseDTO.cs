using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MedicineProject.Domain.DTOs.Base
{
    public record BaseDTO
    {
        [Key]
        [JsonPropertyName("name")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
