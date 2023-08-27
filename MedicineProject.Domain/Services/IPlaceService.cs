using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Services
{
    public interface IPlaceService
    {
        Task<List<County>> GetPlacesAsync();
    }
}
