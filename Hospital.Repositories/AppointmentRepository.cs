using Hospital.Models;
using Hospital.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hospital.Repositories
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HospitalAppDbContext hospitalAppDbContext) : base(hospitalAppDbContext)
        {
        }
        public Appointment GetAppointmentById(int id)
        {
            return _hospitalAppDbContext.Appointments?.Where(c => c.Id == id).FirstOrDefault() ?? new Appointment();
        }

    }
}