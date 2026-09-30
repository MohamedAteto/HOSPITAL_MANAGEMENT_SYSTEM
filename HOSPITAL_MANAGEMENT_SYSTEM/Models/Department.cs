using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Models
{
    public class Department
    {
        [Key]
        public int DepartementId { get; set; }
        [Required,MaxLength(100)]
        public string DepartementName { get; set; }
        [Required,MaxLength(150)]
        public string? DepartementLocation { get; set; }

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
