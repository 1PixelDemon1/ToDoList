using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services.Interface
{
    public interface IUserService
    {
        User? GetUser(int id);
        ICollection<User>? GetAll();
        ICollection<Task>? GetTasks(int userId);
        ICollection<TaskGroup>? GetTaskGroups(int userId);

        void AddUser(User user);
        void RemoveUser(int id);
        void UpdateUser(User user);
        void AddTask(int userId, Task task);
        void RemoveTask(int userId, int taskId);
        void AddNewTaskGroup(int userId, TaskGroup taskGroup);
        void RemoveTaskGroup(int userId, int taskGroupId);
    }
}
