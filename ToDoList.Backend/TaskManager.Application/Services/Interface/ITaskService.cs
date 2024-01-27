using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services.Interface
{
    public interface ITaskService
    {
        Task GetTask(int taskId);
        IEnumerable<Task>? GetAll();
        IEnumerable<TaskGroup>? GetTaskGroups(int taskId);
        User GetOwner(int taskId);

        void RemoveTask(int id);
        void UpdateTask(int taskId, Task task);
    }
}
