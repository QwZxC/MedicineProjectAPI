using MedicineProject.Domain.Models.Base;
using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Identity;

namespace MedicineProject.Domain.Repositories
{
    public interface IMobileAndWebRepository : IBaseRepository
    {

        Task<List<Doctor>> LoadDoctorsForHospitalAsync(long hospitalId);
        IEnumerable<TModel> GetItems<TModel>() where TModel : BaseModel;
        Task SaveChangesAsync();
        Task<Patient> FindUserByEmailAsync(string email);
        Task<List<long>> FindRoleIdsAsync(long userId);
        Task<List<IdentityRole<long>>> FindRolesAsync(List<long> roleIds);
        Task<IdentityRole<long>> FindRoleByNameAsync(string name);
        Task<List<Hospital>> GetHospitalsAsync();
    }
}
