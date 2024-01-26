using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Data
{
    public class TaskManagerDbContext : DbContext
    {

        public DbSet<Task> Tasks{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
