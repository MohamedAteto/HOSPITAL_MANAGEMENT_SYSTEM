using HOSPITAL_MANAGEMENT_SYSTEM.Data;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Implementation
{
    public class DoctorRepo : GenaricRepo<Doctor> , IDoctoRepo
    {
        private readonly AppDbContext _context;

        public DoctorRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetBySpecialization(string specialization)
        {
            return _context.Doctors
                .Where(x => x.DoctorSpecialization == specialization)
                .ToList();
        }

        public IEnumerable<Doctor> GetDetails()
        {
            return _context.Doctors
                .Include(d => d.Department)
                .ToList();
        }
    }
}
