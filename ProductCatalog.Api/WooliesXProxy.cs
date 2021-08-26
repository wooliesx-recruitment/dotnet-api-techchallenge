using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;

namespace ProductCatalog.Api
{
    public class WooliesXProxy
    {
        public static async Task TrolleyCalculator(HttpContext context)
        {
            var proxyUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/trolleyCalculator";
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var postRequestContent = await reader.ReadToEndAsync();
            var postJsonAsync = proxyUrl
                .SetQueryParam("token", "25a4f06f-8fd5-49b3-a711-c013c156f8c8")
                .WithHeader("Accept", "application/json")
                .WithHeader("Content-Type", "application/json-patch+json")
                .PostAsync(new StringContent(postRequestContent));

            var readAsStringAsync = await postJsonAsync.Result.Content.ReadAsStringAsync();

            await context.Response.WriteAsync(readAsStringAsync);
        }
    }
}