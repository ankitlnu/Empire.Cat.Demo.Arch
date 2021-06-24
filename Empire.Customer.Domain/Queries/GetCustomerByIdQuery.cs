namespace Empire.Customer.Domain.Queries
{
    public class GetCustomerByIdQuery : CustomerQuery
    {
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
