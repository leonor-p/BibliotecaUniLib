using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

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
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Livros_em_destaque()
        {
            var livros = _context.Livros.Where(l => l.EmDestaque).ToList();
            return View(livros);
        }

        // Método para adicionar livros ao banco de dados
        public IActionResult AdicionarLivro()
        {
            var livro = new Livro
            {
                Titulo = "Exemplo de Livro",
                Autor = "Autor Exemplo",
                Categoria = "Categoria Exemplo",
                AnoPublicacao = new DateTime(2020, 1, 1),
                ISBN = "123-4567890123",
                ImagemUrl = "/imagens/default-book-cover.png",
                EmDestaque = true
            };

            _context.Livros.Add(livro);
            _context.SaveChanges();

            return RedirectToAction("Livros_em_destaque");
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

        }


    }



    public IActionResult DetalhesDoLivro(int id)
    {
        // Exemplo: Obtendo informações do livro por ID
        var livro = _context.Livros.FirstOrDefault(l => l.LivroID == id);

        if (livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }
}}
}
