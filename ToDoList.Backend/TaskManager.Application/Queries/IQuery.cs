using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Queries
{
    public interface IQuery<T>
    {
        T Handle();
        protected void Validate();
        protected T Execute();
    }
}
