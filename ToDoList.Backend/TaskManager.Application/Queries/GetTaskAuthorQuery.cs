using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries
{
    public class GetTaskAuthorQuery : BaseQuery<User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public GetTaskAuthorQuery(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override User Execute()
        {
            var task = _unitOfWork.Tasks.Get(task => task.Id == _id, "Author");
            if (task == null) throw new TaskNotFoundException(_id);
            if (task.Author == null) throw new ApplicationException("task has no author");
            return task.Author;
        }

        public override void Validate()
        {
            if (_id <= 0) throw new TaskNotFoundException(_id);
        }
    }
}
