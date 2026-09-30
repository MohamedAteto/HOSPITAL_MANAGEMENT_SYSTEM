using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    [Index(nameof(DoctorEmail) ,IsUnique = true)]
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required, MaxLength(150)]
        public string DoctorFullName { get; set; }
        [Required, MaxLength(100)]
        public string DoctorSpecialization { get; set; }
        [Required, EmailAddress]
        public string DoctorEmail { get; set; }
        [Required, MaxLength(20)]
        public string DoctorPhone { get; set; }
        [Required, Range(1,int.MaxValue)]
        public decimal DoctorSalary { get; set; }



        public int DepartementId { get; set; }
        [ForeignKey("DepartementId")]
        public Department? Department { get; set; }

        public ICollection<Appointment> Appointments { get; set; }  = new List<Appointment>();
    }
}
