using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eCommerce.Api.Filters
{
    public class RequireAuthenticationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Skip authentication for login and register endpoints
            var controllerName = context.RouteData.Values["controller"]?.ToString();
            var actionName = context.RouteData.Values["action"]?.ToString();

            if (controllerName == "AuthView" && (actionName == "Login" || actionName == "Register"))
            {
                return;
            }

            // Skip for API Auth controller
            if (controllerName == "Auth")
            {
                return;
            }

            // Check if user is authenticated
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // Redirect to login page
                context.Result = new RedirectToActionResult("Login", "AuthView", null);
            }
        }
    }
} 