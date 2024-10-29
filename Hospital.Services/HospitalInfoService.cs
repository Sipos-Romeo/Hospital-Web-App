﻿using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class HospitalInfoService : IHospitalInfoService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public HospitalInfoService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateHospitalInfo(HospitalInfo hospitalInfo)
        {
            _repositoryWrapper.HospitalInfoRepository.Create(hospitalInfo);
            _repositoryWrapper.Save();
        }

        public void DeleteHospitalInfo(HospitalInfo hospitalInfo)
        {
            _repositoryWrapper.HospitalInfoRepository.Delete(hospitalInfo);
            _repositoryWrapper.Save();
        }

        public void DeleteItem(string? v)
        {
            throw new NotImplementedException();
        }

        public List<HospitalInfo> GetAllHospitalInfo()
        {
            return _repositoryWrapper.HospitalInfoRepository.FindAll().ToList();
        }

        public HospitalInfo GetHospitalInfoById(int id)
        {
            return _repositoryWrapper.HospitalInfoRepository.GetHospitalById(id);
        }

        public void UpdateHospitalInfo(HospitalInfo hospitalInfo)
        {
            _repositoryWrapper.HospitalInfoRepository.Update(hospitalInfo);
            _repositoryWrapper.Save();
        }
    }
}
