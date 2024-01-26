using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Commands
{
    public class AddTaskCommand : BaseCommand
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly Task _task;

        public AddTaskCommand(IUnitOfWork unitOfWork, Task task)
        {
            _unitOfWork = unitOfWork;
            _task = task;
        }

        public override void Execute()
        {
            _unitOfWork.Tasks.Add(_task);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            _task.Validate();
        }
    }
}
