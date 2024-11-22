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
    public class HospitalInfoRepositoryTests
    {
        private Mock<DbSet<HospitalInfo>> _mockHospitalInfos;
        private Mock<HospitalAppDbContext> _mockDbContext;
        private List<HospitalInfo> _hospitalInfoData;

        public HospitalInfoRepositoryTests()
        {
            
            _hospitalInfoData = new List<HospitalInfo>
            {
                new HospitalInfo { Id = 1, Name = "City Hospital", Type = "General", City = "New York", PinCode = "10001", Country = "USA" },
                new HospitalInfo { Id = 2, Name = "Community Health Center", Type = "Clinic", City = "Los Angeles", PinCode = "90001", Country = "USA" },
                new HospitalInfo { Id = 3, Name = "Specialist Hospital", Type = "Specialist", City = "Chicago", PinCode = "60601", Country = "USA" }
            };

            
            _mockHospitalInfos = new Mock<DbSet<HospitalInfo>>();
            _mockHospitalInfos.As<IQueryable<HospitalInfo>>().Setup(m => m.Provider).Returns(_hospitalInfoData.AsQueryable().Provider);
            _mockHospitalInfos.As<IQueryable<HospitalInfo>>().Setup(m => m.Expression).Returns(_hospitalInfoData.AsQueryable().Expression);
            _mockHospitalInfos.As<IQueryable<HospitalInfo>>().Setup(m => m.ElementType).Returns(_hospitalInfoData.AsQueryable().ElementType);
            _mockHospitalInfos.As<IQueryable<HospitalInfo>>().Setup(m => m.GetEnumerator()).Returns(_hospitalInfoData.GetEnumerator());

            
            _mockDbContext = new Mock<HospitalAppDbContext>();
            _mockDbContext.Setup(c => c.HospitalInfo).Returns(_mockHospitalInfos.Object);
        }

        [Fact]
        public void GetHospitalById_ShouldReturnCorrectHospital_WhenIdExists()
        {
           
            var repository = new HospitalInfoRepository(_mockDbContext.Object);

            
            var result = repository.GetHospitalById(2);

           
            Assert.NotNull(result);
            Assert.Equal("Community Health Center", result.Name);
            Assert.Equal("Clinic", result.Type);
            Assert.Equal("Los Angeles", result.City);
        }

        [Fact]
        public void GetHospitalById_ShouldReturnEmptyHospital_WhenIdDoesNotExist()
        {
            
            var repository = new HospitalInfoRepository(_mockDbContext.Object);

            
            var result = repository.GetHospitalById(99); 

           
            Assert.NotNull(result);
            Assert.Equal(0, result.Id); 
            Assert.Null(result.Name);
        }
    }
}
