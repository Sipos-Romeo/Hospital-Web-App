using Hospital.Models;
using Hospital.Web.Repositories.Interfaces;

namespace Hospital.Repositories.Interfaces
{
    public interface IHospitalInfoRepository : IRepositoryBase<HospitalInfo>
    {
        void Create(HospitalInfo hospitalInfo);
        HospitalInfo GetHospitalById(int id);
        void Update(HospitalInfo hospitalInfo);
    }
}
