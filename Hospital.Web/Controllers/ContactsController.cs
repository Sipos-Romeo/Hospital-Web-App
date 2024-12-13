using Hospital.Models;
using Hospital.Services.Interfaces;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hospital.Web.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactServices _contactServices;
        private readonly IHospitalInfoService _hospitalInfoService;

        public ContactsController(IContactServices contactServices, IHospitalInfoService hospitalInfoService)
        {
            _contactServices = contactServices;
            _hospitalInfoService = hospitalInfoService;
        }

        public IActionResult Index()
        {
            return View(_contactServices.GetAllContact());
        }

        public IActionResult Create()
        {
            var hospitals = _hospitalInfoService.GetAllHospitalInfo();
            var viewModel = new ContactViewModel
            {
                Hospitals = hospitals.Select(h => new KeyValuePair<int, string>(h.Id, h.Name)).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ContactViewModel contactVM)
        {
            if (!ModelState.IsValid)
            {
                contactVM.Hospitals = _hospitalInfoService.GetAllHospitalInfo()
                    .Select(h => new KeyValuePair<int, string>(h.Id, h.Name)).ToList();
                return View(contactVM);
            }

            _contactServices.CreateContact(contactVM.Contact);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var contact = _contactServices.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var contact = _contactServices.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            _contactServices.DeleteContact(contact);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var contact = _contactServices.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            var hospitals = _hospitalInfoService.GetAllHospitalInfo();
            var viewModel = new ContactViewModel
            {
                Contact = contact,
                Hospitals = hospitals.Select(h => new KeyValuePair<int, string>(h.Id, h.Name)).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                // Return view with validation errors.
                return View(contact);
            }

            try
            {
                _contactServices.UpdateContact(contact);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log exception and add error to ModelState.
                Debug.WriteLine($"Concurrency exception: {ex.Message}");
                ModelState.AddModelError("", "Unable to save changes. The record may have been modified or deleted.");
                return View(contact);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var item = _contactServices.GetContactById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}
