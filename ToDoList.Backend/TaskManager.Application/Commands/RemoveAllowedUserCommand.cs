using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;

namespace TaskManager.Application.Commands
{
    public class RemoveAllowedUserCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _groupId;
        private readonly int _userId;

        public RemoveAllowedUserCommand(IUnitOfWork unitOfWork, int groupId, int userId)
        {
            _unitOfWork = unitOfWork;
            _groupId = groupId;
            _userId = userId;
        }
        public override void Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _groupId, "AllowedUsers");
            if (group == null) throw new GroupNotFoundException(_groupId);
            group.RemoveAllowedUser(_userId);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            if (_groupId <= 0) throw new GroupNotFoundException(_groupId);
            if (_userId <= 0) throw new UserNotFoundException(_userId);
        }
    }
}
