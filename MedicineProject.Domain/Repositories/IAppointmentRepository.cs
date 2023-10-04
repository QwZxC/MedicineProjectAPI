using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Repositories
{
    public interface IAppointmentRepository : IBaseRepository
    {
        void DeleteTasks(List<Appointment> appointments);
    }
}
