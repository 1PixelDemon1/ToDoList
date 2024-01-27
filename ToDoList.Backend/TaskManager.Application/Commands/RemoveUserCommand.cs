using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;

namespace TaskManager.Application.Commands
{
    public class RemoveUserCommand : BaseCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public RemoveUserCommand(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override void Execute()
        {
            var user = _unitOfWork.Users.Get(user => user.Id == _id);
            if (user == null) throw new UserNotFoundException(_id);
            _unitOfWork.Users.Remove(user);
            _unitOfWork.SaveChanges();
        }

        public override void Validate()
        {
            if (_id <= 0) throw new UserNotFoundException(_id);
        }
    }
}
