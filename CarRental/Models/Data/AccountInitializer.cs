using CarRental.Models.AccountDto;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Models.Data
{
    public class AccountInitializer
    {
        public static async Task SeedInitDataAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                // Role Manager
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if(!await roleManager.RoleExistsAsync( EnumRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(EnumRoles.Admin));
                if (!await roleManager.RoleExistsAsync(EnumRoles.Owner))
                    await roleManager.CreateAsync(new IdentityRole(EnumRoles.Owner));
                if (!await roleManager.RoleExistsAsync(EnumRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(EnumRoles.User));

                // User Manager
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Add admin if not exist
                var emailAdmin = "admin@yahoo.com";
                var checkAdminExist = await userManager.FindByEmailAsync(emailAdmin);
                if(checkAdminExist == null)
                {
                    var createAdmin = new ApplicationUser()
                    {
                        firstName = "admin",
                        lastName = "admin",
                        UserName = "admin",
                        Email = emailAdmin,
                        EmailConfirmed = true,
                        //PhoneNumber = "0785668985"
                    };
                    await userManager.CreateAsync(createAdmin , "Admin123");
                    await userManager.AddToRoleAsync(createAdmin, EnumRoles.Admin);
                }


                // Add owner if not exist
                var emailOwner = "owner@yahoo.com";
                var checkOwnerExist = await userManager.FindByEmailAsync(emailOwner);
                if (checkOwnerExist == null)
                {
                    var createOwner = new ApplicationUser()
                    {
                        firstName = "owner",
                        lastName = "owner",
                        UserName = "owner",
                        Email = emailOwner,
                        //PhoneNumber = "0785668985"
                    };
                    await userManager.CreateAsync(createOwner, "Owner123");
                    await userManager.AddToRoleAsync(createOwner, EnumRoles.Owner);
                }

                // Add users
                //user 1
                var emailUser = "user@yahoo.com";
                var checkUserExist = await userManager.FindByEmailAsync(emailUser);
                if (checkUserExist == null)
                {
                    var createUser = new ApplicationUser()
                    {
                        firstName = "user",
                        lastName = "user",
                        UserName = "user",
                        Email = emailUser,
                        //PhoneNumber = "0785668985"
                    };
                    await userManager.CreateAsync(createUser, "User123");
                    await userManager.AddToRoleAsync(createUser, EnumRoles.User);
                }
                //user 2
                var emailUser2 = "user2@yahoo.com";
                var checkUser2Exist = await userManager.FindByEmailAsync(emailUser2);
                if (checkUser2Exist == null)
                {
                    var createUser2 = new ApplicationUser()
                    {
                        firstName = "user2",
                        lastName = "user2",
                        UserName = "user2",
                        Email = emailUser2,
                        //PhoneNumber = "0785668985"
                    };
                    await userManager.CreateAsync(createUser2, "User123");
                    await userManager.AddToRoleAsync(createUser2, EnumRoles.User);
                }
            }
        }

    }
}
