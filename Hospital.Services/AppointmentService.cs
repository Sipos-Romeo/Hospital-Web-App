using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public AppointmentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateAppointment(Appointment appointment)
        {
            _repositoryWrapper.AppointmentRepository.Create(appointment);
            _repositoryWrapper.Save();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _repositoryWrapper.AppointmentRepository.Delete(appointment);
            _repositoryWrapper.Save();
        }

        public List<Appointment> GetAllAppointment()
        {
            return _repositoryWrapper.AppointmentRepository.FindAll().ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _repositoryWrapper.AppointmentRepository.GetAppointmentById(id);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _repositoryWrapper.AppointmentRepository.Update(appointment);
            _repositoryWrapper.Save();
        }
    }
}
