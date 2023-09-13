using AutoMapper;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.Base;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Repositories;
using MedicineProject.Domain.Services;

namespace MedicineProject.Core.Service
{
    /// <summary>
    /// Сервис для работы с заявками.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper mapper;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            _repository = repository;
        }

        public async Task<AppointmentDTO> CreateAsync(AppointmentDTO appointment)
        {
            Appointment appointmentToDb = mapper.Map<Appointment>(appointment);

            await _repository.CreateItemAsync(appointmentToDb);

            appointment.Id = appointmentToDb.Id;

            return appointment;
        }

        public async Task<TModel> TryGetItemByIdAsync<TModel>(long id)
            where TModel : BaseModel
        {
            return await _repository.TryGetItemByIdAsync<TModel>(id);
        }
    }
}
