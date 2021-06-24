using Empire.Customer.Domain.Commands;
using Empire.Customer.Domain.Interfaces;
using Empire.Customer.Domain.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using E=Empire.Customer.Domain.Models;
namespace Empire.Customer.Domain.CommandHandlers
{
    public class CustomerCommandHandler : 
        IRequestHandler<CreateCustomerCommand, bool>,
        IRequestHandler<GetAllCustomerQuery, IEnumerable<E.Customer>>,
        IRequestHandler<GetCustomerByIdQuery, E.Customer>
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

        public Task<IEnumerable<E.Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            return customerRepository.GetAllCustomer();
        }

        public Task<E.Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return customerRepository.GetCustomerById(request.Id);
        }
    }
}
