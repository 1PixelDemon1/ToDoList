using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Queries
{
    public abstract class BaseQuery<T> : IQuery<T>
    {
        public T Handle() 
        {
            Validate();
            return Execute();
        }

        public abstract void Validate();
        public abstract T Execute();
    }
}
