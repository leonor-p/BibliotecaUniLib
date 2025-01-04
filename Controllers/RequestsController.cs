using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca_UniLib.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requests/Index/{id}
        public async Task<IActionResult> Index(int id)
        {
            var course = await _context.courses.FirstOrDefaultAsync(b => b.ID == id);

            if (course == null)
            {
                return NotFound();
            }

            var bookRequest = new BookRequests
            {
                BookId = id
            };

            ViewData["course"] = course;
            return View(bookRequest);
        }

        // POST: Requests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookRequests bookRequest)
        {
            if (ModelState.IsValid)
            {
                bookRequest.RequestStartDate = DateTime.Now;
                bookRequest.RequestEndDate = DateTime.Now.AddDays(15);

                var book = await _context.courses.FindAsync(bookRequest.BookId);
                if (book != null)
                {
                    bookRequest.BookTitle = book.Name;
                }
                bookRequest.UserName = User.Identity.Name;

                _context.Add(bookRequest);
                await _context.SaveChangesAsync();

                return RedirectToAction("ConfirmationScreen", "Requests");
            }

            return View("Index", bookRequest);
        }

        // GET: Requests/ConfirmationScreen
        public IActionResult ConfirmationScreen()
        {
            return View();
        }

        // GET: Requests/AcceptRequest/{id}
        [HttpPost]
        public async Task<IActionResult> AcceptRequest(int id)
        {
            var request = await _context.BookRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            if (request.RequestStartDate <= DateTime.Now && request.RequestEndDate >= DateTime.Now)
            {
                request.IsAccepted = true;
                request.AcceptedBy = User.Identity.Name;
                request.AcceptedDate = DateTime.Now;

                var course = await _context.courses.FindAsync(request.BookId);
                if (course != null && course.Quantidade > 0)
                {
                    course.Quantidade -= 1;
                    _context.Update(course);
                }
                else
                {
                    TempData["ErrorMessage"] = "Não há mais exemplares disponíveis.";
                    return RedirectToAction(nameof(Gerirrequisicoes));
                }

                _context.Update(request);
                await _context.SaveChangesAsync();
            }
            else
            {
                TempData["ErrorMessage"] = "A solicitação está fora do período de aceitação.";
            }

            return RedirectToAction(nameof(Gerirrequisicoes));
        }

        // POST: Requests/ReturnRequest/{id}
        [HttpPost]
        public async Task<IActionResult> ReturnRequest(int id)
        {
            var request = await _context.BookRequests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.IsReturned = true;
            request.ReturnedBy = User.Identity.Name;
            request.ReturnedDate = DateTime.Now;

            var course = await _context.courses.FindAsync(request.BookId);
            if (course != null)
            {
                // Log para depuração
                Console.WriteLine($"Updating course quantity: Current Quantity {course.Quantidade}");
                course.Quantidade += 1;
                _context.Update(course);
            }
            else
            {
                // Log para depuração
                Console.WriteLine($"Course not found for BookId {request.BookId}");
            }

            _context.Update(request);
            try
            {
                await _context.SaveChangesAsync();
                // Log para confirmar salvamento
                Console.WriteLine("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                // Log para pegar exceções
                Console.WriteLine($"Error saving changes: {ex.Message}");
            }

            return RedirectToAction(nameof(Gerirrequisicoes));
        }

        // GET: Requests/ManageRequests
        public async Task<IActionResult> Gerirrequisicoes()
        {
            var Requests = await _context.BookRequests.ToListAsync();
            return View(Requests);
        }
    }
}
