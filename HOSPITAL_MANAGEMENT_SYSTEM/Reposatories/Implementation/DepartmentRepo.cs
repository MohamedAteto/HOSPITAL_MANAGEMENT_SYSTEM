using HOSPITAL_MANAGEMENT_SYSTEM.Data;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Implementation
{
    public class DepartmentRepo : GenaricRepo<Department>, IDepartmentRepo
    {

        private readonly AppDbContext _context;

        public DepartmentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Department> GetDepartmentsWithDoctorCount()
        {
            return _context.Departments
                .Include(d => d.Doctors).ToList();
        }
    }
}
