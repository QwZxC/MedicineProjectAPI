﻿using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Models.WebMobile
{
    public class Hospital : BaseModel
    {
        public string Description { get; set; }

        public string Address { get; set; }

        public TimeOnly StartedTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string Contacts { get; set; }

        public byte Rating { get; set; }

        public string Email { get; set; }

        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        public long CityId { get; set; }

        public City City { get; set; }

        public Hospital() { }
    }
}
