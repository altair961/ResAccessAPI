using Microsoft.AspNetCore.Mvc;
using ResAccess.Interfaces;
using ResAccess.DTO;

namespace ResAccess.API.Controllers
{
    [Route("api")]
    public class ResAccessController : Controller
    {
        private readonly ILogger<ResAccessController> _logger;
        private readonly IResAccessManager _resAccessManager;
        public ResAccessController(ILogger<ResAccessController> logger, IResAccessManager resAccessManager)
        {
            if (resAccessManager is null)
                throw new ArgumentNullException(nameof(resAccessManager),
                    "Please provide resAccessManager object when making " +
                    "an instance of ResAccessController class.");

            if (logger is null)
                throw new ArgumentNullException(nameof(logger),
                    "Please provide logger object when making " +
                    "an instance of ResAccessController class.");

            _logger = logger;
            _resAccessManager = resAccessManager;
        }

        [Route("requests")]
        public GetAccessResponse GetAccess(GetAccessRequest request) 
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request),
                    "Please provide GetAccessRequest " +
                    "instance as a parameter ");

            if (string.IsNullOrWhiteSpace(request.Resource))
                throw new ArgumentException(nameof(request.Resource),
                    "Pleace provide resource string parameter which " +
                    "is not null, empty string and not whitespace.");

            //_resAccessManager.ResAccessStatuses[resourceName]
            return new GetAccessResponse() { AccessDecision = AccessDecision.Granted };
        }
    }
}
