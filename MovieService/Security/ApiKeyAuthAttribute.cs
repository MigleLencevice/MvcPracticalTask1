using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieService.Security
{
    public class ApiKeyAuthAttribute : Attribute, IAuthorizationFilter
    {
        private const string APIKEY = "my-secret-key";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!APIKEY.Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}