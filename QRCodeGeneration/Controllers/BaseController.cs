using Microsoft.AspNetCore.Mvc;
using QRCodeGeneration.Utils;

namespace QRCodeGeneration.Controllers
{
    [PerformAudit]
    [HandleError]
    public class BaseController : ControllerBase
    {
        public readonly ILogger _logger;
      

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
