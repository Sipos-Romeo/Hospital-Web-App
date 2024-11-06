using Hospital.Models;
using Hospital.Repositories;
using Hospital.Repositories.Interfaces;
using Hospital.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public DepartmentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateDepartment(Department department)
        {
            _repositoryWrapper.DeparmentRepository.Create(department);
            _repositoryWrapper.Save();

        }

        public void DeleteDepartment(Department department)
        {
            _repositoryWrapper.DeparmentRepository.Delete(department);
            _repositoryWrapper.Save();
        }

        public List<Department> GetAllDepartments()
        {
            return _repositoryWrapper.DeparmentRepository.FindAll().ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _repositoryWrapper.DeparmentRepository.GetDepartmenById(id);
        }

        public void UpdateDepartment(Department department)
        {
            _repositoryWrapper.DeparmentRepository.Update(department);
            _repositoryWrapper.Save();
        }
    }
}
