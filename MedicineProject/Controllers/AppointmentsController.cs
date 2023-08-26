using AutoMapper;
using MedicineProject.Controllers.Base;
using MedicineProject.Domain.Context;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentService;
        private readonly UserManager<Patient> userManager;
        public AppointmentsController(UserManager<Patient> userManager, WebMobileContext context, IMapper mapper,
                                      IMemoryCache memoryCache, IAppointmentService appointmentService)
            : base(context, mapper, memoryCache)
        {
            this.userManager = userManager;
            this.appointmentService = appointmentService;
        }

        [HttpPost("appointment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SendAppointment([FromBody] AppointmentDTO appointment)
        {
            var doctor = await mobileAndWebRepository.TryGetItemByIdAsync<Doctor>(appointment.DoctorId);
            var patient = await userManager.FindByIdAsync(appointment.PatientId.ToString());
            var type = await mobileAndWebRepository.TryGetItemByIdAsync<Domain.Models.WebMobile.Type>(appointment.TypeId);

            if (doctor == null || patient == null || type == null)
            {
                return NotFound();
            }

            await appointmentService.CreateAsync(appointment);

            return Ok(appointment);
        }
    }
}
