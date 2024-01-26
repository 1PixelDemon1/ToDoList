using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Interface
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        T Get(Func<T, bool> filter);
        ICollection<T> Where(Func<T, bool> filter);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
