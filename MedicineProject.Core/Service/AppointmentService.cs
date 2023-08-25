using AutoMapper;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Repositories;
using MedicineProject.Domain.Services;

namespace MedicineProject.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMobileAndWebRepository mobileAndWebRepository;
        private readonly IMapper mapper;

        public AppointmentService(IMobileAndWebRepository mobileAndWebRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.mobileAndWebRepository = mobileAndWebRepository;
        }

        public async Task<AppointmentDTO> CreateAsync(AppointmentDTO appointment)
        {
            Appointment appointmentToDb = mapper.Map<Appointment>(appointment);

            await mobileAndWebRepository.CreateItemAsync(appointmentToDb);
            await mobileAndWebRepository.SaveAsync();

            appointment.Id = appointmentToDb.Id;

            return appointment;
        }
    }
}
