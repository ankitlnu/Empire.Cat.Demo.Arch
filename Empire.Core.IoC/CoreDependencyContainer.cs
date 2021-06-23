
using Empire.Infra.Bus;
using Empire.Infra.Core.Bus;
using Empire.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Empire.Core.IoC
{
    public static class CoreDependencyContainer
    {
        public static void RegisterCoreServices(IServiceCollection services)
        {   
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped(RepositoryFactory);
            
            services.AddScoped<SQLReadWriteConnectionRepository>();
        }

        private static Func<string, IRepository> RepositoryFactory(IServiceProvider serviceProvider) 
        {
            return key =>
            {
                return key switch
                {
                    nameof(SQLReadWriteConnectionRepository) => serviceProvider.GetService<SQLReadWriteConnectionRepository>(),
                    _ => throw new KeyNotFoundException(),
                };
            };
        }

    }
}
