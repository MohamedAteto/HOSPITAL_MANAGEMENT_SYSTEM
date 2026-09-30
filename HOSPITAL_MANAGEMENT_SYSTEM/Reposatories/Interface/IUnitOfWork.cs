namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface
{
    public interface IUnitOfWork
    {
             IDepartmentRepo DepartmentRepo { get; set; }
         IDoctoRepo doctoRepo { get; set; }

        int Save();
    }
}
