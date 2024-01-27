using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using TaskManager.Application.Commands;
using TaskManager.Application.Interface;
using TaskManager.Application.Queries;
using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services
{
    public class TaskGroupService : ITaskGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskGroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAllowedUser(int taskGroupId, int userId)
        {
            new AddAllowedUserCommand(_unitOfWork, taskGroupId, userId).Handle();
        }

        public void AddTask(int taskGroupId, int taskId)
        {
            new AddTaskToGroupCommand(_unitOfWork, taskGroupId, taskId).Handle();
        }

        public IEnumerable<TaskGroup>? GetAll()
        {
            return new GetAllTaskGroupsQuery(_unitOfWork).Handle();
        }

        public IEnumerable<User>? GetAllowedUsers(int taskGroupId)
        {
            return new GetAllowedUsersFromGroupQuery(_unitOfWork, taskGroupId).Handle();
        }

        public User GetOwner(int taskGroupId)
        {
            return new GetGroupAuthorQuery(_unitOfWork, taskGroupId).Handle();
        }

        public TaskGroup GetTaskGroup(int id)
        {
            return new GetTaskGroupQuery(_unitOfWork, id).Handle();
        }

        public IEnumerable<Task>? GetTasks(int taskGroupId)
        {
            return new GetTasksFromGroupQuery(_unitOfWork, taskGroupId).Handle();
        }

        public void RemoveAllowedUser(int taskGroupId, int userId)
        {
            new RemoveAllowedUserCommand(_unitOfWork, taskGroupId, userId).Handle();
        }

        public void RemoveTask(int taskGroupId, int taskId)
        {
            new RemoveTaskFromGroupCommand(_unitOfWork, taskGroupId, taskId).Handle();
        }

        public void RemoveTaskGroup(int id)
        {
            new RemoveTaskGroupCommand(_unitOfWork, id).Handle();
        }

        public void UpdateTaskGroup(int taskGroupId, TaskGroup taskGroup)
        {
            new UpdateGroupCommand(_unitOfWork, taskGroupId, taskGroup).Handle();
        }
    }
}
