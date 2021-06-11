using AsaaS.Common;
using AsaaS.Contracts;

namespace AsaaS.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly Settings _settings;

        public Settings CurrentSettings()
        {
            return _settings;
        }

        public SettingsService(Settings settings)
        {
            _settings = settings;
        }
    }
}