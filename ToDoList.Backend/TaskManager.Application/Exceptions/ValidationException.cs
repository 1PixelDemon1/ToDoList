using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(object obj, string message) : base($"validation exception occured validating {obj} : {message}") { }
    }
}
