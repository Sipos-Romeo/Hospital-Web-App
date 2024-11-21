using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Number { get; set; }

        [Required]
        public string? Type { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        // Foreign Key for Doctor
        [Required]
        public int? DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public virtual ApplicationUser? Doctor { get; set; }

        // Foreign Key for Patient
        [Required]
        public int? PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual ApplicationUser? Patient { get; set; }
    }

}