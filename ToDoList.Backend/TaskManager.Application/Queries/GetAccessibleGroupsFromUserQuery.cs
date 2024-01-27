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
    public class GetAccessibleGroupsFromUserQuery : BaseQuery<IEnumerable<TaskGroup>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _userId;

        public GetAccessibleGroupsFromUserQuery(IUnitOfWork unitOfWork, int userId)
        {
            _unitOfWork = unitOfWork;
            _userId = userId;
        }

        public override IEnumerable<TaskGroup>? Execute()
        {
            var user = _unitOfWork.Users.Get(user => user.Id == _userId, "AccessibleTaskGroups");
            if (user == null) throw new UserNotFoundException(_userId);
            return user.AccessibleTaskGroups;
        }

        public override void Validate()
        {
            if (_userId <= 0) throw new UserNotFoundException(_userId);
        }
    }
}
