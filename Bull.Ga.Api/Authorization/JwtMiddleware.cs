using Bull.Ga.Common.AppModels;
using Bull.Ga.Common.Utils;

namespace Bull.Ga.Api.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var tokenInfo = jwtUtils.ValidateJwtToken(token ?? "");
            if (tokenInfo != null && tokenInfo.UserId != null)
            {
                //attach user to context on succesful jwt validation
                UserAuth user = new UserAuth
                {
                    UserId = tokenInfo.UserId,
                    FullName = tokenInfo.FullName,
                    AppSource = tokenInfo.AppSource,
                    IsPermitToLogin = true
                };

                context.Items["User"] = user;
            }

            await _next(context);
        }
    }
}
