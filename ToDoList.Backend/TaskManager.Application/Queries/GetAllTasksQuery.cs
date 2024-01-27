using TaskManager.Application.Interface;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries
{
    public class GetAllTasksQuery : BaseQuery<IEnumerable<Task>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTasksQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override IEnumerable<Task> Execute()
        {
            return _unitOfWork.Tasks.Where(task => true);            
        }

        public override void Validate() {}
    }
}
