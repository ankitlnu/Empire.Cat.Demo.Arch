using Empire.Customer.Domain.Interfaces;
using Empire.Infra.Data;
using System;
using System.Threading.Tasks;

namespace Empire.Customer.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepository repository;
        public CustomerRepository(Func<string, IRepository> factory)
        {
            repository = factory(nameof(SQLReadWriteConnectionRepository));
        }

        public Task<bool> AddCustomer(Domain.Models.Customer customer)
        {
            var parameter = new
            {
                Name = customer.Name,
                Description = customer.Description,
            };

            return repository.GetScalarValue<bool>("dbo.iff_AddDummyCustomer", parameter);
        }
    }
}
