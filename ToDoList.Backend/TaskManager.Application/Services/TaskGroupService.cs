using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services
{
    public class TaskGroupService : ITaskGroupService
    {
        public void AddNewAllowedUser(int taskGroupId, User user)
        {
            throw new NotImplementedException();
        }

        public void AddTask(int taskGroupId, Task task)
        {
            throw new NotImplementedException();
        }

        public void AddTaskGroup(TaskGroup taskGroup)
        {
            throw new NotImplementedException();
        }

        public ICollection<TaskGroup>? GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAllowedUsers(int taskGroupId)
        {
            throw new NotImplementedException();
        }

        public User GetOwner(int taskGroupId)
        {
            throw new NotImplementedException();
        }

        public TaskGroup? GetTaskGroup(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Task>? GetTasks(int taskGroupId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllowedUser(int taskGroupId, int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(int taskGroupId, int taskId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTaskGroup(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTaskGroup(TaskGroup taskGroup)
        {
            throw new NotImplementedException();
        }
    }
}
