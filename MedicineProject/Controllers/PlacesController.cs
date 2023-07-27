using AutoMapper;
using MedicineProject.Context;
using MedicineProject.DTOs;
using MedicineProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;

        public PlacesController(ApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            LoadCities();
            LoadRegion();
        }

        [HttpGet("GetPlaces")]
        public async Task<ActionResult<List<RegionDTO>>> GetPlaces()
        {
            List<CountyDTO> counties = await context.County.Select(region => mapper.Map<CountyDTO>(region)).ToListAsync();
            counties.ForEach(county =>
            {
                county.RegionDTOs = MapObjects<Region, RegionDTO>(context.County.FindAsync(county.Id).Result.Regions);
                county.RegionDTOs.ForEach(region =>
                {
                    region.Cities = MapObjects<City, CityDTO>(context.Region.FindAsync(region.Id).Result.Cities);
                    region.Cities.ForEach(city => city.Hospitals = MapObjects<Hospital, HospitalDTO>(context.City.Include(city => city.Hospitals)
                                                                            .FirstOrDefaultAsync(dbCity => dbCity.Id == city.Id).Result.Hospitals));
                });
            });
            return Ok(counties);
        }


        private List<DTO> MapObjects<original, DTO>(List<original> items)
        {
            List<DTO> DTOs = new List<DTO>();
            items.ForEach(region => DTOs.Add(mapper.Map<DTO>(region)));
            return DTOs;
        }


        private void LoadRegion()
        {
            context.County.ToList().ForEach(county => 
            {
                List<Region> regions = context.Region.ToList().FindAll(region => county.Id == region.CountyId);
                county.Regions.AddRange(regions);
            });
        }

        private void LoadCities()
        {
            context.Region.ToList().ForEach(region =>
            {
                List<City> regions = context.City.ToList().FindAll(city => region.Id == city.RegionId);
                region.Cities.AddRange(regions);
            });
        }
    }
}
