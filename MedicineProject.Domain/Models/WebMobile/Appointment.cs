using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.WebMobile
{
    public class Appointment : BaseModel
    {
        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public TimeOnly Time { get; set; }

        public DateTime Date { get; set; }
        
        public Type Type { get; set; }

        public long TypeId { get; set; }

        public long PatientId { get; set; }

        public long DoctorId { get; set; }

        public bool IsOpen { get; set; }

        public Appointment() 
        { }
    }
}
