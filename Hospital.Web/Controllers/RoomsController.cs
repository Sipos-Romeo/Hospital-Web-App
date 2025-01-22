using Hospital.Models;
using Hospital.Services;
using Hospital.Services.Interfaces;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class RoomsController : Controller
    {

        private readonly IRoomService _roomService;
        private readonly IHospitalInfoService _hospitalInfoService;

        public RoomsController(IRoomService roomService, IHospitalInfoService hospitalInfoService)
        {
            _roomService = roomService;
            _hospitalInfoService = hospitalInfoService;
        }

        public IActionResult Index()
        {
            return View(_roomService.GetAllRooms());
        }

        public IActionResult Create()
        {
            var hospitals = _hospitalInfoService.GetAllHospitalInfo();
            var viewModel = new RoomViewModel
            {
                Hospitals = hospitals.Select(h => new KeyValuePair<int, string>(h.Id, h.Name ?? "Unknown")).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] RoomViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Hospitals = _hospitalInfoService.GetAllHospitalInfo()
                    .Select(h => new KeyValuePair<int, string>(h.Id, h.Name ?? "Unknown"))
                    .ToList();
            }

            if (viewModel.Room == null)
            {
                ModelState.AddModelError(string.Empty, "Room details are required.");
                return View(viewModel); // Return the view with an error message
            }

            _roomService.CreateRoom(viewModel.Room);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid room ID.");
            }

            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }


            return View(room);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid room ID.");
            }

            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound("Room not found.");
            }

            _roomService.DeleteRoom(room);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            var hospitals = _hospitalInfoService.GetAllHospitalInfo();
            var viewModel = new RoomViewModel
            {
                Room = room,
                Hospitals = hospitals.Select(h => new KeyValuePair<int, string>(h.Id, h.Name ?? "Unknown")).ToList()
            };



            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _roomService.UpdateRoom(room);
                return RedirectToAction(nameof(Index));
            }

            return View(room);
        }
        public IActionResult Details(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state.");
            }

            var item = _roomService.GetRoomById(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }


    }
}