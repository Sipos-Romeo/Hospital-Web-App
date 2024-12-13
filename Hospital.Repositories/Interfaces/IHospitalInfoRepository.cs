using Hospital.Models;
using Hospital.Web.Repositories.Interfaces;

namespace Hospital.Repositories.Interfaces
{
    public interface IHospitalInfoRepository : IRepositoryBase<HospitalInfo>
    {
        new void Create(HospitalInfo hospitalInfo);
        HospitalInfo GetHospitalById(int id);
        new void Update(HospitalInfo hospitalInfo);
    }
}
