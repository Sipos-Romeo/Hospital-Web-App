using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interfaces
{
    public interface IFeedbackFormService
    {
        void CreateFeedbackForm(FeedbackForm feedbackForm);
        void UpdateFeedbackForm(FeedbackForm feedbackForm);
        void DeleteFeedbackForm(FeedbackForm feedbackForm);
        FeedbackForm GetFeedbackFormById(int id);
        List<FeedbackForm> GetAllFeedbackForm();
    }
}
