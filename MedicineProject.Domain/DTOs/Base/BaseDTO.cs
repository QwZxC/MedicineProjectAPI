using System.ComponentModel.DataAnnotations;

namespace MedicineProject.Domain.DTOs.Base
{
    public record BaseDTO
    {
        /// <summary>
        /// Первичный ключ записи
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Имя экземпляра сущности
        /// </summary>
        public string Name { get; set; }
    }
}
