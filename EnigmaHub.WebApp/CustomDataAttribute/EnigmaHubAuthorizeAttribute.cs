using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EnigmaHub.WebApp.CustomDataAttribute;

[AttributeUsage(AttributeTargets.Class)]
public class EnigmaHubAuthorizeAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("xapikey", out var extractedApiKey)) 
        {
            Console.WriteLine("Api Key was not provided");
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsync("Api Key was not provided ");
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }
        var appSettings = context.HttpContext.RequestServices.GetService<IConfiguration>();
        var apiKey = appSettings["ApiKey"];
        if (!apiKey.Equals(extractedApiKey)) {
            context.HttpContext.Response.StatusCode = 401;
            await context.HttpContext.Response.WriteAsync("Unauthorized client");
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            return;
        }
        await base.OnActionExecutionAsync(context, next);
    }
}