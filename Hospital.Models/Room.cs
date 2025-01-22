using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string? RoomNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Type { get; set; }
        [Required]
        public RoomStatus Status { get; set; }

        [Required(ErrorMessage = "Please select a hospital.")]
        public int HospitalInfoId { get; set; }
        public virtual HospitalInfo? HospitalInfo { get; set; }
        public string? Section { get; set; }
      
    }

    public enum RoomStatus
    {
        Free,
        Occupied,
        Cleaning,
        Maintenance
    }

    public class CheckIn
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime CheckInTime { get; set; } = DateTime.Now;

        public DateTime? CheckOutTime { get; set; }
    }

    public class MaintenanceTask
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public string? TaskDescription { get; set; }

        public DateTime ScheduledTime { get; set; }
    }

}