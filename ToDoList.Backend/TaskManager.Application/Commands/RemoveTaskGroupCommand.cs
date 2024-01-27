using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;

namespace TaskManager.Application.Commands
{
    public class RemoveTaskGroupCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public RemoveTaskGroupCommand(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override void Execute()
        {
            var group = _unitOfWork.TaskGroups.Get(group => group.Id == _id);
            if (group == null) throw new GroupNotFoundException(_id);
            _unitOfWork.TaskGroups.Remove(group);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            if (_id <= 0) throw new GroupNotFoundException(_id);
        }
    }
}
