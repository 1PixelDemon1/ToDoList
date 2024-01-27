using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries
{
    public class GetTasksFromGroupQuery : BaseQuery<IEnumerable<Task>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public GetTasksFromGroupQuery(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override IEnumerable<Task>? Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _id, "Tasks");
            if (group == null) throw new GroupNotFoundException(_id);
            return group.Tasks;
        }

        public override void Validate()
        {
            if (_id <= 0) throw new GroupNotFoundException(_id);
        }
    }
}
