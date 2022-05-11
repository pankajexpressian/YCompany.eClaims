using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Policy.API.Infrastructure.Data;
using Policy.API.Application.Services;
using Policy.API.Infrastructure.Services;
using Policy.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Policy.API
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
            services.AddDbContext<PolicyContext>(options =>
            {
                //options.UseSqlServer(Configuration.GetConnectionString("PolicyDbConnection"));
                options.UseInMemoryDatabase(Configuration["ConnectionStrings:InMemoryPolicyDb"]);
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IPolicyService, PolicyService>();

            services.AddScoped<IPolicyRepository, PolicyRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Policy.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Policy.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
