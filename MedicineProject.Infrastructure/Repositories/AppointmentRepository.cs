using MedicineProject.Domain.Context;
using MedicineProject.Domain.Repositories;

namespace MedicineProject.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(WebMobileContext context) : base(context) 
        { 
        }
    }
}
