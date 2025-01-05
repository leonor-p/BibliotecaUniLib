using Biblioteca_UniLib.Models;
using System.Linq;

namespace Biblioteca_UniLib.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            // Look for any categories.
            if (_context.Category.Any())
            {
                return; // DB has been seeded
            }

            if (_context.courses.Any()) // Certifique-se de que está usando "Courses"
            {
                return; // DB has been seeded
            }

            var categories = new Category[]
           {
                new Category{Name="Fantasia", Description="Fantasia",Author="Autor1"},
                new Category{Name="Finanças", Description="Finanças",Author = "Autor2"},
                new Category{Name="Comédia", Description="Comedia", Author = "Autor3"},
                new Category{Name="Romance", Description="Romance", Author = "Autor4"},
                new Category{Name="Ficção", Description="Ficção", Author = "Autor5"},
                new Category{Name="Arte", Description="Arte",Author = "Autor6"},
           };

            _context.Category.AddRange(categories);
            _context.SaveChanges();

            var courses = new Course[]
            {
                new Course
                {
                    Name="A Cegueira do Rio",
                    Description="Description1",
                    CoverPhoto= "/Cover/a_cegueira_do_rio.jpeg",
                    Author="Mia Couto",
                    Addrec=true,
                    Dest=false,
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Ficção").ID
                },

            };

            _context.courses.AddRange(courses); // Certifique-se de que está usando "Courses"
            _context.SaveChanges();
        }
    }
}