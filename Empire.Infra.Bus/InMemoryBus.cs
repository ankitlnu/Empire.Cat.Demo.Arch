using Empire.Infra.Core.Bus;
using Empire.Infra.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace Empire.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> Send<TRequest, TResponse>(TRequest command) where TRequest : Command<TResponse>
        {
            return _mediator.Send(command);
        }
    }
}
