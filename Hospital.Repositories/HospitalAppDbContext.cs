using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Repositories
{
    public class HospitalAppDbContext : IdentityDbContext
    {
        public HospitalAppDbContext(DbContextOptions<HospitalAppDbContext> options) : base(options) { }

        public DbSet<HospitalInfo> HospitalInfo { get; set;}
        public DbSet<Appointment> Appointments { get; set;}
        public DbSet<Contact> Contacts { get; set;}
        public DbSet<Department> Departments { get; set;}
        public DbSet<FeedbackForm> FeedbackForms { get; set;}
        public DbSet<Room> Rooms { get; set;}

    }
    
}
