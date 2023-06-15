using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Data.Shop;
using GameStore.Data.Data;

namespace GameStore.Intranet.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<Categories> _categories;

        public PlatformsController(GameStoreContext context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
        }

        // GET: Platforms
        public async Task<IActionResult> Index()
        {
            return _context.Platforms != null ?
                        View(await _context.Platforms.ToListAsync()) :
                        Problem("Entity set 'GameStoreContext2023.Platforms'  is null.");
        }

        // GET: Platforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Platforms == null)
            {
                return NotFound();
            }

            var Platforms = await _context.Platforms
                .FirstOrDefaultAsync(m => m.IdPlatform == id);
            if (Platforms == null)
            {
                return NotFound();
            }

            return View(Platforms);
        }

        // GET: Platforms/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            return View();
        }

        // POST: Platforms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlatform,Name,IdCategory,IsActive")] Platforms Platforms)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (!ModelState.IsValid)
            {
                _context.Add(Platforms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Platforms);
        }

        // GET: Platforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id == null || _context.Platforms == null)
            {
                return NotFound();
            }

            var Platforms = await _context.Platforms.FindAsync(id);
            if (Platforms == null)
            {
                return NotFound();
            }
            return View(Platforms);
        }

        // POST: Platforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlatform,Name,IdCategory,IsActive")] Platforms Platforms)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id != Platforms.IdPlatform)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(Platforms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatformsExists(Platforms.IdPlatform))
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
            return View(Platforms);
        }

        // GET: Platforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Platforms == null)
            {
                return NotFound();
            }

            var Platforms = await _context.Platforms
                .FirstOrDefaultAsync(m => m.IdPlatform == id);
            if (Platforms == null)
            {
                return NotFound();
            }

            return View(Platforms);
        }

        // POST: Platforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Platforms == null)
            {
                return Problem("Entity set 'GameStoreContext2023.Platforms'  is null.");
            }
            var Platforms = await _context.Platforms.FindAsync(id);
            if (Platforms != null)
            {
                _context.Platforms.Remove(Platforms);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatformsExists(int id)
        {
            return (_context.Platforms?.Any(e => e.IdPlatform == id)).GetValueOrDefault();
        }
    }
}
