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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.courses.Include(c => c.Category);
            return View(await applicationDbContext.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Name,Author, Description, Quantidade, CoverPhoto,Document,CategoryID")] BookViewModel course)
        {
            // Validate the extension of the files
            var photoExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            //var documentExtensions = new[] { ".pdf", ".doc", ".docx", ".epub" };

            var extension = Path.GetExtension(course.CoverPhoto.FileName).ToLower();

            if (!photoExtensions.Contains(extension))
            {
                ModelState.AddModelError("CoverPhoto", "Please, submit a valid image (jpg, jpeg, png, gif, bmp).");
            }

            /*extension = Path.GetExtension(course.Document.FileName).ToLower();
            if (!documentExtensions.Contains(extension))
            {
                ModelState.AddModelError("Document", "Please, submit a valid document (pdf, doc, docx, epub).");
            }*/

            if (ModelState.IsValid)
            {
                var newCourse = new Course
                {
                    Name = course.Name,
                    Author = course.Author,
                    Description = course.Description, // Adicionando a propriedade Description
                    CoverPhoto = Path.GetFileName(course.CoverPhoto.FileName), // Salvar nome do arquivo
                    Quantidade = course.Quantidade,
                    //Document = Path.GetFileName(course.Document.FileName), // Salvar nome do arquivo
                    CategoryID = course.CategoryID // Certifique-se de que CategoryID está configurado
                };

                // Certifique-se de que os diretórios existem
                string coverDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Cover");
                if (!Directory.Exists(coverDirectory))
                {
                    Directory.CreateDirectory(coverDirectory);
                }

                /*string documentsDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Documents");
                if (!Directory.Exists(documentsDirectory))
                {
                    Directory.CreateDirectory(documentsDirectory);
                }*/

                // Salvar o arquivo CoverPhoto na pasta Cover
                string coverFullPath = Path.Combine(coverDirectory, newCourse.CoverPhoto);
                using (var stream = new FileStream(coverFullPath, FileMode.Create))
                {
                    await course.CoverPhoto.CopyToAsync(stream);
                }

                // Salvar o arquivo Document na pasta Documents
                /*string docFullPath = Path.Combine(documentsDirectory, newCourse.Document);
                using (var stream = new FileStream(docFullPath, FileMode.Create))
                {
                    await course.Document.CopyToAsync(stream);
                }*/

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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Author,Description,Quantidade,State,CategoryID")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
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
    }
}
