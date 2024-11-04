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
    public class ContactService : IContactServices
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ContactService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateContact(Contact contact)
        {
            _repositoryWrapper.ContactRepository.Create(contact);
            _repositoryWrapper.Save();
        }

        public void DeleteContact(Contact contact)
        {
            _repositoryWrapper.ContactRepository.Delete(contact);
            _repositoryWrapper.Save();
        }

        public List<Contact> GetAllContact()
        {
            return _repositoryWrapper.ContactRepository.FindAll().ToList();
        }

        public Contact GetContactById(int id)
        {
            return _repositoryWrapper.ContactRepository.GetContactById(id);
        }

        public void UpdateContact(Contact contact)
        {
            _repositoryWrapper.HospitalInfoRepository.Update(contact);
            _repositoryWrapper.Save();
        }
    }
}
