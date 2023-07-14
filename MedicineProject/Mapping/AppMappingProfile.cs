using AutoMapper;
using MedicineProject.DTOs;
using MedicineProject.Models;

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
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
        }
    }
}
