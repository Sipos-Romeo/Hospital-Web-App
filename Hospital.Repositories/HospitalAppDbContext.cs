using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Repositories
{
    public class HospitalAppDbContext : IdentityDbContext
    {
        public HospitalAppDbContext(DbContextOptions<HospitalAppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser>? ApplicationUsers{ get; set;}
        public DbSet<HospitalInfo>? HospitalInfo { get; set;}
        public DbSet<Appointment>? Appointments { get; set;}
        public DbSet<Contact>? Contacts { get; set;}
        public DbSet<Department>? Departments { get; set;}
        public DbSet<FeedbackForm>? FeedbackForms { get; set;}
        public DbSet<Room>? Rooms { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure AppointmentsAsDoctor relationship
            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.AppointmentsAsDoctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure AppointmentsAsPatient relationship
            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.AppointmentsAsPatient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
