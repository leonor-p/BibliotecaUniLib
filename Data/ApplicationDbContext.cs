using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca_UniLib.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Defina DbSets para suas entidades aqui
        
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Biblioteca_UniLib.Models.Category> Category { get; set; } = default!;
        public DbSet<Biblioteca_UniLib.Models.Course> courses { get; set; }
        public DbSet<BookRequests> BookRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de relacionamentos e restrições adicionais
           
            modelBuilder.Entity<IdentityUser>(b =>
            {
                b.Property<bool>("AccBlocked")
                    .HasDefaultValue(false);

                b.Property<bool>("ActiveAcc")
                    .HasDefaultValue(true);
            });
        }
        /*public DbSet<Biblioteca_UniLib.Models.Category> Category { get; set; } = default!;*/
    }
}