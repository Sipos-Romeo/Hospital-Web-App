using Hospital.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private HospitalAppDbContext _hospitalAppDbContext;

        public RepositoryWrapper(HospitalAppDbContext hospitalAppDbContext)
        {
            _hospitalAppDbContext = hospitalAppDbContext;
        }

        public void Save()
        {
            _hospitalAppDbContext.SaveChanges();
        }

        private IHospitalInfoRepository _hospitalInfoRepository;
        public IHospitalInfoRepository HospitalInfoRepository
        {
            get
            {
                if (_hospitalInfoRepository == null)
                {
                    _hospitalInfoRepository = new HospitalInfoRepository(_hospitalAppDbContext);
                }
                return _hospitalInfoRepository;
            }
        }
        private IAppointmentRepository _appointmentRepository;
        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                if (_appointmentRepository == null)
                {
                    _appointmentRepository = new AppointmentRepository(_hospitalAppDbContext);
                }
                return _appointmentRepository;
            }
        }

        private IContactRepository _contactRepository;
        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new ContactRepository(_hospitalAppDbContext);
                }
                return _contactRepository;
            }
        }
        private IDeparmentRepository _deparmentRepository;
        public IDeparmentRepository DeparmentRepository
        {
            get
            {
                if (_deparmentRepository == null)
                {
                    _deparmentRepository = new DepartmentRepository(_hospitalAppDbContext);
                }
                return _deparmentRepository;
            }
        }
        private IFeedbackFormRepository _feedbackFormRepository;
        public IFeedbackFormRepository FeedbackFormRepository
        {
            get
            {
                if (_feedbackFormRepository == null)
                {
                    _feedbackFormRepository = new FeedbackFormRepository(_hospitalAppDbContext);
                }
                return _feedbackFormRepository;
            }
        }
        private IRoomRepository _roomRepository;
        public IRoomRepository RoomRepository
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new RoomRepository(_hospitalAppDbContext);
                }
                return _roomRepository;
            }
        }



    }
}
