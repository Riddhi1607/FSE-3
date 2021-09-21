using Buyer_BidProduct_Service.DBServiceLayer.Models;
using Buyer_BidProduct_Service.DBServiceLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buyer_BidProduct_Service.BusinessLogicLayer.Contracts;
using Buyer_BidProduct_Service.BusinessLogicLayer.Implementations;

namespace Buyer_BidProduct_Service
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
            services.Configure<BuyerDBDatabaseSettings>(Configuration.GetSection(nameof(BuyerDBDatabaseSettings)));

            services.AddSingleton<IBuyerDBDatabaseSettings>(sp => sp.GetRequiredService<IOptions<BuyerDBDatabaseSettings>>().Value);

            services.AddScoped<IBuyerBidProductService_BL, BuyerBidProductService_BL>();

            services.AddControllers();

            services.AddSingleton<BuyerService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Buyer's Bidding API",
                    Description = "Buyers can place bid using this API",
                    Contact = new OpenApiContact
                    {
                        Name = "Riddhi Roy Choudhury",
                        Email = string.Empty
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
