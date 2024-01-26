namespace TaskManager.Application.Exceptions
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(int id) : base($"user with given id({id}) not found!") { }
    }
}
