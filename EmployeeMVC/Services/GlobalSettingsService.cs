using Microsoft.Extensions.Options;

namespace EmployeeMVC.Services
{
    public class GlobalSettingsService
    {
        private readonly AppSettings _appSettings;

        public GlobalSettingsService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public int GetTotalResultsPerPage()
        {
            return _appSettings.TotalResultsPerPage;
        }
    }
}
