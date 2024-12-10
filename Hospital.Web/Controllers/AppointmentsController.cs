using Hospital.Models;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hospital.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            return View(_appointmentService.GetAllAppointment());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            _appointmentService.CreateAppointment(appointment);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _appointmentService.GetAppointmentById(id);
            if (item == null)
            {
                return NotFound();
            }

            // Pass the item to a confirmation view.
            return View(item);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _appointmentService.GetAppointmentById(id);
            if (item == null)
            {
                return NotFound();
            }

            // Perform the deletion.
            _appointmentService.DeleteAppointment(item);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _appointmentService.GetAppointmentById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            try
            {
                _appointmentService.UpdateAppointment(appointment);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine($"Concurrency exception: {ex.Message}");
                ModelState.AddModelError("", "Unable to save changes. The record may have been modified or deleted.");
                return View(appointment);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var item = _appointmentService.GetAppointmentById(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}
