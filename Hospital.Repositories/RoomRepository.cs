using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Tests.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(HospitalAppDbContext hospitalAppDbContext) : base(hospitalAppDbContext)
        {
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _hospitalAppDbContext.Rooms!.ToList();
        }

        public Room GetRoomById(int id)
        {
            return _hospitalAppDbContext.Rooms?.Where(c => c.Id == id)
                .Include(r => r.HospitalInfo)
                .FirstOrDefault() ?? new Room();
        }
    }
}
