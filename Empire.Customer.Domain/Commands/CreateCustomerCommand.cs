namespace Empire.Customer.Domain.Commands
{
    public class CreateCustomerCommand : CustomerCommand
    {
        public CreateCustomerCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
