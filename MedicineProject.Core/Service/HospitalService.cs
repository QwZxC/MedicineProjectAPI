using AutoMapper;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Filters;
using MedicineProject.Domain.Models.WebMobile;
using MedicineProject.Domain.Services;
using MedicineProject.Infrastructure.Repositories;

namespace MedicineProject.Core.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly MobileAndWebRepository _repository;
        private readonly IMapper _mapper;

        public HospitalService(MobileAndWebRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HospitalDTO> AddHospitalAsync(HospitalDTO dto)
        {
            Hospital hospital = _mapper.Map<Hospital>(dto);
            await _repository.CreateItemAsync(hospital);
            dto.Id = hospital.Id;
            return dto;
        }

        public async Task<Hospital> GetHospitalByNameAsync(string name)
        {
            return await _repository.TryGetItemByNameAsync<Hospital>(name);
        }

        public async Task<Hospital> GetHospitalByIdAsync(long id)
        {
            Hospital hospital = await _repository.TryGetItemByIdAsync<Hospital>(id);
            if (hospital == null)
            {
                return null;
            }
            
            hospital.Doctors = await _repository.LoadDoctorsForHospitalAsync(id);
            
            return hospital;
        }

        public async Task<List<Hospital>> GetHospitalsWithFilterAsync(HospitalFilter filter)
        {
            List<Hospital> dbHospitals = await _repository.GetItemListAsync<Hospital>();
            List<Hospital> hospitals = new List<Hospital>();
            dbHospitals.ForEach(hospital =>
            {
                if (hospital.Name.Contains(filter.Name) &&
                    hospital.CityId == filter.CityId &&
                    hospital.Rating >= filter.MinRating &&
                    hospital.Rating <= filter.MaxRating)
                {
                    hospitals.Add(hospital);
                }
            });
            return hospitals;
        }

        public async Task<HospitalDTO> UpdateHospitalAsync(HospitalDTO dto, Hospital hospital)
        {
            hospital.Name = dto.Name;
            hospital.Description = dto.Description;
            hospital.StartedTime = dto.StartedTime;
            hospital.EndTime = dto.EndTime;
            hospital.CityId = dto.CityId;
            hospital.Rating = dto.Rating;
            hospital.Address = dto.Address;
            await _repository.UpdateItemAsync(_mapper.Map<Hospital>(dto),hospital);
            return dto;
        }
    }
}
