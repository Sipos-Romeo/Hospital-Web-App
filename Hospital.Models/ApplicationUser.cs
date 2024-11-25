using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Hospital.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string? FullName { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }

        // Relationships
        public virtual ICollection<Appointment>? AppointmentsAsDoctor { get; set; }
        public virtual ICollection<Appointment>? AppointmentsAsPatient { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
