using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM.DTOs.DoctorDTO
{
    public class DoctorDTO
    {
        public string DoctorFullName { get; set; }
        public string DoctorSpecialization { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhone { get; set; }
        public decimal DoctorSalary { get; set; }
        public int DepartementId { get; set; }
    }
}
