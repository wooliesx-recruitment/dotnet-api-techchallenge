using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Api
{
    public class WooliesXProxy
    {
        public static async Task TrolleyCalculator(HttpContext context)
        {
            var proxyUrl = "https://dev-wooliesx-recruitment.azurewebsites.net/api/resource/trolleyCalculator";
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var postRequestContent = await reader.ReadToEndAsync();

            var response = await proxyUrl
                .SetQueryParam("token", "25a4f06f-8fd5-49b3-a711-c013c156f8c8")
                .WithHeader("Accept", "*/*")
                .WithHeader("Content-Type", "application/json-patch+json")
                .PostAsync(new StringContent(postRequestContent));

            var responseContentString = await response.Content.ReadAsStringAsync();

            await context.Response.WriteAsync(responseContentString);
        }
    }
}