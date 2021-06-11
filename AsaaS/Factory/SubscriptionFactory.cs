using AsaaS.Contracts;
using AsaaS.Services;

namespace AsaaS.Factory
{
    public class SubscriptionFactory
    {
        public static ISubscriptionService CreateService(ISettingsService settingsService)
        {
            return new SubscriptionService(settingsService);
        }
    }
}