using MedicineProject.Domain.DTOs.WebMobile;

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
    }
}
