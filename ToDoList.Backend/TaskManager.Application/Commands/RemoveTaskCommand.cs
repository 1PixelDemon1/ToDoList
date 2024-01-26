using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Commands
{
    public class RemoveTaskCommand : BaseCommand
    {

        private readonly int _id;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTaskCommand(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override void Execute()
        {
            Task? task = _unitOfWork.Tasks.Where(task => task.Id == _id).FirstOrDefault();
            if (task == null) 
            {
                throw new TaskNotFoundException(_id);
            }
            // TODO 
            task.Author.RemoveTask(task.Id);
            foreach (var taskGroup in task.TaskGroups)
            {
                taskGroup.RemoveTask(task.Id);
            }
            _unitOfWork.Tasks.Remove(task);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            if (_id <= 0) throw new TaskNotFoundException(_id);
        }
    }
}
