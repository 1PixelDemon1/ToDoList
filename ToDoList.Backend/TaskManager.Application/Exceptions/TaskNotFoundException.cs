namespace TaskManager.Application.Exceptions
{
    public class TaskNotFoundException : ApplicationException
    {
        public TaskNotFoundException(int id) : base($"task with given id({id}) not found!") { }
    }
}
