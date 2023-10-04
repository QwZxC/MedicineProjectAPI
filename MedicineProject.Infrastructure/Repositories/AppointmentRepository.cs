using MedicineProject.Domain.Context;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Repositories;

namespace MedicineProject.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(WebMobileContext context) : base(context) 
        { 
        }

        public async void DeleteTasks(List<Appointment> appointments)
        {
            appointments.ForEach(appointment =>
            {
                _context.Appointment.Remove(appointment);
            });
            await SaveChangesAsync();
        }
    }
}
