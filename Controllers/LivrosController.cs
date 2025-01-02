using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class LivrosController : Controller
{
    private readonly ApplicationDbContext _context;

    public LivrosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Detalhes(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var livro = await _context.Livros
            .FirstOrDefaultAsync(m => m.LivroID == id);

        if (livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }
}