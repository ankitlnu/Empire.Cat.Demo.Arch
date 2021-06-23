using Empire.Infra.Core.Commands;

namespace Empire.Customer.Domain.Commands
{
    public abstract class CustomerCommand : Command<bool>
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
    }
}
