using Hospital.Models;
using Hospital.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(HospitalAppDbContext ApplicationDbcontext) : base(ApplicationDbcontext)
        {
        }

        Room IRoomRepository.GetRoomById(int id)
        {
            return _hospitalAppDbContext.Rooms.Where(c => c.Id == id).FirstOrDefault() ?? new Room();
        }
    }
}
