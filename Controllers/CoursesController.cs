using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca_UniLib.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context; 
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CoursesController(ApplicationDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _webHostEnvironment=enviroment;
        }



        // GET: Courses
        public async Task<IActionResult> Index(int? id,string searchName, string searchAuthor, string searchCategory)
        {
           
            var course = await _context.courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
           

            
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                courseQuery = courseQuery.Where(c => c.Name.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchAuthor))
            {
                courseQuery = courseQuery.Where(c => c.Author.Contains(searchAuthor));
            }

            if (!string.IsNullOrEmpty(searchCategory))
            {
                courseQuery = courseQuery.Where(c => c.Category.Description.Contains(searchCategory));
            }

            var courses = await courseQuery.ToListAsync();

            ViewData["SearchName"] = searchName;
            ViewData["SearchAuthor"] = searchAuthor;
            ViewData["SearchCategory"] = searchCategory;

            return View(courses);
        }


        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Description");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Author,Description,ISBN,Quantidade,CoverPhoto,CategoryID,Dest,Addrec")] BookViewModel course)
        {
            var photoExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            var extension = Path.GetExtension(course.CoverPhoto.FileName).ToLower();

            if (!photoExtensions.Contains(extension))
            {
                ModelState.AddModelError("CoverPhoto", "Please, submit a valid image (jpg, jpeg, png, gif, bmp).");
            }

            if (ModelState.IsValid)
            {
                var newCourse = new Course
                {
                    Name = course.Name,
                    Author = course.Author,
                    ISBN = course.ISBN,
                    Description = course.Description,
                    CoverPhoto = Path.GetFileName(course.CoverPhoto.FileName),
                    Quantidade = course.Quantidade,
                    CategoryID = course.CategoryID,
                    Dest = course.Dest, // Adicionado
                    Addrec = course.Addrec // Adicionado
                };

                string coverDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Cover");
                if (!Directory.Exists(coverDirectory))
                {
                    Directory.CreateDirectory(coverDirectory);
                }

                string coverFullPath = Path.Combine(coverDirectory, newCourse.CoverPhoto);
                using (var stream = new FileStream(coverFullPath, FileMode.Create))
                {
                    await course.CoverPhoto.CopyToAsync(stream);
                }

                _context.Add(newCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }






        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Description", course.CategoryID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Author,Description,Quantidade,ISBN,State,CategoryID,Dest,Addrec,CoverPhoto")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            var existingCourse = await _context.courses.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(course.CoverPhoto))
            {
                course.CoverPhoto = existingCourse.CoverPhoto;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "Description", course.CategoryID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }
            

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.courses.FindAsync(id);
            if (course != null)
            {
                _context.courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.courses.Any(e => e.ID == id);
        }

        // GET: Requests/ManageRequests
        public async Task<IActionResult> Gerirrequisicoes()
        {
            var requests = await _context.BookRequests.ToListAsync();
            return View(requests);
        }

        // GET: Requests/AcceptRequest/{id}
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

        // GET: Requests/ReturnRequest/{id}
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
                course.Quantidade += 1;
                _context.Update(course);
            }

            _context.Update(request);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Gerirrequisicoes));
        }

        

    }
}
    

