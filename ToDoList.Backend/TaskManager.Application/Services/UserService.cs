using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services
{
    public class UserService : IUserService
    {
        public void AddNewTaskGroup(int userId, TaskGroup taskGroup)
        {
            throw new NotImplementedException();
        }

        public void AddTask(int userId, Task task)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public ICollection<User>? GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<TaskGroup>? GetTaskGroups(int userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Task>? GetTasks(int userId)
        {
            throw new NotImplementedException();
        }

        public User? GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(int userId, int taskId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTaskGroup(int userId, int taskGroupId)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
