using Empire.Infra.Core.Commands;
using E = Empire.Customer.Domain.Models;

namespace Empire.Customer.Domain.Queries
{
    public abstract class CustomerQuery : Command<E.Customer>
    {
        public int Id { get; protected set; }
    }
}
