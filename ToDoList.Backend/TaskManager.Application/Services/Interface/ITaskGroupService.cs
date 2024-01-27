using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services.Interface
{
    public interface ITaskGroupService
    {
        TaskGroup GetTaskGroup(int id);
        IEnumerable<TaskGroup>? GetAll();
        IEnumerable<Task>? GetTasks(int taskGroupId);
        User GetOwner(int taskGroupId);
        IEnumerable<User>? GetAllowedUsers(int taskGroupId);

        void RemoveTaskGroup(int id);
        void UpdateTaskGroup(int taskGroupId, TaskGroup taskGroup);
        void AddTask(int taskGroupId, int taskId);
        void RemoveTask(int taskGroupId, int taskId);
        void AddAllowedUser(int taskGroupId, int userId);
        void RemoveAllowedUser(int taskGroupId, int userId);
    }
}
