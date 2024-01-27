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

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(task => task.Author)
                .WithMany(author => author.Tasks);
            modelBuilder.Entity<Task>()
                .HasMany(task => task.TaskGroups)
                .WithMany(taskGroup => taskGroup.Tasks);
            modelBuilder.Entity<TaskGroup>()
                .HasOne(group => group.Author)
                .WithMany(user => user.TaskGroups);
            modelBuilder.Entity<TaskGroup>()
                .HasMany(group => group.AllowedUsers)
                .WithMany(user => user.AccessibleTaskGroups);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
