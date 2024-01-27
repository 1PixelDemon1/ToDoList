using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetUserQuery : BaseQuery<User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _id;

        public GetUserQuery(IUnitOfWork unitOfWork, int id)
        {
            _unitOfWork = unitOfWork;
            _id = id;
        }

        public override User Execute()
        {
            var user = _unitOfWork.Users.Get(user => user.Id == _id);
            if (user == null) throw new UserNotFoundException(_id);
            return user;
        }

        public override void Validate()
        {
            if (_id <= 0) throw new UserNotFoundException(_id);
        }
    }
}
