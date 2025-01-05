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
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }
        public DbSet<Bibliotecario> Bibliotecarios { get; set; }
        public DbSet<Leitor> Leitores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ReviewLivro> ReviewsLivros { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<HistoricoRequisicoes> HistoricoRequisicoes { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Biblioteca_UniLib.Models.Category> Category { get; set; } = default!;
        public DbSet<Biblioteca_UniLib.Models.Course> courses { get; set; }
        public DbSet<BookRequests> BookRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de relacionamentos e restrições adicionais
            modelBuilder.Entity<Administrador>()
                .HasOne(a => a.CreatedByAdmin)
                .WithMany()
                .HasForeignKey(a => a.CreatedByAdminID);

            modelBuilder.Entity<Bibliotecario>()
                .HasOne(b => b.Biblioteca)
                .WithMany()
                .HasForeignKey(b => b.BibliotecaID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Leitor)
                .WithMany()
                .HasForeignKey(e => e.LeitorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Emprestimo>()
                .HasOne(e => e.Livro)
                .WithMany()
                .HasForeignKey(e => e.LivroID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReviewLivro>()
                .HasOne(r => r.Livro)
                .WithMany()
                .HasForeignKey(r => r.LivroID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReviewLivro>()
                .HasOne(r => r.Leitor)
                .WithMany()
                .HasForeignKey(r => r.LeitorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notificacao>()
                .HasOne(n => n.Leitor)
                .WithMany()
                .HasForeignKey(n => n.LeitorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HistoricoRequisicoes>()
                .HasOne(h => h.Leitor)
                .WithMany()
                .HasForeignKey(h => h.LeitorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HistoricoRequisicoes>()
                .HasOne(h => h.Livro)
                .WithMany()
                .HasForeignKey(h => h.LivroID)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<IdentityUser>(b =>
            {
                b.Property<bool>("AccBlocked")
                    .HasDefaultValue(false);

                b.Property<bool>("ActiveAcc")
                    .HasDefaultValue(true);
            });
        }
        public DbSet<Biblioteca_UniLib.Models.Pessoa> Pessoa { get; set; } = default!;
        /*public DbSet<Biblioteca_UniLib.Models.Category> Category { get; set; } = default!;*/
    }
}