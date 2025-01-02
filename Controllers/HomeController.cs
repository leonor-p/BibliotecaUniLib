using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace Biblioteca_UniLib.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
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

        //imagens para fundo das categorias
        public IActionResult Fantasia()
        {
            ViewData["BodyClass"] = "cat-fantasia";
            return View();
        }

        public IActionResult Romance()
        {
            ViewData["BodyClass"] = "cat-romance";
            return View();
        }

        public IActionResult Ficcao()
        {
            ViewData["BodyClass"] = "cat-ficcao";
            return View();
        }

        public IActionResult Arte()
        {
            ViewData["BodyClass"] = "cat-arte";
            return View();
        }

        public IActionResult Financas()
        {
            ViewData["BodyClass"] = "cat-financas";
            return View();
        }

        public IActionResult Comedia()
        {
            ViewData["BodyClass"] = "cat-comedia";
            return View();
        }
    }


}
