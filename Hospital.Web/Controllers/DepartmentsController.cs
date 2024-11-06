using Hospital.Models;
using Hospital.Services;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentSevice)
        {
            _departmentService = departmentSevice;
        }

        public IActionResult Index()
        {
            return View(_departmentService.GetAllDepartments());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.CreateDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Delete(int id)
        {
            var item = _departmentService.GetDepartmentById(id);
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
            _departmentService.DeleteDepartment(_departmentService.GetDepartmentById(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _departmentService.GetDepartmentById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentService.UpdateDepartment(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult Details(int id)
        {
            var item = _departmentService.GetDepartmentById(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
    }
}

