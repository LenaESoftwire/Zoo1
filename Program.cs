using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using zoo;
using Zoo.Data;

namespace Zoo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ZooDbContext>();
            context.Database.EnsureCreated();

            if (!context.Animals.Any())
            {
                var animals = SampleAnimals.GetAnimals();
                context.Animals.AddRange(animals);
                context.SaveChanges();

                //var keepers = SampleKeepers.GetKeepers();
                //context.Keepers.AddRange(keepers);
                //context.SaveChanges();

                //var interactions = SampleInteractions.GetInteractions();
                //context.Interactions.AddRange(interactions);
                //context.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }
    }
}
