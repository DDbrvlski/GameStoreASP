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
    public class ProducersController : Controller
    {
        private readonly GameStoreContext _context;
        private List<Categories> _categories;

        public ProducersController(GameStoreContext context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            return _context.Producers != null ?
                        View(await _context.Producers.ToListAsync()) :
                        Problem("Entity set 'GameStoreContext2023.Producers'  is null.");
        }

        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var Producers = await _context.Producers
                .FirstOrDefaultAsync(m => m.IdProducer == id);
            if (Producers == null)
            {
                return NotFound();
            }

            return View(Producers);
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            if(_categories == null)
            {
                _categories = _context.Categories.ToList();
            }
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducer,Name,IdCategory,IsActive")] Producers Producers)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (!ModelState.IsValid)
            {
                _context.Add(Producers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Producers);
        }

        // GET: Producers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var Producers = await _context.Producers.FindAsync(id);
            if (Producers == null)
            {
                return NotFound();
            }
            return View(Producers);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducer,Name,IdCategory,IsActive")] Producers Producers)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id != Producers.IdProducer)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(Producers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducersExists(Producers.IdProducer))
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
            return View(Producers);
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Producers == null)
            {
                return NotFound();
            }

            var Producers = await _context.Producers
                .FirstOrDefaultAsync(m => m.IdProducer == id);
            if (Producers == null)
            {
                return NotFound();
            }

            return View(Producers);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Producers == null)
            {
                return Problem("Entity set 'GameStoreContext2023.Producers'  is null.");
            }
            var Producers = await _context.Producers.FindAsync(id);
            if (Producers != null)
            {
                _context.Producers.Remove(Producers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducersExists(int id)
        {
            return (_context.Producers?.Any(e => e.IdProducer == id)).GetValueOrDefault();
        }
    }
}
