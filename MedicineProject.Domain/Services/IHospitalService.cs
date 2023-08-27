using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Filters;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Services
{
    public interface IHospitalService
    {
        Task<List<Hospital>> GetHospitalsWithFilterAsync(HospitalFilter filter);

        Task<Hospital> GetHospitalByIdAsync(long id);

        Task<HospitalDTO> AddHospitalAsync(HospitalDTO dto);

        Task<HospitalDTO> UpdateHospitalAsync(HospitalDTO dto, Hospital hospital);

        Task<Hospital> GetHospitalByNameAsync(string name);
    }
}
