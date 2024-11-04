using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Services.Interfaces;
using Hospital.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public RoomService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }   

        public void CreateRoom(Room room)
        {
            _repositoryWrapper.RoomRepository.Create(room);
            _repositoryWrapper.Save(); ;
        }

        public void DeleteRoom(Room room)
        {
            _repositoryWrapper.RoomRepository.Delete(room);
            _repositoryWrapper.Save();
        }

        public List<Room> GetAllRoom()
        {
           return _repositoryWrapper.RoomRepository.FindAll().ToList();
        }

        public Room GetRoomById(int id)
        {
           return _repositoryWrapper.RoomRepository.GetRoomById(id);
        }

        public void UpdateRoom(Room room)
        {
            _repositoryWrapper.RoomRepository.Update(room);
            _repositoryWrapper.Save();
        }
    }
}
