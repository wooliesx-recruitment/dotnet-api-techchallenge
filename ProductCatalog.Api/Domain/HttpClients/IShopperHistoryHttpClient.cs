using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductCatalog.Api.Domain.Product;

namespace ProductCatalog.Api.Domain.HttpClients
{
    public interface IShopperHistoryHttpClient
    {
        Task<IEnumerable<ShopperHistory>> GetShopperHistory();
    }

    public class ShopperHistoryHttpClient : IShopperHistoryHttpClient
    {
        private readonly string _shopperOrdersUrl =
            "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory";

        public async Task<IEnumerable<ShopperHistory>> GetShopperHistory()
        {
            try
            {
                var shopperHistories = await _shopperOrdersUrl
                    .SetQueryParam("token", "25a4f06f-8fd5-49b3-a711-c013c156f8c8")
                    .AllowAnyHttpStatus()
                    .WithHeader("Accept", "application/json")
                    .GetJsonAsync<List<ShopperHistory>>();
                return shopperHistories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}