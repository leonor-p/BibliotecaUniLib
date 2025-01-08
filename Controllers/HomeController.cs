using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Biblioteca_UniLib.Data;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

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

            if (!string.IsNullOrEmpty(searchGenre))
            {
                courseQuery = courseQuery.Where(b => b.Category.Description.Contains(searchGenre));
            }

            var course = await courseQuery.ToListAsync();

            ViewData["SearchTitle"] = searchName;
            ViewData["SearchAuthor"] = searchAuthor;
            ViewData["SearchGenre"] = searchGenre;

            return View(course);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Todoslivros(string searchName, string searchAuthor, string searchCategory)
        {
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
        public async Task<IActionResult> Livros_em_destaque(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.Dest == true).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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

        [AllowAnonymous]
        public async Task<IActionResult>Adicionados_recentemente(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.Addrec == true).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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
        [AllowAnonymous]
        public IActionResult Sobre_Nos()
        {
            return View();
        }
        
       


        [Authorize] // Garante que apenas usuários autenticados podem acessar
        public async Task<IActionResult> Historicoreq()
        {
            // Obtém o nome do usuário autenticado
            string userName = User.Identity.Name;

            // Busca as requisições feitas pelo usuário autenticado no banco de dados
            var userRequests = await _context.BookRequests
                .Where(r => r.UserName == userName) // Filtra as requisições pelo nome do usuário
                .ToListAsync();

            // Retorna a view com os dados das requisições
            return View(userRequests);
        }
        [AllowAnonymous]
        //Páginas das categorias
        public async Task<IActionResult> cat_fantasia(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.CategoryID == 1).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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
        [AllowAnonymous]
        public async Task<IActionResult> cat_romance(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.CategoryID == 4).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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
        [AllowAnonymous]
        public async Task<IActionResult> cat_ficcao(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.CategoryID == 5).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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
        [AllowAnonymous]
        public async Task<IActionResult> cat_arte(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.CategoryID == 6).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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
        [AllowAnonymous]
        public async Task<IActionResult> cat_financas(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.CategoryID == 2).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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
        [AllowAnonymous]
        public async Task<IActionResult> cat_comedia(string searchName, string searchAuthor, string searchCategory)
        {
            var courseQuery = _context.courses.Include(c => c.Category).AsQueryable();
            var cursos = _context.courses.Where(c => c.CategoryID == 3).ToList();
            if (cursos == null)
            {
                cursos = new List<Course>();
            }
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> GetOverdueRequestsAsync()
        {
            // Lógica para obter requisições em atraso
            var overdueRequests = await GetOverdueRequestsFromDatabaseAsync(); // Método que retorna uma lista de requisições

            if (overdueRequests != null && overdueRequests.Any())
            {
                TempData["OverdueRequests"] = JsonConvert.SerializeObject(overdueRequests);
            }

            return RedirectToAction("Index");
        }

        private async Task<List<RequestsController>> GetOverdueRequestsFromDatabaseAsync()
        {
            // Simula uma chamada de banco de dados ou lógica para buscar os dados
            return await Task.FromResult(new List<RequestsController>());
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

        public IActionResult SessionDetails()
        {
            HttpContext.Session.SetString("StringValue", "Hello, Session!");
            HttpContext.Session.SetInt32("IntValue", 123);

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(".UniLib.Session");
            return RedirectToAction("Index", "Home");
        }

    

    public IActionResult AddCookies()
    {
        var cookieOptions1 = new CookieOptions { Expires = DateTime.Now.AddSeconds(10) };
        var cookieOptions2 = new CookieOptions { Expires = DateTime.Now.AddDays(1) };

        HttpContext.Response.Cookies.Append("Test1", "Value1");
        HttpContext.Response.Cookies.Append("Test2", "Value2", cookieOptions1);
        HttpContext.Response.Cookies.Append("Test3", "Value3", cookieOptions2);

        return RedirectToAction("Privacy");
    }

    public IActionResult DeleteCookies()
    {
        foreach (var item in HttpContext.Request.Cookies.Keys)
        {
            HttpContext.Response.Cookies.Delete(item);
        }

        return RedirectToAction("Privacy");
    }

    public IActionResult AddSessionVariables() //cria as sessões unicas de ID referenciadas antes no program.cs

    {   //podemos criar do tipo string, int ou byte arr
        HttpContext.Session.SetString("StringValue", "Text variable value");
        HttpContext.Session.SetInt32("IntegerValue", 100);
        // uma cookie de sessão '.AspNetCore.Session' é criada e enviada para o cliente

        return RedirectToAction("Privacy");
    }

    public IActionResult DeleteSessionVariables()
    {
        //delete all variables stored in session
        foreach (var item in HttpContext.Session.Keys)
        {
            HttpContext.Session.Remove(item);
        }

        return RedirectToAction("Privacy");
    }

    public IActionResult DeleteSession()
    {
        HttpContext.Response.Cookies.Delete(".AspNetCore.Session");

        return RedirectToAction("Privacy");

    }
        public IActionResult Confirmacao()
        {
            
            return View();

        }
    }
}