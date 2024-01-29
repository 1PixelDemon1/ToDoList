using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Application.Interface;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetUserByEmailQuery : BaseQuery<User>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly string _email;

        public GetUserByEmailQuery(IUnitOfWork unitOfWork, string email)
        {
            _unitOfWork = unitOfWork;
            _email = email;
        }

        public override User Execute()
        {
            var user = _unitOfWork.Users.Get(user => user.Email.ToLower() == _email.ToLower());
            if(user == null)
            {
                throw new ApplicationException($"cant find user with given email: {_email}");
            }
            return user;
        }

        public override void Validate()
        {
            var emailValidator = new EmailAddressAttribute();
            if (!emailValidator.IsValid(_email))
            {
                throw new ArgumentException($"invalid email address: {_email}");
            }
        }
    }
}
