using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models
{
    public class Hospital : BaseModel 
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime StartedTime { get; set; }

        public DateTime EndTime { get; set; }

        public byte Rating { get; set; }

        public string Email { get; set; }

        public List<Patient> Patients { get; set; }

        public List<Doctor> Doctors { get; set; }

        public Hospital() { }

        public Hospital(HospitalDTO hospital)
        {
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
