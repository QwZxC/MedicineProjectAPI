using AutoMapper;
using MedicineProject.Controllers.Base;
using MedicineProject.Domain.Context;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService appointmentService;
        public AppointmentsController(WebMobileContext context, IMapper mapper, 
                                      IMemoryCache memoryCache, IAppointmentService appointmentService)
            : base(context, mapper, memoryCache)
        {
            this.appointmentService = appointmentService;
        }

        [HttpPut("appointment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SendAppointment([FromBody] AppointmentDTO appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }

            Doctor doctor = await mobileAndWebRepository.TryGetItemByIdAsync<Doctor>(appointment.DoctorId);
            if (doctor == null)
            {
                return NotFound("Доктор не найден");
            }

            await appointmentService.CreateAsync(appointment);

            return Ok(appointment);
        }
    }
}
