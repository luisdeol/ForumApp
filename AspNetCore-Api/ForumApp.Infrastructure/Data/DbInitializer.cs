using System.Threading.Tasks;
using ForumApp.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ForumApp.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ForumAppDbContext context) {
            context.Database.EnsureCreated();
        }

        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("ForumUser").Result)
            {
                var role = new ApplicationRole
                {
                    Name = "ForumUser"
                };
                var roleResult = roleManager.CreateAsync(role).Result;
            }

            if (roleManager.RoleExistsAsync("AdminUser").Result) return;
            {
                var role = new ApplicationRole
                {
                    Name = "AdminUser"
                };
                var roleResult = roleManager.CreateAsync(role).Result;
            }
        } 
    }
}