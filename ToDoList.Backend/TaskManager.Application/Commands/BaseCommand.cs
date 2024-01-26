using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public void Handle()
        {
            Validate();
            Execute();
        }

        public abstract void Validate();

        public abstract void Execute();
    }
}
