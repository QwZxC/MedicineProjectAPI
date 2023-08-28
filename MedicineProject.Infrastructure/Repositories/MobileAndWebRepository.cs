using MedicineProject.Domain.Context;
using MedicineProject.Domain.Filters;
using MedicineProject.Domain.Repositories;
using MedicineProject.Domain.Models.WebMobile;
using Microsoft.EntityFrameworkCore;
using MedicineProject.Domain.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Infrastructure.Repositories
{
    public class MobileAndWebRepository : BaseRepository, IMobileAndWebRepository
    {
        public MobileAndWebRepository(WebMobileContext context) : base(context)
        {

        }

        public async Task<IdentityRole<long>> FindRoleByNameAsync(string name)
        {
            return await context.Roles.FirstOrDefaultAsync(role => name == role.Name);
        }

        public async Task<List<long>> FindRoleIdsAsync(long userId)
        {
            return await context.UserRoles.Where(r => r.UserId == userId).Select(x => x.RoleId).ToListAsync();
        }

        public async Task<List<IdentityRole<long>>> FindRolesAsync(List<long> roleIds)
        {
            return await context.Roles.Where(x => roleIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<Patient> FindUserByEmailAsync(string email)
        {
            return await context.Patient.FirstOrDefaultAsync(u => u.Email == email);
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

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
