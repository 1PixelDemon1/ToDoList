using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services.Interface
{
    public interface ITaskGroupService
    {
        TaskGroup? GetTaskGroup(int id);
        ICollection<TaskGroup>? GetAll();
        ICollection<Task>? GetTasks(int taskGroupId);
        User GetOwner(int taskGroupId);
        ICollection<User> GetAllowedUsers(int taskGroupId);

        void AddTaskGroup(TaskGroup taskGroup);
        void RemoveTaskGroup(int id);
        void UpdateTaskGroup(TaskGroup taskGroup);
        void AddTask(int taskGroupId, Task task);
        void RemoveTask(int taskGroupId, int taskId);
        void AddNewAllowedUser(int taskGroupId, User user);
        void RemoveAllowedUser(int taskGroupId, int userId);
    }
}
