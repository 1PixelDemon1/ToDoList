using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetAllTaskGroupsQuery : BaseQuery<IEnumerable<TaskGroup>?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTaskGroupsQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override IEnumerable<TaskGroup>? Execute()
        {
            return _unitOfWork.TaskGroups.Where(group => true);
        }

        public override void Validate() {}
    }
}
