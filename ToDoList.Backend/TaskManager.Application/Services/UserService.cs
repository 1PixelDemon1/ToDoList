using System.Net;
using TaskManager.Application.Commands;
using TaskManager.Application.Interface;
using TaskManager.Application.Queries;
using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTaskGroup(int userId, TaskGroup taskGroup)
        {
            User author = new GetUserQuery(_unitOfWork, userId).Handle();
            var newTaskGroup = new TaskGroup(author, taskGroup.Name, taskGroup.Tasks, taskGroup.IsPrivate, taskGroup.AllowedUsers);
            new AddTaskGroupCommand(_unitOfWork, newTaskGroup).Handle();
        }

        public void AddTask(int userId, Task task)
        {
            User author = new GetUserQuery(_unitOfWork, userId).Handle();
            var newTask = new Task(author, task.Name, task.Description, task.DeadLine, task.State, task.TaskGroups);
            new AddTaskCommand(_unitOfWork, newTask).Handle();
        }

        public void AddUser(User user)
        {
            new AddUserCommand(_unitOfWork, user).Handle();
        }

        public IEnumerable<User>? GetAll()
        {
            return new GetAllUsersQuery(_unitOfWork).Handle();
        }

        public IEnumerable<TaskGroup>? GetTaskGroups(int userId)
        {
            return new GetGroupsFromUserQuery(_unitOfWork, userId).Handle();
        }

        public IEnumerable<TaskGroup>? GetAccessibleGroups(int userId)
        {
            return new GetAccessibleGroupsFromUserQuery(_unitOfWork, userId).Handle();
        }

        public IEnumerable<Task>? GetTasks(int userId)
        {
            return new GetTasksFromUserQuery(_unitOfWork, userId).Handle();
        }

        public User GetUser(int id)
        {
            return new GetUserQuery(_unitOfWork, id).Handle();
        }

        public void RemoveUser(int id)
        {
            new RemoveUserCommand(_unitOfWork, id).Handle();
        }

        public void UpdateUser(int id, User user)
        {
            new UpdateUserCommand(_unitOfWork, id, user).Handle();
        }
    }
}
