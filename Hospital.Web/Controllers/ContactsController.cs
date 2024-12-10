using Hospital.Models;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hospital.Web.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactServices _contactServices;

        public ContactsController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        public IActionResult Index()
        {
            return View(_contactServices.GetAllContact());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                // Return view with validation errors.
                return View(contact);
            }

            _contactServices.CreateContact(contact);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _contactServices.GetContactById(id);
            if (item == null)
            {
                return NotFound();
            }

            // Render confirmation view.
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _contactServices.GetContactById(id);
            if (item == null)
            {
                return NotFound();
            }

            _contactServices.DeleteContact(item);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _contactServices.GetContactById(id);
            if (item == null)
            {
                return NotFound();
            }

            // Pass the item to the edit view.
            return View(item);
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
