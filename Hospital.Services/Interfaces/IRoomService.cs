using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Interfaces
{
    public interface IRoomService
    {
        void CreateRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(Room room);
        Room GetRoomById(int id);
        List<Room> GetAllRoom();
    }
}
