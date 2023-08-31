using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Filters;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Services
{
    public interface IHospitalService
    {
        /// <summary>
        /// Осуществляет поиск списка больниц по подходящим по Get-параметрам.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<Hospital>> GetHospitalsWithFilterAsync(HospitalFilter filter);

        /// <summary>
        /// Осуществляет поиск больницы по её id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Hospital> GetHospitalByIdAsync(long id);

        /// <summary>
        /// Добавляет запись больницы в бд.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<HospitalDTO> AddHospitalAsync(HospitalDTO dto);

        /// <summary>
        /// Обнавляет запись больницы в бд.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="hospital"></param>
        /// <returns></returns>
        Task<HospitalDTO> UpdateHospitalAsync(HospitalDTO dto, Hospital hospital);

        /// <summary>
        /// Осуществляет поиск больницы по её названию.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Hospital> GetHospitalByNameAsync(string name);
    }
}
