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
    public class ContactRepositoryTests
    {
        private Mock<DbSet<Contact>> _mockContacts;
        private Mock<HospitalAppDbContext> _mockDbContext;
        private List<Contact> _contactData;

        public ContactRepositoryTests()
        {
            
            _contactData = new List<Contact>
            {
                new Contact { Id = 1, Email = "hospital1@example.com", Phone = "1234567890", PhoneNumber = "9876543210" },
                new Contact { Id = 2, Email = "hospital2@example.com", Phone = "0987654321", PhoneNumber = "5678901234" },
                new Contact { Id = 3, Email = "hospital3@example.com", Phone = "1122334455", PhoneNumber = "5544332211" }
            };

            
            _mockContacts = new Mock<DbSet<Contact>>();
            _mockContacts.As<IQueryable<Contact>>().Setup(m => m.Provider).Returns(_contactData.AsQueryable().Provider);
            _mockContacts.As<IQueryable<Contact>>().Setup(m => m.Expression).Returns(_contactData.AsQueryable().Expression);
            _mockContacts.As<IQueryable<Contact>>().Setup(m => m.ElementType).Returns(_contactData.AsQueryable().ElementType);
            _mockContacts.As<IQueryable<Contact>>().Setup(m => m.GetEnumerator()).Returns(_contactData.GetEnumerator());

            
            _mockDbContext = new Mock<HospitalAppDbContext>();
            _mockDbContext.Setup(c => c.Contacts).Returns(_mockContacts.Object);
        }

        [Fact]
        public void GetContactById_ShouldReturnCorrectContact_WhenIdExists()
        {
           
            var repository = new ContactRepository(_mockDbContext.Object);

            
            var result = repository.GetContactById(2);

            
            Assert.NotNull(result);
            Assert.Equal("hospital2@example.com", result.Email);
            Assert.Equal("0987654321", result.Phone);
        }

        [Fact]
        public void GetContactById_ShouldReturnEmptyContact_WhenIdDoesNotExist()
        {
           
            var repository = new ContactRepository(_mockDbContext.Object);

          
            var result = repository.GetContactById(99); 

            
            Assert.NotNull(result);
            Assert.Equal(0, result.Id); 
            Assert.Null(result.Email);
        }
    }
}
