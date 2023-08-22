using MedicineProject.Domain.DTOs.Base;
using MedicineProject.Domain.Models.WebMobile;
using System.ComponentModel.DataAnnotations;

namespace MedicineProject.Domain.DTOs
{
    public record HospitalDTO : BaseDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public TimeOnly StartedTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public string Contacts { get; set; }

        public byte Rating { get; set; }

        [Required]
        public string Email { get; set; }

        public List<DoctorDTO> Doctors { get; set; }

        [Required]
        public long CityId { get; set; }

        public HospitalDTO() { }

        public HospitalDTO(Hospital hospital)
        {
            Id = hospital.Id;
            Name = hospital.Name;
            Description = hospital.Description;
            Address = hospital.Address;
            StartedTime = hospital.StartedTime;
            EndTime = hospital.EndTime;
            Rating = hospital.Rating;
            Email = hospital.Email;
            CityId = hospital.CityId;
        }
    }
}
