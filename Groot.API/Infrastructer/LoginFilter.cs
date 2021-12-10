using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading;

namespace Groot.API.Infrastructer
{
    public class LoginFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Thread.Sleep(5000);
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "User", Action = "GetUsers" }));

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
