using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using QRCodeGeneration.Controllers;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;

public class AuditAttribute : ActionFilterAttribute
{

    

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.Controller is BaseController)
        {
            var controller = context.Controller as BaseController;
            controller!._logger.LogInformation(
                $"{context.ActionDescriptor.RouteValues["controller"]}\\{context.ActionDescriptor.RouteValues["action"]}"
                );
        }
        base.OnActionExecuting(context);
    }

   
}