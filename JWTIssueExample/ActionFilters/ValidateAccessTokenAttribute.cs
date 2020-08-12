using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace JWTIssueExample.ActionFilters
{
    public class ValidateAccessTokenAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do nothing
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenHeaderPresent = context.HttpContext.Request.Headers.ContainsKey("x-api-token");

            if (!tokenHeaderPresent)
            {
                context.Result = new BadRequestObjectResult($"x-api-token header is missing.");
                return;
            }

            var token = context.HttpContext.Request.Headers["x-api-token"].FirstOrDefault();
            context.HttpContext.Items.Add("XApiToken", token);
        }
    }
}