using AsaaS.Common;
using AsaaS.Contracts;
using AsaaS.Entities;
using AsaaS.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AsaaS
{
    public static class AsaasServiceCollectionExtensions
    {
        //
        // Summary:
        //     Adds AsaaS services to the provided Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        //   configure:
        public static void AddAsaaS(this IServiceCollection services, Settings settings)
        {
            services.AddSingleton<ISettingsService>(s => new SettingsService(settings));
            services.AddTransient<ICustomerService, CustomerRepositoryService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
        }
    }
}