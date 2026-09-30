using HOSPITAL_MANAGEMENT_SYSTEM.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface
{
    public interface IDepartmentRepo : IGenaricRepo<Department>
    {
       public ICollection<Department> GetDepartmentsWithDoctorCount();
    }
}
