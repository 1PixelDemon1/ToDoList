using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services.Interface
{
    public interface ITaskService
    {
        Task? GetTask(int taskId);
        ICollection<Task>? GetAll();
        ICollection<TaskGroup> GetTaskGroups(int taskId);
        User GetOwner(int taskGroupId);

        void AddTask(Task task);
        void RemoveTask(int id);
        void UpdateTask(Task task);
    }
}
