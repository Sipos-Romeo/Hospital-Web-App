using Hospital.Models;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Controllers
{

    [Authorize(Roles = "Admin")]
    public class HospitalInfoesController : Controller
    {
        private readonly IHospitalInfoService _hospitalInfoService;

        public HospitalInfoesController(IHospitalInfoService hospitalInfoService)
        {
            _hospitalInfoService = hospitalInfoService;
        }

        public IActionResult Index(string searchString = "")
        {

            return View(_hospitalInfoService.GetAllHospitalInfo(searchString));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] HospitalInfo hospitalInfo)
        {
            if (ModelState.IsValid)
            {
                _hospitalInfoService.CreateHospitalInfo(hospitalInfo);
                return RedirectToAction(nameof(Index));
            }
            return View(hospitalInfo);
        }

        public IActionResult Delete(int id)
        {
            var item = _hospitalInfoService.GetHospitalInfoById(id);
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
            _hospitalInfoService.DeleteHospitalInfo(_hospitalInfoService.GetHospitalInfoById(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _hospitalInfoService.GetHospitalInfoById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  HospitalInfo hospitalInfo)
        {
            if (id != hospitalInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _hospitalInfoService.UpdateHospitalInfo(hospitalInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hospitalInfo);
        }
        public IActionResult Details(int id)
        {
            var item = _hospitalInfoService.GetHospitalInfoById(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

    }

    
}
