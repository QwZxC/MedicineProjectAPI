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

        public async Task<List<Hospital>> GetHospitalsWithFilterAsync(HospitalFilter filter)
        {
            List<Hospital> hospitals = new List<Hospital>();
            await context.Hospital.ForEachAsync(hospital =>
            {
                if (hospital.Name.Contains(filter.Name) && 
                    hospital.CityId == filter.CityId && 
                    hospital.Rating >= filter.MinRating &&
                    hospital.Rating <= filter.MaxRating)
                {
                    hospitals.Add(hospital);
                }
            });
            return hospitals;
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
