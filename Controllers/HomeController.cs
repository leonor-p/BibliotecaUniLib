using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

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

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Roles ="Admin")]
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
