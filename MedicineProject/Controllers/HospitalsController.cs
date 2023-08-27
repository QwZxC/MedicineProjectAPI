using AutoMapper;
using MedicineProject.Domain.Context;
using MedicineProject.Controllers.Base;
using MedicineProject.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Services;

namespace MedicineProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController : BaseController
    {
        private readonly IHospitalService _service;

        public HospitalsController(IHospitalService service,WebMobileContext context, IMapper mapper, IMemoryCache memoryCache) 
            : base(context, mapper, memoryCache)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<HospitalDTO>>> GetAllHospitals([FromQuery] HospitalFilter filter)
        {
            List<Hospital> hospitals = await _service.GetHospitalsWithFilterAsync(filter);
            List<HospitalDTO> hospitalsDTOs = new List<HospitalDTO>();

            hospitals.ForEach(hospital => 
            {
                HospitalDTO hospitalDTO = mapper.Map<HospitalDTO>(hospital);
                hospitalDTO.Doctors = MapObjects<Doctor, DoctorDTO>(hospital.Doctors);
                hospitalsDTOs.Add(hospitalDTO);
            });

            return Ok(hospitalsDTOs);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDTO>> GetHospital([FromRoute] long id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (!cache.TryGetValue(id, out Hospital targetHospital))
            {
                return Ok(targetHospital);
            }

            targetHospital = await _service.GetHospitalByIdAsync(id);

            if (targetHospital == null)
            {
                return NotFound("Такой больницы нет в списке");
            }

            HospitalDTO hospitalDTO = mapper.Map<HospitalDTO>(targetHospital);
            hospitalDTO.Doctors = MapObjects<Doctor, DoctorDTO>(targetHospital.Doctors);
            
            cache.Set(id, hospitalDTO);

            return Ok(hospitalDTO);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDTO>> AddHospital([FromBody] HospitalDTO hospitalDTO)
        {
            if (hospitalDTO == null) 
            {
                return BadRequest();
            }

            if (await _service.GetHospitalByNameAsync(hospitalDTO.Name) != null)
            {
                return BadRequest("Больница с таким названием уже есть в списке");
            }

            await _service.AddHospitalAsync(hospitalDTO);

            return Ok(hospitalDTO);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDTO>> UpdateHospital([FromBody] HospitalDTO hospitalDTO)
        {
            if (hospitalDTO == null)
            {
                return BadRequest();
            }
            Hospital oldHospital = await _service.GetHospitalByIdAsync(hospitalDTO.Id);

            if (oldHospital == null)
            {
                return NotFound("Такой больницы нет.");
            }

            oldHospital.Doctors = MapObjects<DoctorDTO, Doctor>(hospitalDTO.Doctors);
            await _service.UpdateHospitalAsync(hospitalDTO, oldHospital);

            return Ok(hospitalDTO);
        }
    }
}
