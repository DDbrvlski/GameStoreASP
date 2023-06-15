using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Intranet.Controllers
{
    public class FooterLinksController : Controller
    {
        private readonly GameStoreContext _context;

        public FooterLinksController(GameStoreContext context)
        {
            _context = context;
        }

        // GET: FooterLinks
        public async Task<IActionResult> Index()
        {
            return _context.FooterLinks != null ?
                        View(await _context.FooterLinks.ToListAsync()) :
                        Problem("Entity set 'GameStoreContext.FooterLinks'  is null.");
        }

        // GET: FooterLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FooterLinks == null)
            {
                return NotFound();
            }

            var FooterLinks = await _context.FooterLinks
                .FirstOrDefaultAsync(m => m.IdFooterLink == id);
            if (FooterLinks == null)
            {
                return NotFound();
            }

            return View(FooterLinks);
        }

        // GET: FooterLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FooterLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFooterLink,Title,Position,Link")] FooterLinks FooterLinks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(FooterLinks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(FooterLinks);
        }

        // GET: FooterLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FooterLinks == null)
            {
                return NotFound();
            }

            var FooterLinks = await _context.FooterLinks.FindAsync(id);
            if (FooterLinks == null)
            {
                return NotFound();
            }
            return View(FooterLinks);
        }

        // POST: FooterLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFooterLink,Title,Position,Link")] FooterLinks FooterLinks)
        {
            if (id != FooterLinks.IdFooterLink)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(FooterLinks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooterLinksExists(FooterLinks.IdFooterLink))
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
            return View(FooterLinks);
        }

        // GET: FooterLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FooterLinks == null)
            {
                return NotFound();
            }

            var FooterLinks = await _context.FooterLinks
                .FirstOrDefaultAsync(m => m.IdFooterLink == id);
            if (FooterLinks == null)
            {
                return NotFound();
            }

            return View(FooterLinks);
        }

        // POST: FooterLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FooterLinks == null)
            {
                return Problem("Entity set 'GameStoreContext.FooterLinks'  is null.");
            }
            var FooterLinks = await _context.FooterLinks.FindAsync(id);
            if (FooterLinks != null)
            {
                _context.FooterLinks.Remove(FooterLinks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooterLinksExists(int id)
        {
            return (_context.FooterLinks?.Any(e => e.IdFooterLink == id)).GetValueOrDefault();
        }
    }
}
