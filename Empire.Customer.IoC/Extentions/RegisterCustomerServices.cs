using Empire.Customer.Application.Interfaces;
using Empire.Customer.Application.Services;
using Empire.Customer.Domain.CommandHandlers;
using Empire.Customer.Domain.Commands;
using Empire.Customer.Domain.Interfaces;
using Empire.Customer.Domain.Queries;
using Empire.Customer.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using E = Empire.Customer.Domain.Models;


namespace Empire.Customer.IoC.Extentions
{
   public static class RegisterCustomer
    {
        public static void RegisterCustomerServices(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<GetAllCustomerQuery, IEnumerable<E.Customer>>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<GetCustomerByIdQuery, E.Customer>, CustomerCommandHandler>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
