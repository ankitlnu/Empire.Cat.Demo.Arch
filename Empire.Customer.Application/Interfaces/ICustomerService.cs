using Empire.Customer.Application.ViewModels;
using System.Threading.Tasks;

namespace Empire.Customer.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(CustomerDTO customer);
    }
}
