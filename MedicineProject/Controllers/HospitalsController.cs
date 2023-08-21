using AutoMapper;
using MedicineProject.Context;
using MedicineProject.Controllers.Base;
using MedicineProject.DTOs;
using MedicineProject.Filters;
using MedicineProject.Models.WebMobileModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : BaseController
    {
        public HospitalsController(WebMobileContext context, IMapper mapper, IMemoryCache memoryCache) 
            : base(context, mapper, memoryCache)
        {

        }

        [HttpGet("GetAllHospitals")]
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

        [HttpPost("AddHospital")]
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

            await mobileAndWebRepository.SaveAsync();

            return Ok(hospitalDTO);
        }

        [HttpPut("UpdateHospital")]
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

            await mobileAndWebRepository.SaveAsync();

            return Ok(hospitalDTO);
        }
    }
}
