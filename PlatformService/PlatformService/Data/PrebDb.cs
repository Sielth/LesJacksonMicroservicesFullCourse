using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Linq;

namespace PlatformService.Data
{
    public static class PrebDb
    {

        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        // If this class wasn't static, SeedData would get the DbContext via constructor.
        // That's why we have to call this method with an instance of DbContext from within PrepPopulation.
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(

                        new Platform()
                        {
                            Name = "Dot Net",
                            Publisher = "Microsoft",
                            Cost = "Free"
                        },

                        new Platform()
                        {
                            Name = "SQL Server Express",
                            Publisher = "Microsoft",
                            Cost = "Free"
                        }, 
                        
                        new Platform()
                        {
                            Name = "Kubernetes",
                            Publisher = "Cloud Native Computing Foundation",
                            Cost = "Free"
                        }

                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data.");
            }
        }
    }
}
