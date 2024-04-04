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
        //public GetAccessStatusResponse GetAccessStatus(GetAccessStatusRequest request)
        public ActionResult<GetAccessStatusResponse> GetAccessStatus(GetAccessStatusRequest request)
        {
//            try
  //          {
                if (request is null)
                    throw new ArgumentNullException(nameof(request),
                        "Please provide GetAccessStatusRequest " +
                        "instance as a parameter ");

           // }
    //        catch (ArgumentException ex)
      //      {
        //        _logger.LogError("123");
          //  }

            // return BadRequest("sdv");
            return new GetAccessStatusResponse
            {
                AccessDecision = Interfaces.AccessDecision.Granted,
                Resource = "dsvmnsdv",
                Reason = "dvdsv"
            };
        }
    }
}
