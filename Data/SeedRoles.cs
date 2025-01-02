using Microsoft.AspNetCore.Identity;

namespace Biblioteca_UniLib.Data
{
    public static class SeedRoles
    {
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any() == false)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                roleManager.CreateAsync(new IdentityRole("Bibliotecario")).Wait();
                roleManager.CreateAsync(new IdentityRole("Leitor")).Wait();

            }
        }
    }
}
