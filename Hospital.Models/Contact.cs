using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public int HospitalInfoId { get; set; }
        public virtual HospitalInfo? HospitalInfo { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
    }

}