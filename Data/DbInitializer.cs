using Biblioteca_UniLib.Models;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

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

            // Look for any books.
            if (_context.Category.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
                new Category{Name="Book1", Description="lll", Author="Author1"},
                new Category{Name="Book2", Description="lll", Author="Author2"},
                new Category{Name="Book3", Description="lll", Author="Author3"},
            };

            _context.Category.AddRange(categories);
            _context.SaveChanges();

            var courses = new Course[]
            {
                new Course{
                    Name="Course1",
                    Description="Description1",
                    Cost=50,
                    State=true,
                    CategoryID=categories.Single( c => c.Name == "Category1").ID
                },
                new Course{
                    Name="Course2",
                    Description="Description2",
                    Cost=50,
                    State=true,
                    CategoryID=categories.Single( c => c.Name == "Category2").ID
                },
                new Course{
                    Name="Course3",
                    Description="Description3",
                    Cost=50,
                    State=true,
                    CategoryID=categories.Single( c => c.Name == "Category3").ID
                }
            };
            _context.courses.AddRange(courses);
            _context.SaveChanges();
        }
    }
}