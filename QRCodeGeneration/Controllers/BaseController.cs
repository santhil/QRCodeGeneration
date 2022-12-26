using Microsoft.AspNetCore.Mvc;

namespace QRCodeGeneration.Controllers
{
    [Audit]
    public class BaseController : ControllerBase
    {
        public readonly ILogger _logger;
      

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
