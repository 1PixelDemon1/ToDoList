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
    public class AddTaskToGroupCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _groupId;
        private readonly int _taskId;

        public AddTaskToGroupCommand(IUnitOfWork unitOfWork, int groupId, int taskId)
        {
            _unitOfWork = unitOfWork;
            _groupId = groupId;
            _taskId = taskId;
        }

        public override void Execute()
        {
            var taskGroup = _unitOfWork.TaskGroups.Get(group => group.Id == _groupId, "Tasks");
            if (taskGroup == null) throw new GroupNotFoundException(_groupId);
            var task = _unitOfWork.Tasks.Get(task => task.Id == _taskId);
            if (task == null) throw new TaskNotFoundException(_taskId);
            taskGroup.AddTask(task);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            if (_groupId <= 0) throw new GroupNotFoundException(_groupId);
            if (_taskId <= 0) throw new TaskNotFoundException(_taskId);
        }
    }
}
