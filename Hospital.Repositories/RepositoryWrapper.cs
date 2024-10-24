using Hospital.Repositories.Interfaces;
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

    }
}
