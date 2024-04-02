using Microsoft.AspNetCore.Mvc;
using ResAccess.DTO;
using ResAccess.Interfaces;

namespace ResAccess.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResAccessController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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

        [HttpGet("/api/GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "/api/requests")]
        public GetAccessStatusResponse GetAccessStatus(GetAccessStatusRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request),
                    "Please provide GetAccessStatusRequest " +
                    "instance as a parameter ");

            if (string.IsNullOrWhiteSpace(request.Resource))
                throw new ArgumentException(nameof(request.Resource),
                    "Pleace provide resource string parameter which " +
                    "is not null, empty string and not whitespace.");

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
