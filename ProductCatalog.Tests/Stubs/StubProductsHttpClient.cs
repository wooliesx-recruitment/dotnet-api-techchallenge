using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductCatalog.Api.Domain.Product;
using ProductCatalog.Api.Domain.HttpClients;

namespace ProductCatalog.Tests.Stubs
{
    public class StubProductsHttpClient : IProductHttpClient
    {
        private List<Product> ProductsToReturn { get; set; }

        public static StubProductsHttpClient WithProducts(List<Product> productsToReturn)
        {
            return new StubProductsHttpClient
            {
                ProductsToReturn = productsToReturn
            };
        }

        public static StubProductsHttpClient WithEmptyProducts()
        {
            return new StubProductsHttpClient
            {
                ProductsToReturn = new List<Product>()
            };
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return Task.FromResult(ProductsToReturn.AsEnumerable());
        }
    }
}