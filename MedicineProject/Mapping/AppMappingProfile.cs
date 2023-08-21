﻿using AutoMapper;
using MedicineProject.DTOs;
using MedicineProject.Models.DesktopModels;
using MedicineProject.Models.WebMobileModels;

namespace MedicineProject.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Illness, IllnessDTO>().ReverseMap();
            CreateMap<RiskFactor, RiskFactorDTO>().ReverseMap();
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Speciality, SpecialityDTO>().ReverseMap();
            CreateMap<MedicineProject.Models.WebMobileModels.Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<County, CountyDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
