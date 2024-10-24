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
        void Save();
    }
}
