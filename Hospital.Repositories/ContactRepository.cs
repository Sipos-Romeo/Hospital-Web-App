using Hospital.Models;
using Hospital.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hospital.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(HospitalAppDbContext hospitalAppDbContext) : base(hospitalAppDbContext)
        {
        }
        public Contact GetContactById(int id)
        {
            return _hospitalAppDbContext.Contacts.Where(c => c.Id == id).FirstOrDefault() ?? new Contact();
        }
    }
}