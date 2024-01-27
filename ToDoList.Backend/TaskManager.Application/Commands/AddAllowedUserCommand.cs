using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands
{
    public class AddAllowedUserCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _taskGroupId;
        private readonly int _userId;

        public AddAllowedUserCommand(IUnitOfWork unitOfWork, int taskGroupId, int userId)
        {
            _unitOfWork = unitOfWork;
            _taskGroupId = taskGroupId;
            _userId = userId;
        }

        public override void Execute()
        {
            var taskGroup = _unitOfWork.TaskGroups.Get(group => group.Id == _taskGroupId, "AllowedUsers");
            if (taskGroup == null) throw new GroupNotFoundException(_taskGroupId);
            var allowedUser = _unitOfWork.Users.Get(user => user.Id == _userId);
            if (allowedUser == null) throw new UserNotFoundException(_userId);
            taskGroup.AddAllowedUser(allowedUser);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            if (_taskGroupId <= 0) throw new GroupNotFoundException(_taskGroupId);
            if (_userId <= 0) throw new UserNotFoundException(_userId);
        }
    }
}
