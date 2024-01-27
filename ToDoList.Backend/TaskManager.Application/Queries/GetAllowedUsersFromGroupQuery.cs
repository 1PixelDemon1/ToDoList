using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetAllowedUsersFromGroupQuery : BaseQuery<IEnumerable<User>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _groupId;

        public GetAllowedUsersFromGroupQuery(IUnitOfWork unitOfWork, int groupId)
        {
            _unitOfWork = unitOfWork;
            _groupId = groupId;
        }

        public override IEnumerable<User>? Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _groupId, "AllowedUsers");
            if (group == null) throw new GroupNotFoundException(_groupId);
            return group.AllowedUsers;
        }

        public override void Validate()
        {
            if (_groupId <= 0) throw new GroupNotFoundException(_groupId);
        }
    }
}
