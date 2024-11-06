using Hospital.Models;
using Hospital.Services;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Controllers
{
    public class FeedbackFormsController : Controller
    {
        
        private readonly IFeedbackFormService _feedbackFormService;

        public FeedbackFormsController(IFeedbackFormService feedbackFormService)
        {
            _feedbackFormService = feedbackFormService;
        }

        public IActionResult Index()
        {
            return View(_feedbackFormService.GetAllFeedbackForm());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] FeedbackForm feedbackForm)
        {
            if (ModelState.IsValid)
            {
                _feedbackFormService.CreateFeedbackForm(feedbackForm);
                return RedirectToAction(nameof(Index));
            }
            return View(feedbackForm);
        }

        public IActionResult Delete(int id)
        {
            var item = _feedbackFormService.GetFeedbackFormById(id);
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
            _feedbackFormService.DeleteFeedbackForm(_feedbackFormService.GetFeedbackFormById(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _feedbackFormService.GetFeedbackFormById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FeedbackForm feedbackForm)
        {
            if (id != feedbackForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _feedbackFormService.UpdateFeedbackForm(feedbackForm);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(feedbackForm);
        }
        public IActionResult Details(int id)
        {
            var item = _feedbackFormService.GetFeedbackFormById(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

    }
}

