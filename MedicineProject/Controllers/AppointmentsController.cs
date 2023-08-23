using AutoMapper;
using MedicineProject.Controllers.Base;
using MedicineProject.Domain.Context;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController
    {
        public AppointmentsController(WebMobileContext context, IMapper mapper, IMemoryCache memoryCache)
            : base(context, mapper, memoryCache)
        {

        }

        [HttpPut("SendAppointment")]
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

            Appointment appointmentToDb = mapper.Map<Appointment>(appointment);

            await mobileAndWebRepository.CreateItemAsync(appointmentToDb);

            await mobileAndWebRepository.SaveAsync();

            return Ok();
        }
    }
}
