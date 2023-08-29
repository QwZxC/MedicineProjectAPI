using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Services
{
    public interface IPlaceService
    {
        /// <summary>
        /// Возвращает список округов.
        /// </summary>
        /// <returns></returns>
        Task<List<County>> GetPlacesAsync();
    }
}
