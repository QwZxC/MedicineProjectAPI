using MedicineProject.Models;
using MedicineProject.Models.WebMobileModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Context
{
    public sealed class WebMobileContext : IdentityDbContext<Models.Patient, IdentityRole<long>, long>
    {
        public DbSet<Models.WebMobileModels.Doctor> Doctor { get; set; }

        public DbSet<Hospital> Hospital { get; set; }

        public DbSet<Speciality> Speciality { get;  set; }

        public DbSet<City> City { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<County> County { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Models.Patient> Patient { get; set; }

        public WebMobileContext(DbContextOptions<WebMobileContext> options) 
            : base(options) 
        {
        }
    }
}
