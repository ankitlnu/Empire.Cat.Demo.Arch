using Empire.Customer.Domain.Commands;
using Empire.Customer.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using E=Empire.Customer.Domain.Models;
namespace Empire.Customer.Domain.CommandHandlers
{
    public class CustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new E.Customer
            {
                Name = request.Name,
                Description = request.Description,
            };

          return  customerRepository.AddCustomer(customer);
        }
    }
}
