using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Repositories;

namespace HospitalApp.Tests.Repositories
{
    public class DepartmentRepositoryTests
    {
        private Mock<DbSet<Department>> _mockDepartments;
        private Mock<HospitalAppDbContext> _mockDbContext;
        private List<Department> _departmentData;

        public DepartmentRepositoryTests()
        {
            
            _departmentData = new List<Department>
            {
                new Department { Id = 1, Name = "Cardiology", Description = "Heart related issues" },
                new Department { Id = 2, Name = "Neurology", Description = "Brain and nervous system" },
                new Department { Id = 3, Name = "Oncology", Description = "Cancer treatment" }
            };

           
            _mockDepartments = new Mock<DbSet<Department>>();
            _mockDepartments.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(_departmentData.AsQueryable().Provider);
            _mockDepartments.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(_departmentData.AsQueryable().Expression);
            _mockDepartments.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(_departmentData.AsQueryable().ElementType);
            _mockDepartments.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(_departmentData.GetEnumerator());

            
            _mockDbContext = new Mock<HospitalAppDbContext>();
            _mockDbContext.Setup(c => c.Departments).Returns(_mockDepartments.Object);
        }

        [Fact]
        public void GetDepartmenById_ShouldReturnCorrectDepartment_WhenIdExists()
        {
          
            var repository = new DepartmentRepository(_mockDbContext.Object);

           
            var result = repository.GetDepartmenById(2);

            
            Assert.NotNull(result);
            Assert.Equal("Neurology", result.Name);
            Assert.Equal("Brain and nervous system", result.Description);
        }

        [Fact]
        public void GetDepartmenById_ShouldReturnEmptyDepartment_WhenIdDoesNotExist()
        {
          
            var repository = new DepartmentRepository(_mockDbContext.Object);

           
            var result = repository.GetDepartmenById(99); 

            
            Assert.NotNull(result);
            Assert.Equal(0, result.Id); 
            Assert.Null(result.Name);
        }
    }
}
