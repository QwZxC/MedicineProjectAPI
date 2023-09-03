using AutoMapper;
using MedicineProject.Domain.Context;
using MedicineProject.Controllers.Base;
using MedicineProject.Domain.DTOs;
using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MedicineProject.Domain.Services;
using System.Collections.Generic;

namespace MedicineProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : BaseController
    {
        private readonly IPlaceService _placeService;
        public PlacesController(WebMobileContext context, IMapper mapper, 
                                IMemoryCache memoryCache, IPlaceService placeService) 
            : base(context, mapper, memoryCache)
        {
            _placeService = placeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountyDTO>))]
        public async Task<ActionResult<List<CountyDTO>>> GetPlaces()
        {
            List<CountyDTO> counties;
            if (cache.TryGetValue(0, out  counties))
            {
                return Ok(counties);
            }
            counties = new List<CountyDTO>();

            List<County> countiesFromDb = await _placeService.GetPlacesAsync();

            countiesFromDb.ForEach(county =>
            {
                CountyDTO dto = mapper.Map<CountyDTO>(county);
                dto.RegionDTOs = MapObjects<Region, RegionDTO>(county.Regions);
                dto.RegionDTOs.ForEach(region => 
                {
                    region.Cities = MapObjects<City, CityDTO>(county.Regions.FirstOrDefault(dbRegion => 
                                                                        dbRegion.Id == region.Id).Cities);
                });
                counties.Add(dto);
            });

            cache.Set(0, counties);

            return Ok(counties);
        }
    }
}

