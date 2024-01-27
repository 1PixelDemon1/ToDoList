using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands
{
    public class UpdateUserCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;
        private readonly User _newUser;

        public UpdateUserCommand(IUnitOfWork unitOfWork, int id, User newUser)
        {
            _unitOfWork = unitOfWork;
            _id = id;
            _newUser = newUser;
        }

        public override void Execute()
        {
            var user = _unitOfWork.Users.Get(user => user.Id == _id);
            if (user == null) throw new UserNotFoundException(_id);
            user.Update(_newUser);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            _newUser.Validate();
            if (_id <= 0) throw new UserNotFoundException(_id);
        }
    }
}
