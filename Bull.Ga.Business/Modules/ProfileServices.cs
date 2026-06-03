using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.AppModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bull.Ga.Business.Modules
{
    public class ProfileServices : IProfileServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ProfileServices> _logger;
        private readonly AppSettings _appSettings;

        public ProfileServices(IHttpContextAccessor httpContextAccessor, ILogger<ProfileServices> logger, IOptions<AppSettings> appSettings)
        {
            _httpContextAccessor = httpContextAccessor;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public UserAuth GetUserContext()
        {
            try
            {
                var user = (UserAuth)_httpContextAccessor.HttpContext.Items["User"];

                if (_appSettings.SkipAuthorization)
                {
                    user = new UserAuth
                    {
                        UserId = "dummy.user",
                        FullName = "dummy user",
                        AppSource = "TempWeb",
                    };
                }

                if (user == null)
                {
                    throw new Exception("Unauthorized");
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"method: GetUserContext(), " +
                   $"message: {ex.Message}");
                throw;
            }
        }
    }
}
