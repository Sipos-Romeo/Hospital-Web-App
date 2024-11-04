using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.TBA
{
    public class Supplier
    {
        public string ID { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ICollection<MedicineReport> MedicineReport { get; set; }
    }
}
