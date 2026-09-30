using HOSPITAL_MANAGEMENT_SYSTEM.Models;
using HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Implementation;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface
{
      
    public interface IDoctoRepo : IGenaricRepo<Doctor>
    {
    

        IEnumerable<Doctor> GetBySpecialization(string specialization);

        IEnumerable<Doctor> GetDetails();


    }
}
