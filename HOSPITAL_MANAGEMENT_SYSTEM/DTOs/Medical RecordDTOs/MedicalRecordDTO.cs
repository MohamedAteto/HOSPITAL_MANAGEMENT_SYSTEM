using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM.DTOs.Medical_RecordDTOs
{
    public class MedicalRecordDTO
    {
        public string Diagnosis { get; set; }
        public string Description { get; set; }
        public string? Notes { get; set; }
        public int AppointmentId { get; set; }
    }
}
