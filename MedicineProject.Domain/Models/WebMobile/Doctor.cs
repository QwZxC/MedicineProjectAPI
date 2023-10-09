using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.WebMobile
{
    public class Doctor : BaseModel
    {
        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public Hospital Hospital { get; set; }

        public long HospitalId { get; set; }

        public long SpecialityId { get; set; }

        public Speciality Speciality { get; set; }

        public Doctor()
        {

        }
    }
}
