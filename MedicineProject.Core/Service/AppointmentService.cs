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

        public async Task UpdateTasksAsync()
        {
            List<Appointment> appointments = await _repository.GetItemListAsync<Appointment>();
            DeleteTasks(appointments);
            CreateTasks();
        }

        private async void CreateTasks()
        {
            List<Doctor> doctors = await _repository.GetItemListAsync<Doctor>();

            doctors.ForEach(doctor =>
            {
                for (int i = 0; i < 7; i++)
                {
                    doctor.Appointments.Add(new Appointment() 
                    { 
                        Doctor = doctor,
                        DoctorId = doctor.Id,
                        Date = DateTime.Now.AddDays(7)
                    });
                }
            });
            await _repository.SaveChangesAsync();
        }


        private void DeleteTasks(List<Appointment> appointments)
        {
            List<Appointment> appointmentsToRemove = new List<Appointment>();

            appointments.ForEach(appointment =>
            {
                if (appointment.Date < DateTime.Now)
                {
                    appointmentsToRemove.Add(appointment);
                }
            });

            _repository.DeleteTasks(appointmentsToRemove);

            appointmentsToRemove.ForEach(appointment => appointments.Remove(appointment));
        }
    }
}
