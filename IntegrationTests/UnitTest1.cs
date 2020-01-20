using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using ReproduceNCrunchBug2;

using Xunit;

namespace IntegrationTests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test1Async()
        {
            var client = _factory.CreateClient();

            var result = await client.GetAsync("/");

            Assert.Equal(200, (int)result.StatusCode);
        }
    }
}
