using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFleetMS.Models
{
    public static class SeedData
    {

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync(Roles.AdministratorRole).Result == null)
            {
                IdentityRole adminRole = new IdentityRole
                {
                    Name = Roles.AdministratorRole,
                    NormalizedName = Roles.AdministratorRole.ToUpper()
                };

                roleManager.CreateAsync(adminRole).Wait();
            }
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin2@admin2.local").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin2@admin2.local",
                    Email = "admin2@admin2.local"
                };

                IdentityResult result = userManager.CreateAsync(user, "BezpieczneHaslo11!!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.AdministratorRole).Wait();
                }
            }
        }
        //private CarFleetMSContext context = new CarFleetMSContext();

        //public void Initialize(UserManager<IdentityUser> _userManager)
        //{

        //    string[] roles = new string[] { "ADMINISTRATOR", "MECHANIC", "SUPERVISOR", "DRIVER" };

        //    foreach (string role in roles)
        //    {
        //        var roleStore = new RoleStore<IdentityRole>(context);

        //            if (!context.Roles.Any(r => r.Name == role))
        //            {
        //                roleStore.CreateAsync(new IdentityRole(role));
        //            }
        //    }

        //    var user = new IdentityUser
        //    {
        //        Email = "admin@admin.pl",
        //        UserName = "admin",
        //        NormalizedEmail = "ADMIN@ADMIN.pl",
        //        NormalizedUserName = "ADMIN",
        //        PhoneNumber = "+111111111111",
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true,
        //        SecurityStamp = Guid.NewGuid().ToString("D")
        //    };

        //    if (!context.Users.Any(u => u.UserName == user.UserName))
        //    {
        //        var password = new PasswordHasher<IdentityUser>();
        //        var hashed = password.HashPassword(user, "Admin123!@#");
        //        user.PasswordHash = hashed;

        //        var userStore = new UserStore<IdentityUser>(context);
        //        var result = userStore.CreateAsync(user);

        //    }

        //    //AssignRoles(_userManager, user.Email, "ADMINISTRATOR").Wait();

        //    context.SaveChangesAsync();
        //}

        //public static async Task<IdentityResult> AssignRoles(UserManager<IdentityUser> userManager, string email, string role)
        //{
        //    UserManager<IdentityUser> _userManager = userManager;
        //    IdentityUser user = await _userManager.FindByEmailAsync(email);
        //    var result = await _userManager.AddToRoleAsync(user, role);

        //    return result;
        //}
    }
}
