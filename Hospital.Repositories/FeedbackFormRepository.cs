using Hospital.Models;
using Hospital.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hospital.Repositories
{
    public class FeedbackFormRepository : RepositoryBase<FeedbackForm>, IFeedbackFormRepository
    {
        public FeedbackFormRepository(HospitalAppDbContext hospitalAppDbContext) : base(hospitalAppDbContext)
        {
        }
        public FeedbackForm GetFeedbackFormById(int id)
        {
            return _hospitalAppDbContext.FeedbackForms?.Where(c => c.Id == id).FirstOrDefault() ?? new FeedbackForm();
        }
    }
}