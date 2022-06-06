using eClaims.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eClaims.Web
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
            //services.AddHttpClient<IPolicyService, PolicyService>(config =>
            //config.BaseAddress = new Uri(Configuration["GatewaySettings:BaseAddress"])
            //);

            services.AddHttpClient<PolicyService>(config =>
           config.BaseAddress = new Uri(Configuration["GatewaySettings:BaseAddress"])
           );

            services.AddHttpClient<IClaimService, ClaimService>(config =>
            config.BaseAddress = new Uri(Configuration["GatewaySettings:BaseAddress"])
            );

            services.AddHttpClient<IDocumentService, DocumentService>(config =>
            config.BaseAddress = new Uri(Configuration["GatewaySettings:BaseAddress"])
            );

            services.AddHttpClient<ICustomerService, CustomerService>(config =>
            config.BaseAddress = new Uri(Configuration["GatewaySettings:BaseAddress"])
            );

            services.AddHttpClient<INotificationService, NotificationService>(config =>
           config.BaseAddress = new Uri(Configuration["GatewaySettings:BaseAddress"])
           );


            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
