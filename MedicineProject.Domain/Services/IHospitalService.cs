using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Services
{
    public interface IHospitalService
    {
        Task<List<Hospital>> hospitals(string hospitalId);
    }
}
