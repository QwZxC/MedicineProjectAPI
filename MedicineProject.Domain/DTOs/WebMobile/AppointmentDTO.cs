using MedicineProject.Domain.DTOs.Base;

namespace MedicineProject.Domain.DTOs.WebMobile 
{
    public record AppointmentDTO : BaseDTO
    {
        public DateTime Time { get; set; }

        public DateTime Date { get; set; }

        public long TypeId { get; set; }

        public long PatientId { get; set; }

        public long DoctorId { get; set; }

        public bool IsOpen { get; set; }

        public AppointmentDTO() { }
    }
}
