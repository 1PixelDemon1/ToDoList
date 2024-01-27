using TaskManager.Application.Commands;
using TaskManager.Application.Interface;
using TaskManager.Application.Queries;
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

        public IEnumerable<Task>? GetAll()
        {
            return new GetAllTasksQuery(_unitOfWork).Handle();
        }

        public User GetOwner(int taskId)
        {
            return new GetTaskAuthorQuery(_unitOfWork, taskId).Handle();
        }

        public Task GetTask(int taskId)
        {
            return new GetTaskQuery(_unitOfWork, taskId).Handle();
        }

        public IEnumerable<TaskGroup>? GetTaskGroups(int taskId)
        {
            return new GetGroupsFromTaskQuery(_unitOfWork, taskId).Handle();
        }

        public void RemoveTask(int id)
        {
            new RemoveTaskCommand(_unitOfWork, id).Handle();
        }

        public void UpdateTask(int taskId, Task task)
        {
            new UpdateTaskCommand(_unitOfWork, taskId, task);
        }
    }
}
