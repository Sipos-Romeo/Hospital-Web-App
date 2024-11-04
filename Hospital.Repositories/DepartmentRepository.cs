using Hospital.Models;
using Hospital.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDeparmentRepository
    {
        public DepartmentRepository(HospitalAppDbContext hospitalAppDbContext) : base(hospitalAppDbContext)
        {
        }
        public Department GetDepartmenById(int id)
        {
           return _hospitalAppDbContext.Departments.Where(c=>c.Id == id).FirstOrDefault() ?? new Department();
        }
    }
}
