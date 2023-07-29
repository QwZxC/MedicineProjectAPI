using AutoMapper;
using MedicineProject.Context;
using MedicineProject.DTOs;
using MedicineProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public PlacesController(ApplicationContext context, IMapper mapper, IMemoryCache memoryCache)
        {
            this.context = context;
            this.mapper = mapper;
            cache = memoryCache;
        }

        [HttpGet("GetPlaces")]
        public async Task<ActionResult<List<RegionDTO>>> GetPlaces()
        {
            List<CountyDTO> counties;
            if (cache.TryGetValue(0, out counties))
            {
                return Ok(counties);
            }
            LoadCities();
            LoadRegion();

            counties = await context.County.Select(region => mapper.Map<CountyDTO>(region)).ToListAsync();
            counties.ForEach(county =>
            {
                county.RegionDTOs = MapObjects<Region, RegionDTO>(context.County.Find(county.Id).Regions);
                county.RegionDTOs.ForEach(region => region.Cities = MapObjects<City, CityDTO>(context.Region.Find(region.Id).Cities));
            });

            cache.Set(0,counties);

            return Ok(counties);
        }

        private List<DTO> MapObjects<ORIGINAL, DTO>(List<ORIGINAL> items)
        {
            List<DTO> DTOs = new List<DTO>();
            items.ForEach(item => DTOs.Add(mapper.Map<DTO>(item)));
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
                region.Cities = context.City.ToList().FindAll(city => city.RegionId == region.Id);
            });
        }
    }
}

