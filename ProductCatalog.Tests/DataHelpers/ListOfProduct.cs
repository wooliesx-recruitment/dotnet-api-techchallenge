using ProductCatalog.Api.Domain.Product;
using System.Collections.Generic;

namespace ProductCatalog.Tests.DataHelpers
{
    public static class ListOfProduct
    {
        public static readonly List<Product> ANotSortedProductsFormLowToHigh = new List<Product>
        {
            new Product("Test Product B", 101.99, 0),
            new Product("Test Product A", 99.99, 0),
            new Product("Test Product C", 10.99, 0),
            new Product("Test Product D", 5, 0),
            new Product("Test Product F", 999999999999, 0),
        };

        public static readonly List<Product> SortedProductsFormLowToHigh = new List<Product>
        {
            new Product("Test Product D", 5, 0),
            new Product("Test Product C", 10.99, 0),
            new Product("Test Product A", 99.99, 0),
            new Product("Test Product B", 101.99, 0),
            new Product("Test Product F", 999999999999, 0),
        };

        public static readonly List<Product> SortedProductsFormHighToLow = new List<Product>
        {
            new Product("Test Product F", 999999999999, 0),
            new Product("Test Product B", 101.99, 0),
            new Product("Test Product A", 99.99, 0),
            new Product("Test Product C", 10.99, 0),
            new Product("Test Product D", 5, 0),
        };

        public static readonly List<Product> SortedAscending = new List<Product>
        {
            new Product("Test Product A", 99.99, 0),
            new Product("Test Product B", 101.99, 0),
            new Product("Test Product C", 10.99, 0),
            new Product("Test Product D", 5, 0),
            new Product("Test Product F", 999999999999, 0),
        };

        public static readonly List<Product> SortedDescending = new List<Product>
        {
            new Product("Test Product F", 999999999999, 0),
            new Product("Test Product D", 5, 0),
            new Product("Test Product C", 10.99, 0),
            new Product("Test Product B", 101.99, 0),
            new Product("Test Product A", 99.99, 0),
        };

        public static readonly List<Product> SortedBasedOnRecommended = new List<Product>
        {
            new Product("Test Product A", 99.99, 0),
            new Product("Test Product B", 101.99, 0),
            new Product("Test Product F", 999999999999, 0),
            new Product("Test Product C", 10.99, 0),
            new Product("Test Product D", 5, 0),
        };
    }
}