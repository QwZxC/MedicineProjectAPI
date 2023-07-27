using MedicineProject.DTOs;
using MedicineProject.Models.Base;

namespace MedicineProject.Models
{
    public class Hospital : BaseModel 
    {
        public string Description { get; set; }

        public string Address { get; set; }

        public TimeOnly StartedTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string Contacts { get; set; }

        public byte Rating { get; set; }

        public string Email { get; set; }

        public List<Patient> Patients { get; set; }

        public List<Doctor> Doctors { get; set; }

        public long CityId { get; set; }

        public City City { get; set; }

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
            Contacts = hospital.Contacts;
            CityId = hospital.CityId;
        }
    }
}
