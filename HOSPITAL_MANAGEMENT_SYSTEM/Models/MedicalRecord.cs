using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordId { get; set; }
        [Required,MaxLength(500)]
        public string Diagnosis { get; set; }
        [Required,MaxLength(1000)]
        public string Description { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }

        public int AppointmentId { get; set; }
        [ForeignKey(nameof(AppointmentId))]
        public Appointment? Appointment { get; set; }

    }
}
