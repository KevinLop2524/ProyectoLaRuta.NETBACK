using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLaRuta.Models;

namespace ProyectoLaRuta.Controllers
{
    public class ServiceController : Controller
    {
        private readonly LarutaContext _context;

        public ServiceController(LarutaContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var servicios = await _context.Services
                .Include(s => s.User)
                .ToListAsync();

            return View(servicios);
        }


        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProyectoLaRuta.Models.Service service)
        {
            
            ModelState.Remove("User");
            ModelState.Remove("Posts");

            if (ModelState.IsValid)
            {
                
                service.FechaCreacion = DateTime.UtcNow;

               
                service.UserId = 1;

                _context.Services.Add(service);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(service);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Service service)
        {
            ModelState.Remove("User");
            ModelState.Remove("Posts");

            if (ModelState.IsValid)
            {
                _context.Update(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(service);
        }



        public async Task<IActionResult> Details(long id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
                return NotFound();

            return View(service);
        }


        
        public async Task<IActionResult> Delete(long id)
        {
            var service = await _context.Services
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        // POST: /Service/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
                return NotFound();

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
