using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Repositories;
using NPOI.SS.Formula.Functions;

namespace HospitalApp.Tests.Repositories
{
    public class AppointmentRepositoryTests
    {
        private Mock<DbSet<Appointment>> _mockAppointments;
        private Mock<HospitalAppDbContext> _mockDbContext;
        private List<Appointment> _appointmentData;

        public AppointmentRepositoryTests()
        {
           
            _appointmentData = new List<Appointment>
            {
                new Appointment { Id = 1, Number = "A1001", Type = "Checkup", Description = "Routine Checkup" },
                new Appointment { Id = 2, Number = "A1002", Type = "Surgery", Description = "Minor Surgery" },
                new Appointment { Id = 3, Number = "A1003", Type = "Follow-Up", Description = "Follow-up after Surgery" }
            };

            // Setup mock DbSet
            _mockAppointments = new Mock<DbSet<Appointment>>();
            _mockAppointments.As<IQueryable<Appointment>>().Setup(m => m.Provider).Returns(_appointmentData.AsQueryable().Provider);
            _mockAppointments.As<IQueryable<Appointment>>().Setup(m => m.Expression).Returns(_appointmentData.AsQueryable().Expression);
            _mockAppointments.As<IQueryable<Appointment>>().Setup(m => m.ElementType).Returns(_appointmentData.AsQueryable().ElementType);
            _mockAppointments.As<IQueryable<Appointment>>().Setup(m => m.GetEnumerator()).Returns(_appointmentData.GetEnumerator());

            // Setup mock DbContext
            _mockDbContext = new Mock<HospitalAppDbContext>();
            _mockDbContext.Setup(c => c.Appointments).Returns(_mockAppointments.Object);
        }

        [Fact]
        public void GetAppointmentById_ShouldReturnCorrectAppointment_WhenIdExists()
        {
            
            var repository = new AppointmentRepository(_mockDbContext.Object);

           
            var result = repository.GetAppointmentById(2);

            
            Assert.NotNull(result);
            Assert.Equal("A1002", result.Number);
            Assert.Equal("Surgery", result.Type);
        }

        [Fact]
        public void GetAppointmentById_ShouldReturnEmptyAppointment_WhenIdDoesNotExist()
        {
            
            var repository = new AppointmentRepository(_mockDbContext.Object);

           
            var result = repository.GetAppointmentById(99); 

           
            Assert.NotNull(result);
            Assert.Equal(0, result.Id); 
            Assert.Null(result.Number);
        }
    }
}
