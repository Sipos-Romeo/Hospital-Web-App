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
    public class FeedbackFormRepositoryTests
    {
        private Mock<DbSet<FeedbackForm>> _mockFeedbackForms;
        private Mock<HospitalAppDbContext> _mockDbContext;
        private List<FeedbackForm> _feedbackFormData;

        public FeedbackFormRepositoryTests()
        {
            
            _feedbackFormData = new List<FeedbackForm>
            {
                new FeedbackForm { Id = 1, Name = "John Doe", Description = "Great service!", Email = "john.doe@example.com", RatingSection = 5 },
                new FeedbackForm { Id = 2, Name = "Jane Smith", Description = "Average experience.", Email = "jane.smith@example.com", RatingSection = 3 },
                new FeedbackForm { Id = 3, Name = "Sam Wilson", Description = "Poor service.", Email = "sam.wilson@example.com", RatingSection = 1 }
            };

            
            _mockFeedbackForms = new Mock<DbSet<FeedbackForm>>();
            _mockFeedbackForms.As<IQueryable<FeedbackForm>>().Setup(m => m.Provider).Returns(_feedbackFormData.AsQueryable().Provider);
            _mockFeedbackForms.As<IQueryable<FeedbackForm>>().Setup(m => m.Expression).Returns(_feedbackFormData.AsQueryable().Expression);
            _mockFeedbackForms.As<IQueryable<FeedbackForm>>().Setup(m => m.ElementType).Returns(_feedbackFormData.AsQueryable().ElementType);
            _mockFeedbackForms.As<IQueryable<FeedbackForm>>().Setup(m => m.GetEnumerator()).Returns(_feedbackFormData.GetEnumerator());

            
            _mockDbContext = new Mock<HospitalAppDbContext>();
            _mockDbContext.Setup(c => c.FeedbackForms).Returns(_mockFeedbackForms.Object);
        }

        [Fact]
        public void GetFeedbackFormById_ShouldReturnCorrectFeedbackForm_WhenIdExists()
        {
            
            var repository = new FeedbackFormRepository(_mockDbContext.Object);

           
            var result = repository.GetFeedbackFormById(2);

            
            Assert.NotNull(result);
            Assert.Equal("Jane Smith", result.Name);
            Assert.Equal("Average experience.", result.Description);
            Assert.Equal(3, result.RatingSection);
        }

        [Fact]
        public void GetFeedbackFormById_ShouldReturnEmptyFeedbackForm_WhenIdDoesNotExist()
        {
           
            var repository = new FeedbackFormRepository(_mockDbContext.Object);

            
            var result = repository.GetFeedbackFormById(99); // Non-existent ID

            
            Assert.NotNull(result);
            Assert.Equal(0, result.Id); // Assuming the default constructor sets Id = 0
            Assert.Null(result.Name);
        }
    }
}
