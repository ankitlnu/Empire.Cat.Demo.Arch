using Empire.Customer.Application.Interfaces;
using Empire.Customer.Application.Services;
using Empire.Customer.Domain.CommandHandlers;
using Empire.Customer.Domain.Commands;
using Empire.Customer.Domain.Interfaces;
using Empire.Customer.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Empire.Core.IoC
{
    public static class CustomerDependencyContainer
    {
        public static void RegisterCustomerServices(IServiceCollection services)
        {
            CoreDependencyContainer.RegisterCoreServices(services);

            services.AddScoped<IRequestHandler<CreateCustomerCommand, bool>, CreateCustomerCommandHandler>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
