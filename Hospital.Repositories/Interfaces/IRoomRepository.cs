using Hospital.Models;
using Hospital.Web.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Interfaces
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        Room GetRoomById(int id);
    }
}
