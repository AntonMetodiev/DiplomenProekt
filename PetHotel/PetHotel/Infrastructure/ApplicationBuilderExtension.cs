using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PetHotel.App.Entities;
using PetHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetHotel.App.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;
            await RoleSeeder(services);
            await SeedAdministrator(services);
            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedTypePets(data);
            var dataPlace = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedPlaces(dataPlace);
            var dataStatus = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedStatus(dataStatus);
            return app;
        }
        private static void SeedTypePets(ApplicationDbContext data)
        {
            if (data.TypePets.Any())
            {
                return;
            }
            data.TypePets.AddRange(new[]
            {
                new TypePet {Name="Dog"},
                new TypePet {Name="Cat"},
                new TypePet {Name="Bird"},
                new TypePet {Name="Rabbit"},
            });
            data.SaveChanges();
        }
        private static void SeedStatus(ApplicationDbContext dataStatus)
        {
            if (dataStatus.Statuses.Any())
            {
                return;
            }
            dataStatus.Statuses.AddRange(new[]
            {
                new Status {StatusName="Approved"},
                new Status {StatusName="Pending"},
                new Status {StatusName="Rejected"},
               
            });
            dataStatus.SaveChanges();
        }

        
        private static void SeedPlaces(ApplicationDbContext dataPlace)
        {
            if (dataPlace.Places.Any())
            {
                return;
            }
            dataPlace.Places.AddRange(new[]
            {
                new Place {Name="Dog", TypePetId=1, Area=30},
                new Place {Name="Cat", TypePetId=2, Area=30},
                new Place {Name="Bird", TypePetId=3, Area=20},
                new Place {Name="Rabbit", TypePetId=4, Area=30},
            });
            dataPlace.SaveChanges();
        }

        

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Client" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.FirstName = "Admin";
                user.LastName = "Admin";
                user.PhoneNumber = "0892648610";

                var result = await userManager.CreateAsync
                    (user, "123456");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

    }
}