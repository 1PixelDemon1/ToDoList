using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagerDbContext _db;

        public IRepository<User> Users { get; set; }
        public IRepository<Task> Tasks { get; set; }
        public IRepository<TaskGroup> TaskGroups { get; set; }

        public UnitOfWork(TaskManagerDbContext db)
        {
            _db = db;
            Users = new Repository<User>(_db);
            Tasks = new Repository<Task>(_db);
            TaskGroups = new Repository<TaskGroup>(_db);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
