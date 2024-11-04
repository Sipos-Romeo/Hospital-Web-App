using Hospital.Models;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Controllers
{
    public class ContactsControler : Controller
    {
        private readonly IContactServices _contactServices;

        public ContactsControler(IContactServices contactServices)
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
            if (ModelState.IsValid)
            {
                _contactServices.CreateContact(contact);
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var item = _contactServices.GetContactById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactServices.DeleteContact(_contactServices.GetContactById(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _contactServices.GetContactById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contactServices.UpdateContact(contact);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
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
