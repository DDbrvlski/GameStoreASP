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
    public class PublishersController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<Categories> _categories;

        public PublishersController(GameStoreContext context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
        }

        // GET: Publishers
        public async Task<IActionResult> Index()
        {
            return _context.Publishers != null ?
                        View(await _context.Publishers.ToListAsync()) :
                        Problem("Entity set 'GameStoreContext2023.Publishers'  is null.");
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publishers == null)
            {
                return NotFound();
            }

            var Publishers = await _context.Publishers
                .FirstOrDefaultAsync(m => m.IdPublisher == id);
            if (Publishers == null)
            {
                return NotFound();
            }

            return View(Publishers);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPublisher,Name,IdCategory,IsActive")] Publishers Publishers)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (!ModelState.IsValid)
            {
                _context.Add(Publishers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Publishers);
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id == null || _context.Publishers == null)
            {
                return NotFound();
            }

            var Publishers = await _context.Publishers.FindAsync(id);
            if (Publishers == null)
            {
                return NotFound();
            }
            return View(Publishers);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPublisher,Name,IdCategory,IsActive")] Publishers Publishers)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id != Publishers.IdPublisher)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(Publishers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublishersExists(Publishers.IdPublisher))
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
            return View(Publishers);
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publishers == null)
            {
                return NotFound();
            }

            var Publishers = await _context.Publishers
                .FirstOrDefaultAsync(m => m.IdPublisher == id);
            if (Publishers == null)
            {
                return NotFound();
            }

            return View(Publishers);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publishers == null)
            {
                return Problem("Entity set 'GameStoreContext2023.Publishers'  is null.");
            }
            var Publishers = await _context.Publishers.FindAsync(id);
            if (Publishers != null)
            {
                _context.Publishers.Remove(Publishers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublishersExists(int id)
        {
            return (_context.Publishers?.Any(e => e.IdPublisher == id)).GetValueOrDefault();
        }
    }
}
