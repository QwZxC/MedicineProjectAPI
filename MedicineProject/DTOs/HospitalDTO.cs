using MedicineProject.DTOs.Base;
using MedicineProject.Models;

namespace MedicineProject.DTOs
{
    public record HospitalDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public TimeOnly StartedTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public byte Rating { get; set; }

        public string Email { get; set; }
        
        public List<Patient> Patients { get; set; }

        public List<Doctor> Doctors { get; set; }
        
        public HospitalDTO() { }

        public HospitalDTO(Hospital hospital)
        {
            Id = hospital.Id;
            Name = hospital.Name;
            Description = hospital.Description;
            Address = hospital.Address;
            StartedTime = hospital.StartedTime;
            EndTime = hospital.EndTime;
            Rating = hospital.Rating;
            Email = hospital.Email;
            Patients = hospital.Patients;
            Doctors = hospital.Doctors;
        }
    }
}
