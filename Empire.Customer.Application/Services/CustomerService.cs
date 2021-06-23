using Empire.Customer.Application.Interfaces;
using Empire.Customer.Application.ViewModels;
using Empire.Customer.Domain.Commands;
using Empire.Infra.Core.Bus;
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
    }
}
