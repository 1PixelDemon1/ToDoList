using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries
{
    public class GetGroupsFromTaskQuery : BaseQuery<IEnumerable<TaskGroup>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;
        
        public GetGroupsFromTaskQuery(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override IEnumerable<TaskGroup>? Execute()
        {
            var task = _unitOfWork.Tasks.Get(task => task.Id == _id, "TaskGroups");
            if (task == null) throw new TaskNotFoundException(_id);
            return task.TaskGroups;
        }

        public override void Validate()
        {
            if (_id <= 0) throw new TaskNotFoundException(_id);
        }
    }
}
