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
    public class RoomRepositoryTests
    {
        private Mock<DbSet<Room>> _mockRooms;
        private Mock<HospitalAppDbContext> _mockDbContext;
        private List<Room> _roomData;

        public RoomRepositoryTests()
        {
            
            _roomData = new List<Room>
            {
                new Room { Id = 1, RoomNumber = "101", Type = "ICU", Status = "Occupied" },
                new Room { Id = 2, RoomNumber = "102", Type = "General", Status = "Available" },
                new Room { Id = 3, RoomNumber = "103", Type = "Private", Status = "Under Maintenance" }
            };

            
            _mockRooms = new Mock<DbSet<Room>>();
            _mockRooms.As<IQueryable<Room>>().Setup(m => m.Provider).Returns(_roomData.AsQueryable().Provider);
            _mockRooms.As<IQueryable<Room>>().Setup(m => m.Expression).Returns(_roomData.AsQueryable().Expression);
            _mockRooms.As<IQueryable<Room>>().Setup(m => m.ElementType).Returns(_roomData.AsQueryable().ElementType);
            _mockRooms.As<IQueryable<Room>>().Setup(m => m.GetEnumerator()).Returns(_roomData.GetEnumerator());

            
            _mockDbContext = new Mock<HospitalAppDbContext>();
            _mockDbContext.Setup(c => c.Rooms).Returns(_mockRooms.Object);
        }

        [Fact]
        public void GetRoomById_ShouldReturnCorrectRoom_WhenIdExists()
        {
            
            var repository = new RoomRepository(_mockDbContext.Object);

            
            var result = repository.GetRoomById(2);

          
            Assert.NotNull(result);
            Assert.Equal("102", result.RoomNumber);
            Assert.Equal("General", result.Type);
            Assert.Equal("Available", result.Status);
        }

        [Fact]
        public void GetRoomById_ShouldReturnEmptyRoom_WhenIdDoesNotExist()
        {
           
            var repository = new RoomRepository(_mockDbContext.Object);

            
            var result = repository.GetRoomById(99); 

            
            Assert.NotNull(result);
            Assert.Equal(0, result.Id); 
            Assert.Null(result.RoomNumber);
        }
    }
}
