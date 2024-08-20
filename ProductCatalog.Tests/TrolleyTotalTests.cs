using Xunit;
using System.Net.Http;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ProductCatalog.Tests
{
    public class TrolleyTotalTests
    {
        [Fact]
        public async Task TrolleyTotalEndpointIsConfiguredAndReturnsCorrectResponse()
        {
            // Arrange
            var httpClient = new WebApplicationFactory<ProductCatalog.Api.Startup>().Server.CreateClient();

            var requestContent = """
                {
                  "products": [{ "name": "test", "price": 100.0 }],
                  "specials": [
                    { "quantities": [{ "name": "test", "quantity": 2 }], "total": 150 }
                  ],
                  "quantities": [{ "name": "test", "quantity": 2 }]
                }
                """;

            // Act
            var httpResponseMessage = await httpClient.PostAsync("/trolleyTotal", new StringContent(requestContent));

            // Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            readAsStringAsync.Should().Be("150.0");
        }
    }
}