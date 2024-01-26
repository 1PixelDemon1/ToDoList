using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetAllUsersQuery : BaseQuery<ICollection<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUsersQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override ICollection<User> Execute()
        {
            return _unitOfWork.Users.Where(user => true);
        }

        public override void Validate(){}
    }
}
