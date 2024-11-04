using Hospital.Models;
using Hospital.Services;
using Hospital.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Controllers
{
    public class RoomsController : Controller
    {
        
            private readonly IRoomService _roomService;

            public RoomsController(RoomService roomService)
            {
            _roomService = roomService;
            }

            public IActionResult Index()
            {
                return View(_roomService.GetAllRoom());
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create([FromForm] Room room)
            {
                if (ModelState.IsValid)
                {
                _roomService.CreateRoom(room);
                    return RedirectToAction(nameof(Index));
                }
                return View(room);
            }

            public IActionResult Delete(int id)
            {
                var item = _roomService.GetRoomById(id);
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
            _roomService.DeleteRoom(_roomService.GetRoomById(id));
                return RedirectToAction(nameof(Index));
            }

            public IActionResult Edit(int id)
            {
                var item = _roomService.GetRoomById(id);
                if (item == null)
                {
                    return NotFound();
                }
                return View(item);
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
                    try
                    {
                    _roomService.UpdateRoom(room);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(room);
            }
            public IActionResult Details(int id)
            {
                var item = _roomService.GetRoomById(id);

                if (item == null)
                {
                    return NotFound();
                }

                return View(item);
            }

        }
    }

