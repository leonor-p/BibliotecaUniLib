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

            // Look for any books.
            if (_context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var books = new Books[]
            {
                new Books{Name="Book1", Description="lll", Author="Author1"},
                new Books{Name="Book2", Description="lll", Author="Author2"},
                new Books{Name="Book3", Description="lll", Author="Author3"},
            };

            _context.Books.AddRange(books);
            _context.SaveChanges();
        }
    }
}