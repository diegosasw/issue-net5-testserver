using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApiNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SamplesController 
        : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SamplesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var value = _configuration.GetValue<string>("Foo.Bar");
            return Ok(value);
        }
    }
}
