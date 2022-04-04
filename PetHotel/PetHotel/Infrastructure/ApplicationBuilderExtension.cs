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

            return app;
        }

        private static void SeedTypePets(ApplicationDbContext data)
        {
            if (data.TypePet.Any())
            {
                return;
            }
            data.TypePet.AddRange(new[]
            {
                new TypePet {Name="Dog"},
                new TypePet {Name="Cat"},
                new TypePet {Name="Bird"},
                new TypePet {Name="Rabbit"},
            });
            data.SaveChanges();
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