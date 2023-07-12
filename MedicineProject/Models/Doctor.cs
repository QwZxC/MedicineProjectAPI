using MedicineProject.DTOs;

namespace MedicineProject.Models
{
    public class Doctor : User
    {
        public int SpecialityId { get; set; }
        
        public Speciality Speciality { get; set; }

        public Doctor(DoctorDTO doctor)
            : base(doctor) 
        { 
            SpecialityId = doctor.SpecialityId;
            Speciality = doctor.Speciality;
        }

        public Doctor()
        {

        }
    }
}
