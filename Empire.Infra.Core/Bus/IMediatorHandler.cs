using Empire.Infra.Core.Commands;
using System.Threading.Tasks;

namespace Empire.Infra.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<TResponse> Send<TRequest, TResponse>(TRequest command) where TRequest : Command<TResponse>;
    }
}
