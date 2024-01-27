using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetTaskGroupQuery : BaseQuery<TaskGroup>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public GetTaskGroupQuery(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override TaskGroup Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _id);
            if (group == null) throw new GroupNotFoundException(_id);
            return group;
        }

        public override void Validate()
        {
            if (_id <= 0) throw new GroupNotFoundException(_id);
        }
    }
}
