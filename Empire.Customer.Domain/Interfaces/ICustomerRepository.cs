using System.Collections.Generic;
using System.Threading.Tasks;
using E=Empire.Customer.Domain.Models;

namespace Empire.Customer.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(E.Customer customer);
        
        Task<IEnumerable<E.Customer>> GetAllCustomer();

        Task<E.Customer> GetCustomerById(int Id);
    }
}
