using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

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
        public async Task CallingIndex_ShouldReturn200()
        {
            var client = _factory.CreateClient();

            var result = await client.GetAsync("/");

            Assert.Equal(200, (int)result.StatusCode);
        }

        [Fact]
        public void ApplicationPartManager_ShouldLoadCompiledRazorAssemblyPartForReproduceNCrunchBug2Views()
        {
            var appPartManager = _factory.Services.GetRequiredService<ApplicationPartManager>();
            Assert.Contains(appPartManager.ApplicationParts, part => (part is CompiledRazorAssemblyPart razorPart) && razorPart.Name == "ReproduceNCrunchBug2.Views");
        }
    }
}
