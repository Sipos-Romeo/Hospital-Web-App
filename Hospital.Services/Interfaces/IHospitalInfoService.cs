using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interfaces
{
    public interface IHospitalInfoService
    {
        void CreateHospitalInfo(HospitalInfo hospitalInfo);
        void UpdateHospitalInfo(HospitalInfo hospitalInfo);
        void DeleteHospitalInfo(HospitalInfo hospitalInfo);
        HospitalInfo GetHospitalInfoById(int id);
        List<HospitalInfo> GetAllHospitalInfo();
    }
}
