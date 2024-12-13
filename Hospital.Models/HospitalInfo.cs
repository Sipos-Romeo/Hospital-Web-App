using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class HospitalInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public string? Type { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(10)]
        public string? PinCode { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; } 
        public virtual ICollection<Contact>? Contacts { get; set; } 
    }

}
