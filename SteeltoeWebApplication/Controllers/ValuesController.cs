using Microsoft.AspNetCore.Mvc;

namespace SteeltoeWebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IConfiguration configuration, ILogger<ValuesController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var value1 = _configuration["Value1"];
            var value2 = _configuration["Value2"];

            return new[] { value1, value2 };
        }
    }
}
