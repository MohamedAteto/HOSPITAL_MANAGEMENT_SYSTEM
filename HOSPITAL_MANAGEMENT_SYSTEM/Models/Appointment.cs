using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required,MaxLength(30)]
        public string Status { get; set; }



        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }


        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        public MedicalRecord? MedicalRecord { get; set; }
    }
}
