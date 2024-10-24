using Hospital.Models;
using Hospital.Web.Repositories.Interfaces;

namespace Hospital.Repositories.Interfaces
{
    public interface IHospitalInfoRepository : IRepositoryBase<HospitalInfo>
    {
        HospitalInfo GetHospitalById(int id);
    }
}
