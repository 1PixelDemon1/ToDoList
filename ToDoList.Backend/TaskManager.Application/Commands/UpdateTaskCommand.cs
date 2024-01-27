using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Commands
{
    public class UpdateTaskCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _taskId;
        private readonly Task _newTask;

        public UpdateTaskCommand(IUnitOfWork unitOfWork, int taskId, Task newTask)
        {
            _unitOfWork = unitOfWork;
            _taskId = taskId;
            _newTask = newTask;
        }

        public override void Execute()
        {
            var task = _unitOfWork.Tasks.Get(task => task.Id == _taskId);
            if (task == null) throw new TaskNotFoundException(_taskId);
            task.Update(_newTask);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            _newTask.Validate();
            if (_taskId <= 0) throw new TaskNotFoundException(_taskId);
        }
    }
}
