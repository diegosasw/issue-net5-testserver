using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using WebApiNew.Services;
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
