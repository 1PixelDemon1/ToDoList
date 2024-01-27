using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;

namespace TaskManager.Application.Commands
{
    public class RemoveTaskFromGroupCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _groupId;
        private readonly int _taskId;

        public RemoveTaskFromGroupCommand(IUnitOfWork unitOfWork, int groupId, int taskId)
        {
            _unitOfWork = unitOfWork;
            _groupId = groupId;
            _taskId = taskId;
        }

        public override void Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _groupId, "Tasks");
            if (group == null) throw new GroupNotFoundException(_groupId);
            group.RemoveTask(_taskId);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            if (_groupId <= 0) throw new GroupNotFoundException(_groupId);
            if (_taskId <= 0) throw new TaskNotFoundException(_taskId);
        }
    }
}
