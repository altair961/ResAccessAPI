using Microsoft.AspNetCore.Mvc;
using ResAccess.DTO;
using ResAccess.Interfaces;

namespace ResAccess.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResAccessController : ControllerBase
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

        [HttpPost("/api/requests")]
        public ActionResult<GetAccessStatusResponse> GetAccessStatus(GetAccessStatusRequest request)
        {
            try
            {
                if (request is null)
                    throw new ArgumentNullException(nameof(request),
                        "Please provide GetAccessStatusRequest " +
                        "instance as a parameter ");

                if (string.IsNullOrWhiteSpace(request.Resource))
                    throw new ArgumentException(nameof(request.Resource),
                        "Pleace provide resource string parameter which " +
                        "is not null, empty string and not whitespace.");

            }
            catch (ArgumentException ex)
            {
                return BadRequest("Bad request.");
            }

            _resAccessManager.GetAccessStatus(request.Resource);

            return new GetAccessStatusResponse
            {
                AccessDecision = Interfaces.AccessDecision.Granted,
                Resource = "dsvmnsdv",
                Reason = "dvdsv"
            };
        }
    }
}
