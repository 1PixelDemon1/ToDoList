using TaskManager.Application.Interface;
using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTask(Task task)
        {
            throw new NotImplementedException();
        }

        public ICollection<Task>? GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetOwner(int taskGroupId)
        {
            throw new NotImplementedException();
        }

        public Task? GetTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public ICollection<TaskGroup> GetTaskGroups(int taskId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
