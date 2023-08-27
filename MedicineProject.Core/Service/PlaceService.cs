using MedicineProject.Domain.Context;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Services;
using MedicineProject.Infrastructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Core.Service
{
    public class PlaceService : IPlaceService
    {

        private readonly MobileAndWebRepository _repository;

        public PlaceService(WebMobileContext context) 
        {
            _repository = new MobileAndWebRepository(context);
        }

        public async Task<List<County>> GetPlacesAsync()
        {
            List<County> counties = await _repository.GetItemListAsync<County>();
            await LoadRegion(counties);
            counties.ForEach(county => LoadCities(county.Regions));
            return counties;
        }

        private async Task LoadRegion(List<County> counties)
        {
            List<Region> regions = await _repository.GetItemListAsync<Region>();
            counties.ForEach(county =>
            {
                List<Region> countyRegions = regions.ToList().FindAll(region => county.Id == region.CountyId);
                county.Regions.AddRange(countyRegions);
            });
        }

        private void LoadCities(List<Region> regions)
        {
            List<City> cities = _repository.GetItems<City>().ToList();
            regions.ForEach(region =>
            {
                region.Cities = cities.FindAll(city => city.RegionId == region.Id);
            });
        }
    }
}
