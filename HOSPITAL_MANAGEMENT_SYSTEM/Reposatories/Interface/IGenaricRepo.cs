namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface
{
    public interface IGenaricRepo<T> where T : class
    {
        public ICollection<T> GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public T GetById(int id);
        public void Save();
    }
}
