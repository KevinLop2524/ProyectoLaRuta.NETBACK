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
    public class CommunitiesController : Controller
    {
        private readonly LarutaContext _context;

        public CommunitiesController(LarutaContext context)
        {
            _context = context;
        }

        // GET: Communities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Communities.ToListAsync());
        }

        // GET: Communities/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Communities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // GET: Communities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Communities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Community community)
        {
            if (ModelState.IsValid)
            {
                community.Active = true;                     
                community.DateOfCreation = DateTime.Now;      
                community.DeletedAt = null;                   

                community.CreatorId = 1;

                community.BannerPublicId = null;
                community.BannerUrl = null;
                community.LogoPublicId = null;
                community.LogoUrl = null;

                _context.Add(community);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(community);
        }


        // GET: Communities/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Communities.FindAsync(id);
            if (community == null)
            {
                return NotFound();
            }
            return View(community);
        }

        // POST: Communities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Active,Category,Description,Name,AllowsPosts,PostRules,BannerPublicId,BannerUrl,LogoPublicId,LogoUrl")] Community data)
        {
            if (!ModelState.IsValid)
                return View(data);

            var community = await _context.Communities.FindAsync(id);

            if (community == null)
                return NotFound();


            community.Name = data.Name;
            community.Description = data.Description;
            community.Category = data.Category;
            community.AllowsPosts = data.AllowsPosts;
            community.PostRules = data.PostRules;
            community.Active = data.Active;
            community.BannerPublicId = data.BannerPublicId;
            community.BannerUrl = data.BannerUrl;
            community.LogoPublicId = data.LogoPublicId;
            community.LogoUrl = data.LogoUrl;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: Communities/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Communities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        // POST: Communities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var community = await _context.Communities.FindAsync(id);
            if (community != null)
            {
                _context.Communities.Remove(community);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityExists(long id)
        {
            return _context.Communities.Any(e => e.Id == id);
        }
    }
}
