using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Repositories
{
    public interface IHospitalRepository : IBaseRepository
    {
        Task<List<Doctor>> LoadDoctorsForHospitalAsync(long hospitalId);
    }
}
