using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCatalog.Api.Domain.HttpClients;
using ProductCatalog.Api.Domain.Product;
using System.IO;

namespace ProductCatalog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<GetSortedProductQueryHandler>();
            services.AddTransient<IProductHttpClient, ProductHttpClient>();
            services.AddTransient<IShopperHistoryHttpClient, ShopperHistoryHttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context => { await context.Response.WriteAsync("Welcome to Product Catalog API"); });

                endpoints.Map("/trolleyTotal", async context => { await WooliesXProxy.TrolleyCalculator(context); });

                endpoints.MapControllers();
            });
        }
    }
}