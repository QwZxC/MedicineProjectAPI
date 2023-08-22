using MedicineProject.Domain.Models.WebMobile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Domain.Context
{
    public sealed class WebMobileContext : IdentityDbContext<Patient, IdentityRole<long>, long>
    {
        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Hospital> Hospital { get; set; }

        public DbSet<Speciality> Speciality { get;  set; }

        public DbSet<City> City { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<County> County { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public WebMobileContext(DbContextOptions<WebMobileContext> options) 
            : base(options) 
        {
        }
    }
}
