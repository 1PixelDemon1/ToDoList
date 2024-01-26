using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Interface
{
    public interface IUnitOfWork
    {
        public IRepository<User> Users { get; set; }
        public IRepository<Task> Tasks { get; set; }
        public IRepository<TaskGroup> TaskGroups { get; set; }
        void SaveChanges();
    }
}
