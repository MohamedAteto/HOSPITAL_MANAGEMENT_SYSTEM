using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM.DTOs.AppointmentDTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
