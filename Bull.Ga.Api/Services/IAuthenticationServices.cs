using Bull.Ga.Api.Helpers;
using Bull.Ga.Business.Interfaces;
using Bull.Ga.Common.Constants;
using Bull.Ga.Common.DtoModels;
using Bull.Ga.Common.Utils;

namespace Bull.Ga.Api.Services
{
    public interface IAuthenticationServices
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }

    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUserServices _userService;
        private readonly IDomainServices _domainServices;
        private IJwtUtils _jwtUtils;

        public AuthenticationServices(IUserServices userService, IDomainServices domainServices, IJwtUtils jwtUtils)
        {
            _userService = userService;
            _domainServices = domainServices;
            _jwtUtils = jwtUtils;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userService.GetUserById(model.UserId);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new AppException(MessageConstants.S_INCORRECT_USER_PASSWORD);

            // non active user
            if (!user.IsPermitToLogin)
                throw new AppException(MessageConstants.S_INACTIVE_USER);

            user.AppSource = model.AppSource;

            // authentication succesful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }
    }
}
