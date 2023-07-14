using AutoMapper;
using MedicineProject.Context;
using MedicineProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetAllHospitals(string name = "", int minRating = 0, int maxRating = 5)
        {
            List<HospitalDTO> hospitals = new List<HospitalDTO>();
            context.Hospital.ToList().ForEach(hospital =>
            {
               if (hospital.Name.Contains(name) && hospital.Rating >= minRating && hospital.Rating <= maxRating)
               {
                    hospitals.Add(mapper.Map<HospitalDTO>(hospital));
               }
            });
            return Ok(hospitals);
        }
    }
}
