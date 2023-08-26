using AutoMapper;
using MedicineProject.Domain.Context;
using MedicineProject.Controllers.Base;
using MedicineProject.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.DTOs.WebMobile;

namespace MedicineProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalsController : BaseController
    {
        public HospitalsController(WebMobileContext context, IMapper mapper, IMemoryCache memoryCache) 
            : base(context, mapper, memoryCache)
        {

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<HospitalDTO>>> GetAllHospitals([FromQuery] HospitalFilter filter)
        {
            List<Hospital> hospitals = await mobileAndWebRepository.GetHospitalsWithFilterAsync(filter);
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

            targetHospital = await mobileAndWebRepository.TryGetItemByIdAsync<Hospital>(id);

            if (targetHospital == null)
            {
                return NotFound("Такой больницы нет в списке");
            }

            targetHospital.Doctors = await mobileAndWebRepository.LoadDoctorsForHospitalAsync(id);

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

            if (await mobileAndWebRepository.TryGetItemByNameAsync<Hospital>(hospitalDTO.Name) != null)
            {
                return BadRequest("Больница с таким названием уже есть в списке");
            }

            await mobileAndWebRepository.CreateItemAsync(mapper.Map<Hospital>(hospitalDTO));

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
            Hospital oldHospital = await mobileAndWebRepository.TryGetItemByIdAsync<Hospital>(hospitalDTO.Id);

            if (oldHospital == null)
            {
                return NotFound("Такой больницы нет.");
            }
            
            oldHospital.Name = hospitalDTO.Name;
            oldHospital.Description = hospitalDTO.Description;
            oldHospital.StartedTime = hospitalDTO.StartedTime;
            oldHospital.EndTime = hospitalDTO.EndTime;
            oldHospital.CityId = hospitalDTO.CityId;
            oldHospital.Rating = hospitalDTO.Rating;
            oldHospital.Address = hospitalDTO.Address;
            oldHospital.Doctors = MapObjects<DoctorDTO, Doctor>(hospitalDTO.Doctors);

            mobileAndWebRepository.UpdateItemAsync(mapper.Map<Hospital>(hospitalDTO), oldHospital);

            return Ok(hospitalDTO);
        }
    }
}
