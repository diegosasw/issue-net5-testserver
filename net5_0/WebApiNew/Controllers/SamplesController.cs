using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiNew.Services;

namespace WebApiNew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SamplesController 
        : ControllerBase
    {
        private readonly IMyService _myService;

        public SamplesController(IMyService myService)
        {
            _myService = myService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var value = _myService.GetValue();
            return Ok(value);
        }
    }
}
