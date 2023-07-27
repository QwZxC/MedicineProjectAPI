using AutoMapper;
using MedicineProject.Context;
using MedicineProject.DTOs;
using MedicineProject.Filters;
using MedicineProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public HospitalsController(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetHospitals")]
        public async Task<ActionResult<List<HospitalDTO>>> GetAllHospitals([FromQuery] HospitalFilter filter)
        {
            List<HospitalDTO> hospitals = new List<HospitalDTO>();
            
            City targetCity = await context.City.FindAsync(filter.CityId);
            if (targetCity == null) 
            {
                return BadRequest("Неверный городо");
            }
            
            await context.Hospital.ForEachAsync(hospital =>
            {
               if (hospital.Name.Contains(filter.Name) && hospital.Rating >= filter.MinRating && hospital.Rating <= filter.MaxRating && hospital.CityId == targetCity.Id)
               {
                    hospitals.Add(mapper.Map<HospitalDTO>(hospital));
               }
            });
            return Ok(hospitals);
        }

        [HttpGet]
        [Route("GetHospitals/{id:int}")]
        public async Task<ActionResult> GetHospitalById(long id)
        {
            if (id <= 0)
            {
                return BadRequest("Невозможный id");
            }
            HospitalDTO hospital = mapper.Map<HospitalDTO>(await context.Hospital.FindAsync(id));
            
            if (hospital == null)
            {
                return NotFound("Такой больницы нет");
            }

            return Ok(hospital);
        }
    }
}
