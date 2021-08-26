using Xunit;
using Newtonsoft.Json;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProductCatalog.Tests.DataHelpers;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductCatalog.Api.Domain.Product;

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
            httpResponseMessage.StatusCode.Should().Be(StatusCodes.Status200OK);
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
            httpResponseMessage.StatusCode.Should().Be(StatusCodes.Status200OK);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Product[]>(readAsStringAsync);
            products.Should().Equal(ListOfProduct.SortedBasedOnRecommended);
        }
    }
}