using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries
{
    public class GetTasksFromUserQuery : BaseQuery<IEnumerable<Task>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public GetTasksFromUserQuery(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override IEnumerable<Task>? Execute()
        {
            var user = _unitOfWork.Users.Get(user => user.Id == _id, "Tasks");
            if (user == null) throw new UserNotFoundException(_id);
            return user.Tasks;
        }

        public override void Validate()
        {
            if (_id <= 0) throw new UserNotFoundException(_id);
        }
    }
}
