using AsaaS.Contracts;
using AsaaS.Services;

namespace AsaaS.Factory
{
    public static class CustomerFactory
    {
        public static ICustomerService CreateService(ISettingsService settingsService)
        {
            return new CustomerRepositoryService(settingsService);
        }
    }
}