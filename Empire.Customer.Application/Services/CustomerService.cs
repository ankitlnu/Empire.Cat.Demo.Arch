using Empire.Customer.Application.Interfaces;
using Empire.Customer.Application.ViewModels;
using Empire.Customer.Domain.Commands;
using Empire.Customer.Domain.Queries;
using Empire.Infra.Core.Bus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empire.Customer.Application.Services
{
    public class CustomerService : ICustomerService
    {        
        private readonly IMediatorHandler bus;

        public CustomerService(IMediatorHandler bus)
        {   
            this.bus = bus;
        }

        public Task<bool> AddCustomer(CustomerDTO customer)
        {
            var createCustomerCommand = new CreateCustomerCommand(
                  customer.Name,
                  customer.Description
                );

           return bus.Send<CreateCustomerCommand, bool>(createCustomerCommand);
        }

        public Task<IEnumerable<Domain.Models.Customer>> GetAllCustomer()
        {
            return bus.Send<GetAllCustomerQuery, IEnumerable<Domain.Models.Customer>>(new GetAllCustomerQuery { });
        }

        public Task<Domain.Models.Customer> GetCustomerById(int Id)
        {
            return bus.Send<GetCustomerByIdQuery, Domain.Models.Customer>(new GetCustomerByIdQuery(Id));
        }
    }
}
