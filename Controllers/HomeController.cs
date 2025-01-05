using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Html;
using Biblioteca_UniLib.Data;

namespace Biblioteca_UniLib.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Adicionando o contexto do banco de dados

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Inicializando o contexto do banco de dados
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
            List<string> alllivros = new List<string>
            {
                "Dom Quixote",
                "O Pequeno Príncipe",
                "Orgulho e Preconceito",
                "1984",
                "Cem Anos de Solidão",
                "O Senhor dos Anéis",
                "Harry Potter e a Pedra Filosofal",
                "O Grande Gatsby",
                "A Metamorfose",
                "Moby Dick",
                "Jane Eyre",
                "A Revolução dos Bichos"
            };

            ViewBag.alllivros = new HtmlString(JsonConvert.SerializeObject(alllivros.ToArray()));
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

        // Páginas das categorias
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

        public string TestAjaxForm(string text)
        {
            return "<br>Receive " + text + " at <strong> " + DateTime.Now + "</strong>";
        }

        public string TestAjaxLink()
        {
            System.Threading.Thread.Sleep(5000); // Simulate time-consuming processing
            return "executed at <strong> " + DateTime.Now + "</strong>";
        }

        public string testAjax(string id)
        {
            Dictionary<string, List<string>> alllivros = new Dictionary<string, List<string>>
            {
                { "Ficção", new List<string> { "1", "2" } },
                { "Comédia", new List<string> { "3", "4" } },
                { "Arte", new List<string> { "5", "6" } },
                { "Fantasia", new List<string> { "7", "8" } },
                { "Finanças", new List<string> { "9", "10" } },
                { "Romance", new List<string> { "11", "12" } }
            };

            List<string> items = new List<string>();
            if (id != null && alllivros.ContainsKey(id))
                items = alllivros[id];

            return JsonConvert.SerializeObject(items);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult Search(string q)
        {
            var courses = _context.Courses
                .Where(c => c.Name.Contains(q))
                .Select(c => new { c.ID, c.Name })
                .ToList();

            return Json(courses);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
