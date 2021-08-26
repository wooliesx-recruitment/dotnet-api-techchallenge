using System.Collections.Generic;
using ProductCatalog.Api.Domain.Product;

namespace ProductCatalog.Tests.DataHelpers
{
    public class ShopperHistoryData
    {
        public static readonly List<ShopperHistory> History = new List<ShopperHistory>
        {
            new ShopperHistory("123",new List<Product>
            {
                new Product("Test Product A", 99.99, 3),
                new Product("Test Product B", 101.99, 1),
                new Product("Test Product F", 999999999999, 1),
            }),
            new ShopperHistory("23",new List<Product>
            {
                new Product("Test Product A", 99.99, 2),
                new Product("Test Product B", 101.99, 3),
                new Product("Test Product F", 999999999999, 1),
            }),
            new ShopperHistory("23",new List<Product>
            {
                new Product("Test Product C", 10.99, 2),
                new Product("Test Product F", 999999999999, 2),
            }),
            new ShopperHistory("23",new List<Product>
            {
                new Product("Test Product A", 99.99, 1),
                new Product("Test Product A", 101.99, 1),
                new Product("Test Product C", 10.99, 1),
            }),
        };
    }
}