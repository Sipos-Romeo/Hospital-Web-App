using Hospital.Models;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;

namespace Hospital.Web.Controllers
{
    [Authorize]
    public class HospitalInfoesController : Controller
    {
        private readonly IHospitalInfoService _hospitalInfoService;

        public HospitalInfoesController(IHospitalInfoService hospitalInfoService)
        {
            _hospitalInfoService = hospitalInfoService;
        }

        public IActionResult Index()
        {
            return View(_hospitalInfoService.GetAllHospitalInfo());
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
    }
}
