using Bull.Ga.Common.AppModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bull.Ga.Api.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly bool _skipAuthorization = false;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Skip authorization in action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous || _skipAuthorization)
            {
                return;
            }

            // authorization
            var user = (UserAuth)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in or role no authorized
                context.Result = new JsonResult(new ResultBase { Success = false, Message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
