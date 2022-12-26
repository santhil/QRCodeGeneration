using Microsoft.AspNetCore.Mvc.Filters;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;

namespace Dttl.Qr.Service { 
public class PerformAuditAttribute : ActionFilterAttribute
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
}