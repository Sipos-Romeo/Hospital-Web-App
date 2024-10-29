using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repositories
{
    public class HospitalInfoRepository : RepositoryBase<HospitalInfo>, IHospitalInfoRepository
    {
        private object _hospitalInfoRepository;

        public HospitalInfoRepository(HospitalAppDbContext hospitalAppDbContext) : base(hospitalAppDbContext)
        {
        }

        public HospitalInfo GetHospitalById(int id)
        {
            return _hospitalAppDbContext.HospitalInfo.Where(c => c.Id == id).FirstOrDefault() ?? new HospitalInfo();
        }

        public IHospitalInfoRepository GetHospitalInfoRepository()
        {
            if (_hospitalInfoRepository == null)
            {
                _hospitalInfoRepository = new HospitalInfoRepository(_hospitalAppDbContext);
            }
            return (IHospitalInfoRepository)_hospitalInfoRepository;
        }
    }
}
