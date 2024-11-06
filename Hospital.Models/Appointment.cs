using Hospital.Models.TBA;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set;}
        [NotMapped]
        public ApplicationUser? Doctor { get; set;} // string
        [NotMapped]
        public ApplicationUser? Patient { get; set;} // string
    }
}