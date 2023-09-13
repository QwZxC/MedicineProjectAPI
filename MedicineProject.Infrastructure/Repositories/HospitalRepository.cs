using MedicineProject.Domain.Context;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Infrastructure.Repositories
{
    public class HospitalRepository : BaseRepository, IHospitalRepository
    {
        public HospitalRepository(WebMobileContext context) : base(context) 
        { 
        
        }

        public async Task<List<Doctor>> LoadDoctorsForHospitalAsync(long hospitalId)
        {
            List<Doctor> doctors = new List<Doctor>();
            await _context.Doctor.Include(doctor => doctor.Speciality).
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
