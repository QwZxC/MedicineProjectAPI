using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Services
{
    public interface IAppointmentService
    {
        /// <summary>
        /// Создаёт заявку.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        Task<AppointmentDTO> CreateAsync(AppointmentDTO appointment);
        
        Task<TModel> TryGetItemByIdAsync<TModel>(long id) where TModel : BaseModel;

        Task UpdateTasksAsync();
    }
}
