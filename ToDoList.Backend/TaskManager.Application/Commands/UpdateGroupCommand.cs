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
    public class UpdateGroupCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _taskGroupId;
        private readonly TaskGroup _newTaskGroup;

        public UpdateGroupCommand(IUnitOfWork unitOfWork, int taskGroupId, TaskGroup newTaskGroup)
        {
            _unitOfWork = unitOfWork;
            _taskGroupId = taskGroupId;
            _newTaskGroup = newTaskGroup;
        }

        public override void Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _taskGroupId);
            if (group == null) throw new GroupNotFoundException(_taskGroupId);
            group.Update(_newTaskGroup);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            _newTaskGroup.Validate();
            if (_taskGroupId <= 0) throw new GroupNotFoundException(_taskGroupId);
        }
    }
}
