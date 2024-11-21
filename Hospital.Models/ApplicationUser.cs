using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        // Additional properties for your application
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
        Male, Female, Other
    }
}