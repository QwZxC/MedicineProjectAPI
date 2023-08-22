using System.ComponentModel.DataAnnotations;

namespace MedicineProject.Domain.Models.Base
{
    public abstract class BaseModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
