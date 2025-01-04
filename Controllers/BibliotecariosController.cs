using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_UniLib.Data;

namespace Biblioteca_UniLib.Controllers
{
    public class BibliotecariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BibliotecariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bibliotecarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bibliotecarios.Include(b => b.Biblioteca);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bibliotecarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecario = await _context.Bibliotecarios
                .Include(b => b.Biblioteca)
                .FirstOrDefaultAsync(m => m.BibliotecarioID == id);
            if (bibliotecario == null)
            {
                return NotFound();
            }

            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Create
        public IActionResult Create()
        {
            ViewData["BibliotecaID"] = new SelectList(_context.Bibliotecas, "BibliotecaID", "Nome");
            return View();
        }

        // POST: Bibliotecarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BibliotecarioID,Nome,Email,Senha,BibliotecaID")] Bibliotecario bibliotecario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bibliotecario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BibliotecaID"] = new SelectList(_context.Bibliotecas, "BibliotecaID", "Nome", bibliotecario.BibliotecaID);
            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecario = await _context.Bibliotecarios.FindAsync(id);
            if (bibliotecario == null)
            {
                return NotFound();
            }
            ViewData["BibliotecaID"] = new SelectList(_context.Bibliotecas, "BibliotecaID", "Nome", bibliotecario.BibliotecaID);
            return View(bibliotecario);
        }

        // POST: Bibliotecarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BibliotecarioID,Nome,Email,Senha,BibliotecaID")] Bibliotecario bibliotecario)
        {
            if (id != bibliotecario.BibliotecarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bibliotecario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliotecarioExists(bibliotecario.BibliotecarioID))
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
            ViewData["BibliotecaID"] = new SelectList(_context.Bibliotecas, "BibliotecaID", "Nome", bibliotecario.BibliotecaID);
            return View(bibliotecario);
        }

        // GET: Bibliotecarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecario = await _context.Bibliotecarios
                .Include(b => b.Biblioteca)
                .FirstOrDefaultAsync(m => m.BibliotecarioID == id);
            if (bibliotecario == null)
            {
                return NotFound();
            }

            return View(bibliotecario);
        }

        // POST: Bibliotecarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bibliotecario = await _context.Bibliotecarios.FindAsync(id);
            if (bibliotecario != null)
            {
                _context.Bibliotecarios.Remove(bibliotecario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotecarioExists(int id)
        {
            return _context.Bibliotecarios.Any(e => e.BibliotecarioID == id);
        }

        public IActionResult Gerirrequisicoes()
        {
            return View(); // Certifique-se de que há uma view chamada Gerirrequisicoes.cshtml
        }
    }
}
