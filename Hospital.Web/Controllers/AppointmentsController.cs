using Hospital.Models;
using Hospital.Services;
using Hospital.Services.Interfaces;
using Hospital.Web.Models;
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
            if (ModelState.IsValid)
            {
                _appointmentService.CreateAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        public IActionResult Delete(int id)
        {
            var item = _appointmentService.GetAppointmentById(id);
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
            _appointmentService.DeleteAppointment(_appointmentService.GetAppointmentById(id));
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
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appointmentService.UpdateAppointment(appointment);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
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

    