using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class RoomViewModel
    {
        public Room Room { get; set; }
        public List<KeyValuePair<int, string>> Hospitals { get; set; } = new();
    }

}
