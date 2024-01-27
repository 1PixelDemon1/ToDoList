using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public ICollection<Task>? Tasks { get; private set; }
        public ICollection<TaskGroup>? TaskGroups { get; private set; }
        public ICollection<TaskGroup>? AccessibleTaskGroups { get; private set; }

        public User() {}

        public User(string fullName, string email, ICollection<Task>? tasks = null, ICollection<TaskGroup>? taskGroups = null, ICollection<TaskGroup>? accessibleTaskGroups = null)
        {
            FullName = fullName;
            Email = email;
            Tasks = tasks;
            TaskGroups = taskGroups;
            AccessibleTaskGroups = accessibleTaskGroups;
            Validate();
        }

        public void Update(User updatedUser)
        {
            updatedUser.Validate();
            FullName = updatedUser.FullName;
            Email = updatedUser.Email;
            Tasks = updatedUser.Tasks;
            TaskGroups = updatedUser.TaskGroups;
            AccessibleTaskGroups = updatedUser.AccessibleTaskGroups;
        }

        public void Validate()
        {
            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(Email))
            {
                throw new ArgumentException($"invalid email address: {Email}");
            }

            if (string.IsNullOrEmpty(FullName))
            {
                throw new ArgumentException($"invalid name: {FullName}");
            }
        }

        public void AddTask(Task task)
        {
            if (Tasks == null)
            {
                Tasks = new List<Task> { task };
            }
            else
            {
                Tasks.Add(task);
            }
        }

        public void RemoveTask(int id)
        {
            Task? task = Tasks?.FirstOrDefault(task => task.Id == id);
            if(task != null)
            {
                Tasks!.Remove(task);
            }
        }

        public void RemoveTaskGroup()
        {
            TaskGroup? taskGroup = TaskGroups?.FirstOrDefault(taskGroup => taskGroup.Id == Id);
            if(taskGroup != null)
            {
                TaskGroups!.Remove(taskGroup);
            }
        }

        public void AddTaskGroup(TaskGroup taskGroup)
        {
            if (TaskGroups == null)
            {
                TaskGroups = new List<TaskGroup> { taskGroup };
            }
            else
            {
                TaskGroups.Add(taskGroup);
            }
        }

        public void GetAccess(TaskGroup taskGroup)
        {
            taskGroup.AddAllowedUser(this);
            if(AccessibleTaskGroups == null)
            {
                AccessibleTaskGroups = new List<TaskGroup> { taskGroup };
            }
            else
            {
                AccessibleTaskGroups.Add(taskGroup);
            }
        }
    }
}
