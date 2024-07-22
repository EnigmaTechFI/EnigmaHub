using EnigmaHub.Domain.Constants;
using EnigmaHub.Domain.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace EnigmaHub.Domain.Data;

public class DbInitializer
{
    public static async Task SeedUsersAndRoles(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager,
        ApplicationDbContext applicationDbContext, IConfiguration config)
    {
        #region AddRoles
        IdentityResult roleResult;
        string[] roleNames = { Roles.User, Roles.Admin, Roles.Supplier, Roles.Customer, Roles.Marketing, Roles.Reseller, Roles.FmDigital, Roles.Manager, Roles.Developer};
        foreach (var roleName in roleNames)
        {
            var roleExist = roleManager.RoleExistsAsync(roleName).Result;
            if (!roleExist)
                roleResult = roleManager.CreateAsync(new IdentityRole(roleName)).Result;
        }
        
        #endregion

        #region AddUserAndCompany
        
        var adm2 = userManager.FindByEmailAsync("develop@enigma-tech.it").Result;
        if (adm2 == null)
        {
            adm2 = new MyUser
            {
                Id = "da010659-e752-4902-9d06-73dde10af9f0",
                FirstName = "Develop",
                LastName = "Enigma",
                UserName = "develop_enigma",
                Email = "develop@enigma-tech.it",
                EmailConfirmed = true,
                PhoneNumber = "3396227051"
            };

            IdentityResult result = userManager.CreateAsync(adm2, "Antani123!").Result;
            var addedRole = userManager.AddToRolesAsync(adm2, new[] { Roles.Developer}).Result;
        }
        
        var adm1 = userManager.FindByEmailAsync("lorenzo.vettori@enigma-tech.it").Result;
        if (adm1 == null)
        {
            adm1 = new MyUser
            {
                FirstName = "Lorenzo",
                LastName = "Vettori",
                UserName = "lore_vetto",
                Email = "lorenzo.vettori@enigma-tech.it",
                EmailConfirmed = true,
                PhoneNumber = "3396227051"
            };

            IdentityResult result = userManager.CreateAsync(adm1, "Antani123!").Result;
            var addedRole = userManager.AddToRolesAsync(adm1, new[] { Roles.Admin}).Result;
        }

        #endregion
    }
}
