using MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Context
{
    public class MedicalContext : DbContext
    {
        public MedicalContext(DbContextOptions<MedicalContext> options)
            : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Speciality> Speciality { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
