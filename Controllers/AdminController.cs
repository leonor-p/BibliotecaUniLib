<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Biblioteca_UniLib.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
=======
﻿using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca_UniLib.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
>>>>>>> Pedro
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
            return View(await _context.Pessoa.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
=======
            var users = await _userManager.Users.ToListAsync();

            var userBlocks = users
                .ToDictionary(u => u.UserName, u =>
                {
                    var entry = _context.Entry(u);
                    return entry.Property<bool>("AccBlocked").CurrentValue;
                });

            var activeAccounts = users
                .Where(u => _context.Entry(u).Property<bool>("ActiveAcc").CurrentValue)
                .Select(u => u.Id)
                .ToHashSet();

            var inactiveUsers = users
                .Where(u => !_context.Entry(u).Property<bool>("ActiveAcc").CurrentValue)
                .ToList();

            var activeRoles = new Dictionary<string, List<IdentityUser>>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    if (!_context.Entry(user).Property<bool>("ActiveAcc").CurrentValue) continue;

                    if (!activeRoles.ContainsKey(role))
                    {
                        activeRoles[role] = new List<IdentityUser>();
                    }
                    activeRoles[role].Add(user);
                }
            }

            var inactiveRoles = new Dictionary<string, List<IdentityUser>>();
            foreach (var user in inactiveUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    if (!inactiveRoles.ContainsKey(role))
                    {
                        inactiveRoles[role] = new List<IdentityUser>();
                    }
                    inactiveRoles[role].Add(user);
                }
            }

            ViewData["UserManager"] = _userManager;
            ViewData["UserBlocks"] = userBlocks;
            ViewData["ActiveAccounts"] = activeAccounts;
            ViewData["InactiveAccounts"] = inactiveUsers;
            ViewData["ActiveRoles"] = activeRoles;
            ViewData["InactiveRoles"] = inactiveRoles;

            return View("Admin", users);
        }

        // POST: Admin/ToggleAccountBlock/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleAccountBlock(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
>>>>>>> Pedro
            {
                return NotFound();
            }

<<<<<<< HEAD
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
=======
            var entry = _context.Entry(user);
            var isBlocked = entry.Property<bool>("AccBlocked").CurrentValue;
            entry.Property("AccBlocked").CurrentValue = !isBlocked;

            // Atualiza o estado do usuário no UserManager
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Error");
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/ActivateAccount/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateAccount(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
>>>>>>> Pedro
            {
                return NotFound();
            }

<<<<<<< HEAD
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
            return View(pessoa);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoa.Remove(pessoa);
            }
=======
            var entry = _context.Entry(user);
            entry.Property("ActiveAcc").CurrentValue = true;
>>>>>>> Pedro

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

<<<<<<< HEAD
        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
=======
        // POST: Admin/DeleteUser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("O ID do utilizador não pode ser nulo ou vazio.");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Utilizador não encontrado.");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("Error");
        }

        // GET: Admin/CreateUser
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(string email, string userName, string password, string confirmPassword, DateTime birthday, string role)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(role))
            {
                ModelState.AddModelError("", "Todos os campos são obrigatórios.");
                return View();
            }

            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "As palavras-passe não coincidem.");
                return View();
            }

            if (!new[] { "Admin", "Librarian", "Reader" }.Contains(role))
            {
                ModelState.AddModelError("", "Função inválida selecionada.");
                return View();
            }

            var user = new IdentityUser
            {
                UserName = userName,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {

                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(user, role);

                if (role == "Admin" || role == "Librarian")
                {
                    var entry = _context.Entry(user);
                    entry.Property("ActiveAcc").CurrentValue = false;
                    await _context.SaveChangesAsync();
                }

                var profile = new Perfil
                {
                    Username = userName,
                    //Birthday = birthday,
                };

                _context.Perfis.Add(profile);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }


            // GET: Admin/EditUser/{id}
            public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("O ID do utilizador não pode ser nulo ou vazio.");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Utilizador não encontrado.");
            }

            var profile = await _context.Perfis.FirstOrDefaultAsync(p => p.Username == user.UserName);
            if (profile == null)
            {
                return NotFound("Perfil não encontrado.");
            }

            //ViewBag.Birthday = profile.Birthday;
            return View(user);
        }

        // POST: Admin/EditUser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, string email, string userName, DateTime birthday)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("O ID do utilizador não pode ser nulo ou vazio.");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Utilizador não encontrado.");
            }

            user.Email = email;
            user.UserName = userName;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                var profileReload = await _context.Perfis.FirstOrDefaultAsync(p => p.Username == user.UserName);
                /*if (profileReload != null)
                {
                    ViewBag.Birthday = profileReload.Birthday;
                }*/

                return View(user);
            }

            var profile = await _context.Perfis.FirstOrDefaultAsync(p => p.Username == user.UserName);
            if (profile != null)
            {
                //profile.Birthday = birthday;
                profile.Username = userName;
                _context.Perfis.Update(profile);
                await _context.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError("", "Perfil não encontrado. Não foi possível atualizar o perfil.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
>>>>>>> Pedro
