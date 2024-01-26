using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interface;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> dbSet;

        private readonly TaskManagerDbContext _dbContext;

        public Repository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T? Get(Func<T, bool> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public ICollection<T>? Where(Func<T, bool> filter)
        {
            return dbSet.Where(filter) as ICollection<T>;
        }
    }
}
