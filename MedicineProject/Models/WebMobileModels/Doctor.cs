using MedicineProject.Models.Base;

namespace MedicineProject.Models.WebMobileModels
{
    public class Doctor : BaseModel
    {
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public Hospital Hospital { get; set; }

        public long SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        public List<Appointment> Appointments { get; set; }

        public Doctor()
        {

        }
    }
}
