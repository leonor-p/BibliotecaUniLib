using Biblioteca_UniLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Biblioteca_UniLib.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any books.
                if (context.Livros.Any())
                {
                    return;   // DB has been seeded
                }

                context.Livros.AddRange(
                    new Livro
                    {
                        Titulo = "Exemplo de Livro",
                        Autor = "Autor Exemplo",
                        Categoria = "Categoria Exemplo",
                        AnoPublicacao = new DateTime(2020, 1, 1),
                        ISBN = "123-4567890123",
                        ImagemUrl = "/imagens/default-book-cover.png",
                        EmDestaque = true
                    },
                    new Livro
                    {
                        Titulo = "Outro Livro Exemplo",
                        Autor = "Outro Autor",
                        Categoria = "Outr CATEGORIA",
                        AnoPublicacao = new DateTime(2021, 1, 1),
                        ISBN = "123-4567890124",
                        ImagemUrl = "/imagens/default-book-cover.png",
                        EmDestaque = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}