using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Repositories
{
    public class HospitalAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public HospitalAppDbContext(DbContextOptions<HospitalAppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<HospitalInfo>? HospitalInfo { get; set; }
        public DbSet<Appointment>? Appointments { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<FeedbackForm>? FeedbackForms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships
            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.AppointmentsAsDoctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.AppointmentsAsPatient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
