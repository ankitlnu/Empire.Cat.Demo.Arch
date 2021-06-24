using Empire.Customer.IoC.Extentions;
using Microsoft.Extensions.DependencyInjection;

namespace Empire.Core.IoC
{
    public static class CustomerDependencyContainer
    {
        public static void RegisterCustomerServices(IServiceCollection services)
        {
            CoreDependencyContainer.RegisterCoreServices(services);

            services.RegisterCustomerServices();
        }
    }
}
