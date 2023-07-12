using MedicineProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Hospital> Hospital { get; set; }

        public DbSet<Illness> Illness { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<RiskFactor> RiskFactor { get; set; }

        public DbSet<Speciality> Speciality { get;  set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) 
        { 
        }
    }
}
