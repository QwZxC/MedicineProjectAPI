using MedicineProject.Models.Base;

namespace MedicineProject.Models.WebMobileModels
{
    public class Appointment : BaseModel
    {
        public Appointment() { }

        public Models.Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public TimeOnly Time { get; set; }

        public DateTime Date { get; set; }
        
        public Type Type { get; set; }

        public long TypeId { get; set; }

        public long PatientId { get; set; }

        public long DoctorId { get; set; }

        public bool IsOpen { get; set; }
    }
}
