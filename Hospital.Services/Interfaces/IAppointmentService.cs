using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interfaces
{
    public interface IAppointmentService
    {
            void CreateAppointment(Appointment appointment);
            void UpdateAppointment(Appointment appointment);
            void DeleteAppointment(Appointment appointment);
            Appointment GetAppointmentById(int id);
            List<Appointment> GetAllAppointment();
        
    }
}
