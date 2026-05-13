using Bull.Ga.Common.AppModels;

namespace Bull.Ga.Common.DtoModels
{
    public class AuthenticateResponse
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public AuthenticateResponse(UserAuth user, string token)
        {
            UserId = user.UserId;
            FullName = user.FullName;

            Token = token;
        }
    }
}
