using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PT_EDI_Indonesia_MVC.Core.Models;

namespace PT_EDI_Indonesia_MVC.Data.Seed
{
    public static class RolesSeed
    {
        public static async Task CreateRoles(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = new string[] { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var powerUser = new User
            {
                UserName = "admin@test.com",
                Email = "admin@test.com"
            };

            string userPwd = "Password123!";
            var _user = await userManager.FindByEmailAsync(powerUser.Email);

            if (_user is null)
            {
                var createPowerUser = await userManager.CreateAsync(powerUser, userPwd);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}