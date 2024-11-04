using Hospital.Models;
using Hospital.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Interfaces
{
    public interface IDeparmentRepository : IRepositoryBase<Department>
    {
        void Update(Department department);
        void Create(Department department);
        void Delete(Department department);
        Department GetDepartmenById(int id);
        Department GetContactById(int id);
    }
}
