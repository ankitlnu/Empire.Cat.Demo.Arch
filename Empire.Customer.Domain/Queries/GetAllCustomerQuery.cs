using Empire.Infra.Core.Commands;
using System.Collections.Generic;
using E=Empire.Customer.Domain.Models;

namespace Empire.Customer.Domain.Queries
{
    public class GetAllCustomerQuery : Command<IEnumerable<E.Customer>>
    {
    }
}
