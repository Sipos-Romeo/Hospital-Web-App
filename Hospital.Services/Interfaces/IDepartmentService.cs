using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interfaces
{
    public interface IDepartmentService
    {
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
        Department GetDepartmentById(int id);
        List<Department> GetAllDepartments();
    }
}
