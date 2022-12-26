using Microsoft.AspNetCore.Mvc;
  

namespace Dttl.Qr.Service
{
    [PerformAudit]
    [HandleError]
    public class BaseController : ControllerBase
    {
        public readonly ILogger _logger;
      
//Change
        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
