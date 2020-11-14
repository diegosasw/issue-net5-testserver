using Microsoft.Extensions.Configuration;

namespace WebApi.Services
{
    public class MyService
        : IMyService
    {
        private readonly IConfiguration _configuration;

        public MyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue()
        {
            var value = _configuration.GetValue<string>("Foo:Bar");
            return value;
        }
    }
}
