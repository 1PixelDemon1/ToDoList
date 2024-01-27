using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace TaskManager.Domain.Entities
{
    public class TaskGroup
    {
        public User Author { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Task>? Tasks { get; private set; }
        public bool IsPrivate { get; set; } = true;
        public ICollection<User>? AllowedUsers { get; private set; }

        public TaskGroup() {}

        public TaskGroup(User author, string name, ICollection<Task>? tasks, bool isPrivate, ICollection<User>? allowedUsers)
        {
            Author = author;
            Name = name;
            Tasks = tasks;
            IsPrivate = isPrivate;
            AllowedUsers = allowedUsers;

            Validate();
        }

        public void Update(TaskGroup taskGroup)
        {
            taskGroup.Validate();

            Author = taskGroup.Author;
            Name = taskGroup.Name;
            Tasks = taskGroup.Tasks;
            IsPrivate = taskGroup.IsPrivate;
            AllowedUsers = taskGroup.AllowedUsers;
        }

        public void Validate()
        {
            if(string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException($"invalid name: {Name}");
            }

            var allowedUsers = AllowedUsers != null && AllowedUsers.Count > 0;
            
            if (IsPrivate && allowedUsers)
            {
                throw new ArgumentException("private group cannot have any allowed users");
            }
        }

        public void AddTask(Task task)
        {
            task.Validate();

            if(Tasks == null)
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
            if (task != null) 
            { 
                Tasks?.Remove(task);
            }
        }

        public void AddAllowedUser(User allowedUser)
        {
            if (IsPrivate) throw new ArgumentException("private task group cannot have any allowed users");
            
            allowedUser.Validate();
            if(AllowedUsers == null)
            {
                AllowedUsers = new List<User> { allowedUser };
            }
            else
            {
                AllowedUsers.Add(allowedUser);
            }
        }

        public void RemoveAllowedUser(int id)
        {
            User? allowedUser = AllowedUsers?.FirstOrDefault(user => user.Id == id);
            if(allowedUser != null)
            {
                AllowedUsers?.Remove(allowedUser);
            }
        }

        public void SetPrivate(bool isPrivate)
        {
            IsPrivate = isPrivate;
            if(IsPrivate)
            {
                AllowedUsers?.Clear();
            }
        }
    }
}
