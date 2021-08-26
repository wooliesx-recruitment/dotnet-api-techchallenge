using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api.Domain.HttpClients;
using ProductCatalog.Api.Domain.Product;

namespace ProductCatalog.Api.Controllers
{
    [Route("/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet("/sort")]
        public async Task<ActionResult<IEnumerable<Product>>> Sort([FromQuery] string sortOption)
        {
            var sortedProductQueryHandler =
                new GetSortedProductQueryHandler(new ProductHttpClient(), new ShopperHistoryHttpClient());
            
            var getSortedProductQuery = new GetSortedProductQuery(sortOption);
            var queryResponse = await sortedProductQueryHandler.Handle(getSortedProductQuery);
            return Ok(queryResponse.Products);
        }
    }
}