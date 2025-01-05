using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_UniLib.Data
{
    public static class SeedRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            // Seed roles
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Bibliotecario"));
                await roleManager.CreateAsync(new IdentityRole("Leitor"));
            }

            // Seed Admin user
            var adminUser = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true // Marcar o e-mail como confirmado
            };

            string adminPassword = "Teste1234!"; // Define uma senha segura

            var existingUser = await userManager.FindByEmailAsync(adminUser.Email);

            if (existingUser == null)
            {
                // Criar o usuário administrador
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    // Adicionar ao role de Admin
                    await userManager.AddToRoleAsync(adminUser, "Admin");

                    // Marcar conta como ativada e desbloqueada
                    var entry = context.Entry(adminUser);
                    entry.Property<bool>("AccBlocked").CurrentValue = false;
                    entry.Property<bool>("ActiveAcc").CurrentValue = true;
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Erro ao criar usuário admin: {string.Join(", ", createAdminUser.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                // Atualizar estado da conta existente
                var entry = context.Entry(existingUser);
                if (entry.Property<bool>("AccBlocked").CurrentValue)
                {
                    entry.Property<bool>("AccBlocked").CurrentValue = false;
                }
                if (!entry.Property<bool>("ActiveAcc").CurrentValue)
                {
                    entry.Property<bool>("ActiveAcc").CurrentValue = true;
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
