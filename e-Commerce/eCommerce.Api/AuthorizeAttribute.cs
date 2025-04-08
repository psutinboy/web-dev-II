using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            if (!_hasUserSession(context))
            {
                context.Result = new JsonResult(new { StatusCode = 100 }) { StatusCode = StatusCodes.Status200OK };
                return;
            }
        }
        catch (Exception)
        {
            context.Result = new JsonResult(new { StatusCode = 400 }) { StatusCode = StatusCodes.Status200OK };
        }
    }
    private bool _hasUserSession(AuthorizationFilterContext context)
    {
        object userIdObject = context.HttpContext.Items["User"];
//
        if (userIdObject == null)
        {
            return false;
        }

        return true;
    }

}
