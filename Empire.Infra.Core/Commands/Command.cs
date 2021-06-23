using Empire.Infra.Core.Events;
using System;

namespace Empire.Infra.Core.Commands
{
    public abstract class Command<T> : Message<T>
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
