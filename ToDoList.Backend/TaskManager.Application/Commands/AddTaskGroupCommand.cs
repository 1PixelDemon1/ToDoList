using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands
{
    public class AddTaskGroupCommand : BaseCommand
    {
        private readonly TaskGroup _taskGroup;
        private readonly IUnitOfWork _unitOfWork;

        public AddTaskGroupCommand(IUnitOfWork unitOfWork, TaskGroup taskGroup)
        {
            _unitOfWork = unitOfWork;
            _taskGroup = taskGroup;
        }

        public override void Execute()
        {
            _unitOfWork.TaskGroups.Add(_taskGroup);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            _taskGroup.Validate();
        }
    }
}