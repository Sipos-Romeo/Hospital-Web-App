﻿using System.ComponentModel.DataAnnotations;

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

        public string? Status { get; set; }

        // Foreign Key for HospitalInfo
        public int HospitalInfoId { get; set; }
        public virtual HospitalInfo? HospitalInfo { get; set; }
    }

}