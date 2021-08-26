using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProductCatalog.Api.Domain.HttpClients
{
    public interface IProductHttpClient
    {
        Task<IEnumerable<Product.Product>> GetProducts();
    }

    public class ProductHttpClient : IProductHttpClient
    {

        private readonly string _productUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products";

        public async Task<IEnumerable<Product.Product>> GetProducts()
        {
            try
            {
                var products = await _productUrl
                    .SetQueryParam("token", "25a4f06f-8fd5-49b3-a711-c013c156f8c8")
                    .AllowAnyHttpStatus()
                    .WithHeader("Accept", "application/json")
                    .GetJsonAsync<Product.Product[]>();
                return products;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}