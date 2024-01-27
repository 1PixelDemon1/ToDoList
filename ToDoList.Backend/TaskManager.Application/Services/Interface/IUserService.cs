using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services.Interface
{
    public interface IUserService
    {
        User GetUser(int id);
        IEnumerable<User>? GetAll();
        IEnumerable<Task>? GetTasks(int userId);
        IEnumerable<TaskGroup>? GetTaskGroups(int userId);
        IEnumerable<TaskGroup>? GetAccessibleGroups(int userId);

        void AddUser(User user);
        void RemoveUser(int id);
        void UpdateUser(int id, User user);
        void AddTask(int userId, Task task);
        void AddTaskGroup(int userId, TaskGroup taskGroup);
    }
}
