using AutoMapper;
using MedicineProject.Context;
using MedicineProject.DTOs;
using MedicineProject.Filters;
using MedicineProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public HospitalsController(ApplicationContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            this.context = context;
            this.mapper = mapper;
            cache = memoryCache;
        }

        [HttpGet]
        [Route("GetHospitals")]
        public async Task<ActionResult<List<HospitalDTO>>> GetAllHospitals([FromQuery] HospitalFilter filter)
        {
            List<HospitalDTO> hospitals;
            
            City targetCity = await context.City.FindAsync(filter.CityId);
            if (targetCity == null) 
            {
                return BadRequest("Неверный городо");
            }
            
            if (filter.Name == string.Empty && filter.MinRating == 0 && filter.MaxRating == 5 && cache.TryGetValue(filter.CityId, out hospitals))
            {
                return Ok(hospitals);
            }
            hospitals = new List<HospitalDTO>();

            await context.Hospital.ForEachAsync(hospital =>
            {
               if (hospital.Name.Contains(filter.Name) && hospital.Rating >= filter.MinRating && hospital.Rating <= filter.MaxRating && hospital.CityId == targetCity.Id)
               {
                    hospitals.Add(mapper.Map<HospitalDTO>(hospital));
               }
            });
            cache.Set(filter.CityId, hospitals);

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
