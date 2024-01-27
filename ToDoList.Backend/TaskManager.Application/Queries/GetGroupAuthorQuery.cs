using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetGroupAuthorQuery : BaseQuery<User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public GetGroupAuthorQuery(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override User Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _id, "Author");
            if (group == null) throw new GroupNotFoundException(_id);
            if (group.Author == null) throw new ApplicationException("group has no author");
            return group.Author;
        }

        public override void Validate()
        {
            if (_id <= 0) throw new GroupNotFoundException(_id);
        }
    }
}
