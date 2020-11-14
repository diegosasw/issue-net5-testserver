using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WebApi.Services;
using Xunit;

namespace WebApi.Tests
{
    public class SamplesControllerTests
    {
        [Fact]
        public async Task Test_Samples_Controller()
        {
            var server =
                new TestServer(
                    new WebHostBuilder()
                        .UseStartup<Startup>()
                        .UseCommonConfiguration()
                        .UseEnvironment("Test"));

            var client = server.CreateClient();
            var result = await client.GetAsync("samples");
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await result.Content.ReadAsStringAsync();
            content.Should().Be("value for test");
        }

        [Fact]
        public async Task Test_Samples_Controller_With_Mocks()
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
                                var myServiceMock = new Mock<IMyService>();
                                myServiceMock
                                    .Setup(x => x.GetValue())
                                    .Returns("value from the mock");

                                mockServices.AddSingleton<IMyService>(sp => myServiceMock.Object);
                            }));

            var client = server.CreateClient();
            var result = await client.GetAsync("samples");
            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await result.Content.ReadAsStringAsync();
            content.Should().Be("value from the mock");
        }
    }
}
