using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IHospitalInfoRepository HospitalInfoRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IContactRepository ContactRepository { get; }
        IDeparmentRepository DeparmentRepository { get; }
        IFeedbackFormRepository FeedbackFormRepository { get; }
        IRoomRepository RoomRepository { get; }
        void Save();

    }
}
