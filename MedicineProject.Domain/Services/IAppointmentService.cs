using MedicineProject.Domain.DTOs.WebMobile;

namespace MedicineProject.Domain.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> CreateAsync(AppointmentDTO appointment);
    }
}
