using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace WebApiNew.Tests
{
    public class SamplesControllerTests
    {
        [Fact]
        public void Test_Samples_Controller()
        {
            var server =
                new TestServer(
                    new WebHostBuilder()
                        .UseStartup<Startup>()
                        .UseCommonConfiguration()
                        .UseEnvironment("Test"));
        }

        [Fact]
        public void Test_Samples_Controller_With_Mocks()
        {
            var server =
                new TestServer(
                    new WebHostBuilder()
                        .UseStartup<Startup>()
                        .UseCommonConfiguration()
                        .UseEnvironment("Test")
                        .ConfigureTestServices(
                            mockServices =>
                            {

                            }));
        }
    }
}
