using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;

namespace Biblioteca_UniLib.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Search(string query)
        {
            // Implementação da lógica de pesquisa, por exemplo, buscar no banco de dados.
            var results = SearchDatabase(query);

            // Retornar os resultados da pesquisa para a view
            return View(results);
        }

        private List<string> SearchDatabase(string query)
        {
            // Exemplo de lógica de pesquisa (substitua pelo seu próprio código)
            List<string> data = new List<string> { "Item1", "Item2", "Item3" };
            return data.Where(d => d.Contains(query, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
