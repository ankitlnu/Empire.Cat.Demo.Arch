using Empire.Customer.Application.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using E = Empire.Customer.Domain.Models;

namespace Empire.Customer.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(CustomerDTO customer);
        Task<IEnumerable<E.Customer>> GetAllCustomer();
        Task<E.Customer> GetCustomerById(int Id);
    }
}
