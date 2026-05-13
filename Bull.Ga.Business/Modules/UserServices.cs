using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bull.Ga.Business.Modules
{
    public class UserServices : IUserServices
    {
        private readonly ILogger<UserServices> _logger;
        private readonly AppSettings _appSettings;

        public UserServices(ILogger<UserServices> logger, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public UserAuth? GetUserById(string userId)
        {
            UserAuth? userAuth = null;

            return userAuth;
        }
    }
}
