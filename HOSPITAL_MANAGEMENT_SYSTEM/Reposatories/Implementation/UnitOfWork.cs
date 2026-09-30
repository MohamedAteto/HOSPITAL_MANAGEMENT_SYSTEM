using HOSPITAL_MANAGEMENT_SYSTEM.Data;
using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IDepartmentRepo DepartmentRepo { get; }

        public IDoctoRepo DoctorRepo { get; }

        //public IPatientRepo PatientRepo { get; }

        //public IAppointment AppointmentRepo { get; }

        //IPatientRepo patientRepo, IAppointment appointmentRepo
        public UnitOfWork(AppDbContext context, IDepartmentRepo departmentRepo, IDoctoRepo doctorRepo)
        {
            _context = context;
            DepartmentRepo = departmentRepo;
            DoctorRepo = doctorRepo;
            //PatientRepo = patientRepo;
            //AppointmentRepo = appointmentRepo;


        }

        public int Save()
        {
            return _context.SaveChanges();
        }



    }
}
