using ProductCatalog.Api.Domain.HttpClients;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Api.Domain.Product
{
    public class GetSortedProductQuery
    {
        public string SortOption { get; }

        public GetSortedProductQuery(string sortOption)
        {
            SortOption = sortOption;
        }
    }

    public class GetSortedProductQueryHandler
    {
        private readonly IProductHttpClient _productHttpClient;
        private readonly IShopperHistoryHttpClient _shopperHistoryHttpClient;

        public GetSortedProductQueryHandler(
            IProductHttpClient productHttpClient,
            IShopperHistoryHttpClient shopperHistoryHttpClient)
        {
            _productHttpClient = productHttpClient;
            _shopperHistoryHttpClient = shopperHistoryHttpClient;
        }

        public async Task<GetSortedProductQueryResponse> Handle(GetSortedProductQuery getSortedProductQuery)
        {
            var products = await _productHttpClient.GetProducts();
            var productList = products.ToList();
            if (getSortedProductQuery.SortOption == "Low")
                return new GetSortedProductQueryResponse(productList.OrderBy(product => product.Price));
            else if (getSortedProductQuery.SortOption == "High")
                return new GetSortedProductQueryResponse(productList.OrderByDescending(product => product.Price));
            else if (getSortedProductQuery.SortOption == "Ascending")
                return new GetSortedProductQueryResponse(productList.OrderBy(product => product.Name));
            else if (getSortedProductQuery.SortOption == "Descending")
                return new GetSortedProductQueryResponse(productList.OrderByDescending(product => product.Name));
            else if (getSortedProductQuery.SortOption == "Recommended")
                return new GetSortedProductQueryResponse(await Recommend(productList));
            else
                return new GetSortedProductQueryResponse(productList);
        }

        private async Task<IEnumerable<Product>> Recommend(IEnumerable<Product> products)
        {
            var shopperHistory = await _shopperHistoryHttpClient.GetShopperHistory();

            var productsOrderedBasedOnNumberOfOrders =
                from shoppingHistory in shopperHistory
                let allOrders = shoppingHistory.Products
                from order in allOrders
                group order by order.Name into ordersGroupedByName
                let productsAndNumberOfOrders = new
                {
                    NumberOfOrders = ordersGroupedByName.Sum(product => product.Quantity),
                    Product = products.SingleOrDefault(product => product.Name == ordersGroupedByName.Key)
                }
                orderby productsAndNumberOfOrders.NumberOfOrders descending
                select productsAndNumberOfOrders.Product;

            var orderedProducts = productsOrderedBasedOnNumberOfOrders.ToList();
            var productsThatWereNotOrdered = products.Except(orderedProducts);
            orderedProducts.AddRange(productsThatWereNotOrdered);
            return orderedProducts;
        }
    }

    public class GetSortedProductQueryResponse
    {
        public GetSortedProductQueryResponse(IEnumerable<Product> products)
        {
            Products = products;
        }

        public IEnumerable<Product> Products { get; }
    }
}