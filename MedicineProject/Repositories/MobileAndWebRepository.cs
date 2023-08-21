using MedicineProject.Context;
using MedicineProject.Filters;
using MedicineProject.Models.WebMobileModels;
using MedicineProject.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Repositories
{
    public class MobileAndWebRepository : BaseRepository
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

    }
}
