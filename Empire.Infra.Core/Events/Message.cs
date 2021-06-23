using MediatR;

namespace Empire.Infra.Core.Events
{
    public abstract class Message<T> : IRequest<T>
    {
        public string MessageType { get; protected set; }

        protected Message() => MessageType = GetType().Name;
    }    
}
