using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Biblioteca_UniLib.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Biblioteca_UniLib.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Verifique se _context não é null
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchName, string searchAuthor, string searchGenre)
        {
            var courseQuery = _context.courses.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                courseQuery = courseQuery.Where(b => b.Name.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchAuthor))
            {
                courseQuery = courseQuery.Where(b => b.Author.Contains(searchAuthor));
            }

            /* if (!string.IsNullOrEmpty(searchGenre))
             {
                 courseQuery = courseQuery.Where(b => b.Genre.Contains(searchGenre));
             }*/

            var course = await courseQuery.ToListAsync();

            ViewData["SearchTitle"] = searchName;
            ViewData["SearchAuthor"] = searchAuthor;
            //ViewData["SearchGenre"] = searchGenre;

            return View(course);
        }

        public IActionResult Livros_em_destaque()
        {
            return View();
        }

        public IActionResult Adicionados_recentemente()
        {
            return View();
        }

        public IActionResult Freida_mcfadden()
        {
            return View();
        }

        public IActionResult George_Martin()
        {
            return View();
        }

        public IActionResult Alice_Oseman()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Termos()
        {
            return View();
        }

        public IActionResult Ajuda()
        {
            return View();
        }

        //Páginas das categorias
        public IActionResult cat_fantasia()
        {
            return View("Categorias/cat_fantasia");
        }

        public IActionResult cat_romance()
        {
            return View("Categorias/cat_romance");
        }

        public IActionResult cat_ficcao()
        {
            return View("Categorias/cat_ficcao");
        }

        public IActionResult cat_arte()
        {
            return View("Categorias/cat_arte");
        }

        public IActionResult cat_financas()
        {
            return View("Categorias/cat_financas");
        }

        public IActionResult cat_comedia()
        {
            return View("Categorias/cat_comedia");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult OnlyAdmins()
        {
            return View();
        }

        [Authorize(Roles = "Bibliotecario")]
        public IActionResult OnlyBiblio()
        {
            return View();
        }

        [Authorize(Roles = "Leitor")]
        public IActionResult OnlyLeitor()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Bibliotecario")]
        public IActionResult OnlyAdminsAndBiblio()
        {
            return View();
        }
    }
}