using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repositories
{
    public class HospitalInfoRepository : RepositoryBase<HospitalInfo>, IHospitalInfoRepository
    {
        public HospitalInfoRepository(HospitalAppDbContext hospitalAppDbContext) : base(hospitalAppDbContext)
        {
        }

        public HospitalInfo GetHospitalById(int id)
        {
            return _hospitalAppDbContext.HospitalInfo.Where(c => c.Id == id).FirstOrDefault() ?? new HospitalInfo();
        }
    }
}
