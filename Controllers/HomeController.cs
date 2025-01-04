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

        public IActionResult SessionDetails()
        {
            HttpContext.Session.SetString("StringValue", "Hello, Session!");
            HttpContext.Session.SetInt32("IntValue", 123);

            return View();
        }

    }


}

//BOLACHAS AKA COOKIES


public class HomeController : Controller
{
    public IActionResult AddCookies()
    {
        var cookieOptions1 = new CookieOptions { Expires = DateTime.Now.AddSeconds(10) };
        var cookieOptions2 = new CookieOptions { Expires = DateTime.Now.AddDays(1) };

        HttpContext.Response.Cookies.Append("Test1", "Value1");
        HttpContext.Response.Cookies.Append("Test2", "Value2", cookieOptions1);
        HttpContext.Response.Cookies.Append("Test3", "Value3", cookieOptions2);

        return RedirectToAction("Index");
    }

    public IActionResult DeleteCookies()
    {
        foreach (var item in HttpContext.Request.Cookies.Keys)
        {
            HttpContext.Response.Cookies.Delete(item);
        }

        return RedirectToAction("Index");
    }

    public IActionResult AddSessionVariables() //cria as sessões unicas de ID referenciadas antes no program.cs

    {   //podemos criar do tipo string, int ou byte array
        HttpContext.Session.SetString("StringValue", "Text variable value");
        HttpContext.Session.SetInt32("IntegerValue", 100);
        // uma cookie de sessão '.AspNetCore.Session' é criada e enviada para o cliente

        return RedirectToAction("Index");
    }

    public IActionResult DeleteSessionVariables()
    {
        //delete all variables stored in session
        foreach (var item in HttpContext.Session.Keys)
        {
            HttpContext.Session.Remove(item);
        }

        return RedirectToAction("Index");
    }

    public IActionResult DeleteSession()
    {
        HttpContext.Response.Cookies.Delete(".AspNetCore.Session");

        return RedirectToAction("Index");

    }


}
