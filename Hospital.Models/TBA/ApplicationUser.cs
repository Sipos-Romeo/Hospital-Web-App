using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models.TBA
{
    public class ApplicationUser
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Specialist { get; set; }
        public Department Department { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }


}

namespace Hospital.Models.TBA
{
    public enum Gender
    {
        Male, Female, Other
    }
}