using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM.DTOs.PatientDTOs
{
    public class PatientDTO
    {
        public string PatientFullName { get; set; }
        public string PatientGender { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public string PatientPhone { get; set; }
        public string? patientAddress { get; set; }
    }
}
