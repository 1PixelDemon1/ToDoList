using System.ComponentModel.DataAnnotations;

namespace TaskManager.Domain.Entities
{
    public class Task
    {
        public User Author { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime? DeadLine { get; set; }
        public TaskState State { get; private set; }
        public ICollection<TaskGroup>? TaskGroups { get; private set; }

        public Task() {}

        public Task(User author, string name, string description, DateTime? deadLine, TaskState state, ICollection<TaskGroup>? taskGroups = null)
        {
            Author = author;
            Name = name;
            Description = description;
            DeadLine = deadLine;
            State = state;
            TaskGroups = taskGroups;

            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException($"invalid name: {Name}");
            }
            if(Description == null)
            {
                throw new ArgumentException($"description cant be null");
            }
        }

        public void Update(Task newTask)
        {
            newTask.Validate();

            Author = newTask.Author;
            Name = newTask.Name;
            Description = newTask.Description;
            DeadLine = newTask.DeadLine;
            State = newTask.State;
            TaskGroups = newTask.TaskGroups;
        }

        public void AddToGroup(TaskGroup taskGroup)
        {
            taskGroup.Validate();
            if(TaskGroups == null)
            {
                TaskGroups = new List<TaskGroup> { taskGroup };
            }
            else
            {
                TaskGroups.Add(taskGroup);
            }
        }

        public void RemoveFromGroup(int id)
        {
            TaskGroup? taskGroup = TaskGroups?.FirstOrDefault(taskGroup => taskGroup.Id == id);

            if(taskGroup != null)
            {
                taskGroup.RemoveTask(this.Id);
                TaskGroups!.Remove(taskGroup);
            }
        }

    }
}
