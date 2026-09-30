using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required, MaxLength(150)]
        public string PatientFullName { get; set; }
        [Required, MaxLength(20)]
        public string PatientGender { get; set; }
        [Required]
        [Range(typeof(DateTime), "1964-01-01", "2026-12-31", ErrorMessage = "Date of Birth must be after 1964 and before 2026.")]
        public DateTime PatientDateOfBirth { get; set; }
        [Required, MaxLength(20)]
        public string PatientPhone { get; set; }

        [MaxLength(250)]
        public string? patientAddress { get; set; }


        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
