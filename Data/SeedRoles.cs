using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca_UniLib.Data
{
    public static class SeedRoles
    {
        public static void Seed(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            // Criar roles
            if (roleManager.Roles.Any() == false)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
                roleManager.CreateAsync(new IdentityRole("Bibliotecario")).Wait();
                roleManager.CreateAsync(new IdentityRole("Leitor")).Wait();
            }

            // Criar usuários de exemplo
            if (userManager.Users.Any() == false)
            {
                var adminUser = new IdentityUser { UserName = "admin@domain.com", Email = "admin@domain.com", EmailConfirmed = true };
                userManager.CreateAsync(adminUser, "Admin123!").Wait();
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();

                var bibliotecarioUser = new IdentityUser { UserName = "bibliotecario@domain.com", Email = "bibliotecario@domain.com", EmailConfirmed = true };
                userManager.CreateAsync(bibliotecarioUser, "Bibliotecario123!").Wait();
                userManager.AddToRoleAsync(bibliotecarioUser, "Bibliotecario").Wait();

                var leitorUser = new IdentityUser { UserName = "leitor@domain.com", Email = "leitor@domain.com", EmailConfirmed = true };
                userManager.CreateAsync(leitorUser, "Leitor123!").Wait();
                userManager.AddToRoleAsync(leitorUser, "Leitor").Wait();

                // Associar usuários ao Perfil
                var adminPerfil = new Perfil { Username = adminUser.UserName };
                var bibliotecarioPerfil = new Perfil { Username = bibliotecarioUser.UserName };
                var leitorPerfil = new Perfil { Username = leitorUser.UserName };

                context.Perfis.Add(adminPerfil);
                context.Perfis.Add(bibliotecarioPerfil);
                context.Perfis.Add(leitorPerfil);

                context.SaveChanges();

                // Associar Perfis aos Roles
                context.PerfilRoles.Add(new PerfilRole { PerfilId = adminPerfil.Id, RoleId = roleManager.FindByNameAsync("Admin").Result.Id });
                context.PerfilRoles.Add(new PerfilRole { PerfilId = bibliotecarioPerfil.Id, RoleId = roleManager.FindByNameAsync("Bibliotecario").Result.Id });
                context.PerfilRoles.Add(new PerfilRole { PerfilId = leitorPerfil.Id, RoleId = roleManager.FindByNameAsync("Leitor").Result.Id });

                context.SaveChanges();
            }
        }
    }
}
