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
            CreateMap<MedicineProject.Domain.Models.WebMobile.Patient, DTOs.WebMobile.PatientDTO>().ReverseMap();
            CreateMap<Illness, IllnessDTO>().ReverseMap();
            CreateMap<RiskFactor, RiskFactorDTO>().ReverseMap();
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
            CreateMap<Doctor, DTOs.WebMobile.DoctorDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<County, CountyDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Models.WebMobile.Type, TypeDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
        }
    }
}
