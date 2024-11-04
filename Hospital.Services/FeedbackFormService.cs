using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class FeedbackFormService : IFeedbackFormService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public FeedbackFormService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void CreateFeedbackForm(FeedbackForm feedbackForm)
        {
            _repositoryWrapper.FeedbackFormRepository.Create(feedbackForm);
            _repositoryWrapper.Save();
        }

        public void DeleteFeedbackForm(FeedbackForm feedbackForm)
        {
            _repositoryWrapper.FeedbackFormRepository.Create(feedbackForm);
            _repositoryWrapper.Save();
        }

        public List<FeedbackForm> GetAllFeedbackForm()
        {
           return _repositoryWrapper.FeedbackFormRepository.FindAll().ToList();
        }

        public FeedbackForm GetFeedbackFormById(int id)
        {
           return _repositoryWrapper.FeedbackFormRepository.GetFeedbackFormById(id);
        }

        public void UpdateFeedbackForm(FeedbackForm feedbackForm)
        {
            _repositoryWrapper.FeedbackFormRepository.Update(feedbackForm);
            _repositoryWrapper.Save();
        }
    }

}
