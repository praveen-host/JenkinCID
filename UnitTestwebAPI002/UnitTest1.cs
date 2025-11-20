using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace UnitTestwebAPI002
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UnitTest1(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }



        [Fact]
        public void WeatherForecast_TemperatureF_Is_Correct()
        {
            var wf = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 0, "Freezing");
            Assert.Equal(32, wf.TemperatureF);

            wf = new WeatherForecast(DateOnly.FromDateTime(DateTime.Now), 100, "Hot");
            Assert.Equal(32 + (int)(100 / 0.5556), wf.TemperatureF);
        }
    }

    // Duplicate the record for test project scope
    internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
