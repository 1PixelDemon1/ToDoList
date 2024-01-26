namespace TaskManager.Application.Exceptions
{
    public class GroupNotFoundException : ApplicationException
    {
        public GroupNotFoundException(int id) : base($"group with given id({id}) not found!") { }
    }
}
