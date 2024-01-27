using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries
{
    public class GetTaskQuery : BaseQuery<Task>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public GetTaskQuery(IUnitOfWork unitOfWork, int id)
        {
            _id = id;
            _unitOfWork = unitOfWork;
        }
        public override Task Execute()
        {
            var task = _unitOfWork.Tasks.Get(task => task.Id == _id);
            if (task == null) throw new TaskNotFoundException(_id);
            return task;
        }

        public override void Validate()
        {
            if(_id <= 0) throw new TaskNotFoundException(_id);
        }
    }
}
