using System.ComponentModel.DataAnnotations;

namespace MedicineProject.Models.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
