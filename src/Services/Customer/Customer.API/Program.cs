using Customer.API.Inrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Customer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            MigrateDatabase(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private async static void MigrateDatabase(IHost host)
        {
            await CustomerDataSeeder.MigrateDatabases(host);
        }
    }
}
