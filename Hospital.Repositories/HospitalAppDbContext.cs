using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;

namespace Hospital.Repositories
{
    public class HospitalAppDbContext : IdentityDbContext
    {
        public HospitalAppDbContext(DbContextOptions<HospitalAppDbContext> options) : base(options) { }

        public DbSet<HospitalInfo> HospitalInfo { get; set;}
    }
    
}
