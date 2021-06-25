using Dapper;
using Empire.Customer.Domain.Interfaces;
using Empire.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IEnumerable<Domain.Models.Customer>> GetAllCustomer()
        {
            return repository.GetAll<Domain.Models.Customer>("dbo.iff_GetAllDummyCustomer", new { });
        }

        public async Task<Domain.Models.Customer> GetCustomerById(int Id)
        {
            var parameter = new
            {
                Id
            };

            return await repository.DBContext(connection => 
            {
                return connection.QueryFirstOrDefaultAsync<Domain.Models.Customer>(
                    "dbo.iff_GetDummyCustomerById",
                      param:parameter,
                      commandType:System.Data.CommandType.StoredProcedure
                    );
            });
        }
    }
}
