using HOSPITAL_MANAGEMENT_SYSTEM.Data;
using HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_MANAGEMENT_SYSTEM.Reposatories.Implementation
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;


        public GenaricRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbSet.Find(id);

            if (item is null)
                throw new ArgumentException($"Entity with id {id} not found.");

            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {

            return _dbSet.Find(id)
                ?? throw new ArgumentException($"Entity with id {id} not found.");
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }


     
    }
}
