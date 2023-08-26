using MedicineProject.Domain.Filters;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Repositories
{
    public interface IMobileAndWebRepository : IBaseRepository
    {
        Task<List<Hospital>> GetHospitalsWithFilterAsync(HospitalFilter filter);
    }
}
