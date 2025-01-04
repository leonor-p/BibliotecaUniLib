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

            request.IsAccepted = true;
            request.AcceptedBy = User.Identity.Name;
            request.AcceptedDate = DateTime.Now;

            _context.Update(request);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageRequests));
        }

        // GET: Requests/ReturnRequest/{id}
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

            _context.Update(request);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageRequests));
        }

        // GET: Requests/ManageRequests
        public async Task<IActionResult> ManageRequests()
        {
            var requests = await _context.BookRequests.ToListAsync();
            return View(requests);
        }

        public async Task<IActionResult> Gerirrequisicoes()
        {
            var bookRequests = await _context.BookRequests.ToListAsync();
            return View(bookRequests);
        }
    }   
}
