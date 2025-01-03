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
                new Category{Name="Book1", Description="Description1", Author="Author1"},
                new Category{Name="Book2", Description="Description2", Author="Author2"},
                new Category{Name="Book3", Description="Description3", Author="Author3"},
            };

            _context.Category.AddRange(categories);
            _context.SaveChanges();

            var courses = new Course[]
            {
                new Course
                {
                    Name="Course1",
                    Description="Description1",
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Book1").ID
                },
                new Course
                {
                    Name="Course2",
                    Description="Description2",
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Book2").ID
                },
                new Course
                {
                    Name="Course3",
                    Description="Description3",
                    Quantidade=50,
                    State=true,
                    CategoryID=categories.Single(c => c.Name == "Book3").ID
                }
            };

            _context.courses.AddRange(courses); // Certifique-se de que está usando "Courses"
            _context.SaveChanges();
        }
    }
}