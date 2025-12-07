using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoLaRuta.Models;

namespace ProyectoLaRuta.Controllers
{
    public class UsersController : Controller
    {
        private readonly LarutaContext _context;

        public UsersController(LarutaContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.Active = 1;
            user.EmailVerified = 0;
            user.DateOfCreation = DateTime.UtcNow;
            user.Role = "CLIENT";

            _context.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Active,Email,FirstName,Gender,Height,LastName,Role,SecondLastName,SecondName,Username,Weight,Password")] User user)
        {
            if (id != user.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // 1️⃣ Traer el usuario actual de la DB
                    var userDb = await _context.Users.FindAsync(id);
                    if (userDb == null)
                        return NotFound();

                    // 2️⃣ Actualizar solo los campos editables
                    userDb.Active = user.Active;
                    userDb.Email = user.Email;
                    userDb.FirstName = user.FirstName;
                    userDb.Gender = user.Gender;
                    userDb.Height = user.Height;
                    userDb.LastName = user.LastName;
                    userDb.Role = user.Role;
                    userDb.SecondLastName = user.SecondLastName;
                    userDb.SecondName = user.SecondName;
                    userDb.Username = user.Username;
                    userDb.Weight = user.Weight;
                    userDb.Password = user.Password; // si quieres permitir cambiar contraseña aquí

                    // 3️⃣ Guardar cambios
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }




        //inicio de sesión
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    (u.Email == model.UsernameOrEmail || u.Username == model.UsernameOrEmail)
                    && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return View(model);
            }

            TempData["SuccessMessage"] = "Inicio de sesión exitoso";

            return RedirectToAction(nameof(Index)); // o Home/Index si quieres
        }

    }
}
