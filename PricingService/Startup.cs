using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PricingService.Data.DBContext;
using PricingService.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricingService
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
            services.AddSwaggerGen(opt =>
            {

                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Pricing APIs", Version = "v1" });
            });

            services.AddDbContext<PricingContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });



            var container = new ServiceCollection();
            container.AddTransient<ICarService, CarService>();
      
            // Build the IoC and get a provider
            var provider = container.BuildServiceProvider();

            //services.AddTransient<ICarService, CarService>();
            //services.AddHostedService<RabbitMQListener>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(z =>
            {
                z.SwaggerEndpoint("/swagger/v1/swagger.json", "Pricing API v1");
            });
            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
