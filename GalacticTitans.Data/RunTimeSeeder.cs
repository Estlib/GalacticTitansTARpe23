using GalacticTitans.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticTitans.Data
{
    public class RunTimeSeeder
    {
        public static async Task AddDefaultAdmin(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateAsyncScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var context = scope.ServiceProvider.GetRequiredService<GalacticTitansContext>();

            await context.Database.EnsureCreatedAsync();

            /* safety checks omitted */

            //            builder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser
            //    {
            //        City = "testPassword1!",
            //        Id = "10000000-1000-1000-1000-100010001000",
            //        PlayerProfileID = Guid.Parse("10000000-1000-1000-1000-100010001000"),
            //        ProfileType = true,
            //        UserName = "galactus@titanus.com",
            //        Email = "galactus@titanus.com",
            //        EmailConfirmed = true,
            //    }
            //);
            var CityData = "testPassword1!";
            var IdData = "10000000-1000-1000-1000-100010001000";
            var PlayerProfileIdData = Guid.Parse("10000000-1000-1000-1000-100010001000");
            var ProfileType = true;
            var UserNameData = "galactus@titanus.com";
            var EmailData = "galactus@titanus.com";
            var EmailConfirmedData = true;

            var newPasswordHasher = new PasswordHasher<ApplicationUser>();
            

            // check admin
            var existingAdmin = await userManager.FindByIdAsync(IdData);
            if (existingAdmin == null) //make admin
            {
                
                //data
                var defaultAdmin = new ApplicationUser
                {
                    Id = IdData,
                    UserName = UserNameData,
                    NormalizedUserName = UserNameData.ToUpper(),
                    Email = EmailData,
                    NormalizedEmail = EmailData.ToUpper(),
                    EmailConfirmed = EmailConfirmedData,
                    City = CityData,
                    PlayerProfileID = PlayerProfileIdData,
                    ProfileType = ProfileType,
                };
                //passhashish
                var passwordHashData = newPasswordHasher.HashPassword(defaultAdmin, CityData);
                //le make
                defaultAdmin.PasswordHash = passwordHashData;
                await userManager.CreateAsync(defaultAdmin);
                // hallukas await userManager.AddToRoleAsync(defaultAdmin, "Admin");
            }
            //ctrl+s
            else
            {
                existingAdmin.NormalizedUserName = UserNameData.ToUpper();
                existingAdmin.NormalizedEmail = EmailData.ToUpper();
                var passwordHashData = newPasswordHasher.HashPassword(existingAdmin, CityData);
                existingAdmin.PasswordHash = passwordHashData;
                await userManager.UpdateAsync(existingAdmin);
            }
            await context.SaveChangesAsync();  
            
        }
    }
}
