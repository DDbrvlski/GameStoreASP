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
    public class TypesOfProductsController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<Categories> _categories;

        public TypesOfProductsController(GameStoreContext context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
        }

        // GET: TypesOfProducts
        public async Task<IActionResult> Index()
        {
            return _context.TypesOfProducts != null ?
                        View(await _context.TypesOfProducts.ToListAsync()) :
                        Problem("Entity set 'GameStoreContext2023.TypesOfProducts'  is null.");
        }

        // GET: TypesOfProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypesOfProducts == null)
            {
                return NotFound();
            }

            var TypesOfProducts = await _context.TypesOfProducts
                .FirstOrDefaultAsync(m => m.IdTypesOfProducts == id);
            if (TypesOfProducts == null)
            {
                return NotFound();
            }

            return View(TypesOfProducts);
        }

        // GET: TypesOfProducts/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            return View();
        }

        // POST: TypesOfProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTypesOfProducts,Name,IdCategory,IsActive")] TypesOfProducts TypesOfProducts)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (!ModelState.IsValid)
            {
                _context.Add(TypesOfProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(TypesOfProducts);
        }

        // GET: TypesOfProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id == null || _context.TypesOfProducts == null)
            {
                return NotFound();
            }

            var TypesOfProducts = await _context.TypesOfProducts.FindAsync(id);
            if (TypesOfProducts == null)
            {
                return NotFound();
            }
            return View(TypesOfProducts);
        }

        // POST: TypesOfProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTypesOfProducts,Name,IdCategory,IsActive")] TypesOfProducts TypesOfProducts)
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            if (id != TypesOfProducts.IdTypesOfProducts)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(TypesOfProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesOfProductsExists(TypesOfProducts.IdTypesOfProducts))
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
            return View(TypesOfProducts);
        }

        // GET: TypesOfProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypesOfProducts == null)
            {
                return NotFound();
            }

            var TypesOfProducts = await _context.TypesOfProducts
                .FirstOrDefaultAsync(m => m.IdTypesOfProducts == id);
            if (TypesOfProducts == null)
            {
                return NotFound();
            }

            return View(TypesOfProducts);
        }

        // POST: TypesOfProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypesOfProducts == null)
            {
                return Problem("Entity set 'GameStoreContext2023.TypesOfProducts'  is null.");
            }
            var TypesOfProducts = await _context.TypesOfProducts.FindAsync(id);
            if (TypesOfProducts != null)
            {
                _context.TypesOfProducts.Remove(TypesOfProducts);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesOfProductsExists(int id)
        {
            return (_context.TypesOfProducts?.Any(e => e.IdTypesOfProducts == id)).GetValueOrDefault();
        }
    }
}
