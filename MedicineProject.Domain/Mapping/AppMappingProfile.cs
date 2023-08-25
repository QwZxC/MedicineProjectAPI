using AutoMapper;
using MedicineProject.Domain.DTOs;
using MedicineProject.Domain.DTOs.Desktop;
using MedicineProject.Domain.DTOs.WebMobile;
using MedicineProject.Domain.Models.DesktopModels;
using MedicineProject.Domain.Models.WebMobile;

namespace MedicineProject.Domain.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<MedicineProject.Domain.Models.WebMobile.Patient, PatientDTO>().ReverseMap();
            CreateMap<Illness, IllnessDTO>().ReverseMap();
            CreateMap<RiskFactor, RiskFactorDTO>().ReverseMap();
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
            CreateMap<MedicineProject.Domain.Models.WebMobile.Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<County, CountyDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
