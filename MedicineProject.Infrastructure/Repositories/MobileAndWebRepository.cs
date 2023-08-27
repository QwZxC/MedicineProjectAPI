using MedicineProject.Domain.Context;
using MedicineProject.Domain.Filters;
using MedicineProject.Domain.Repositories;
using MedicineProject.Domain.Models.WebMobile;
using Microsoft.EntityFrameworkCore;
using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Infrastructure.Repositories
{
    public class MobileAndWebRepository : BaseRepository, IMobileAndWebRepository
    {
        public MobileAndWebRepository(WebMobileContext context) : base(context)
        {

        }

        public IEnumerable<TModel> GetItems<TModel>()
            where TModel : BaseModel
        {
           return context.Set<TModel>();
        }

        public async Task<List<Doctor>> LoadDoctorsForHospitalAsync(long hospitalId)
        {
            List<Doctor> doctors = new List<Doctor>();
            await context.Doctor.Include(doctor => doctor.Speciality).
                  ForEachAsync(doctor => 
                  {
                      if (doctor.HospitalId == hospitalId)
                      {
                          doctors.Add(doctor);
                      }
                  });
            return doctors;
        }

    }
}
