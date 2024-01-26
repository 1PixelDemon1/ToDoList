using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands
{
    public class AddUserCommand : BaseCommand
    {
        private readonly User _user;
        private readonly IUnitOfWork _unitOfWork;

        public AddUserCommand(IUnitOfWork unitOfWork, User user)
        {
            _unitOfWork = unitOfWork;
            _user = user;
        }

        public override void Execute()
        {
            _unitOfWork.Users.Add(_user);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            _user.Validate();
        }
    }
}
