using System.Threading.Tasks;
using E=Empire.Customer.Domain.Models;

namespace Empire.Customer.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> AddCustomer(E.Customer customer);

        //Todo
        //Task<Customer> GetCustomer(int id);
    }
}
