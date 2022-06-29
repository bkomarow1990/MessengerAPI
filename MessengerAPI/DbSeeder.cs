using System.Linq;
using Entities;
using Infrastructure.Constants;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MessengerAPI
{
    public static class DbSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();
            context.Database.Migrate();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!roleManager.Roles.Any())
            {
                var result = roleManager.CreateAsync(new IdentityRole { Name = Roles.Admin }).Result;
                result = roleManager.CreateAsync(new IdentityRole { Name = Roles.User }).Result;
            }

            if (!userManager.Users.Any())
            {
                string email = "admin@gmail.com";
                var user = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                    Image = "1.jpg",
                    FirstName = "Valeriy",
                    LastName = "Adminow"
                };
                var result = userManager.CreateAsync(user).Result;
                result = userManager.AddToRoleAsync(user, Roles.Admin).Result;
            }
        }
    }
}
