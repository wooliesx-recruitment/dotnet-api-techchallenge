using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProductCatalog.Api.Domain.Product;
using ProductCatalog.Tests.DataHelpers;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ProductCatalog.Tests
{
    public class ProductSortController
    {
        [Fact]
        public async Task SortEndpointIsConfiguredAndReturnsCorrectJsonResponse()
        {
            // Arrange
            var httpClient = new WebApplicationFactory<ProductCatalog.Api.Startup>().Server.CreateClient();

            // Act
            var httpResponseMessage = await httpClient.GetAsync("/sort?sortOption=High");

            // Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Product[]>(readAsStringAsync);
            products.Should().Equal(ListOfProduct.SortedProductsFormHighToLow);
        }

        [Fact]
        public async Task SortEndpointIsConfiguredAndReturnsCorrectJsonResponseForRecommended()
        {
            // Arrange
            var httpClient = new WebApplicationFactory<ProductCatalog.Api.Startup>().Server.CreateClient();

            // Act
            var httpResponseMessage = await httpClient.GetAsync("/sort?sortOption=Recommended");

            // Assert
            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Product[]>(readAsStringAsync);
            products.Should().Equal(ListOfProduct.SortedBasedOnRecommended);
        }
    }
}