using TaskManager.Domain.Entities;

namespace TaskManager.Api.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DeadLine { get; set; }
        public TaskState State { get; set; }
    }
}
