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
    public class FooterDetailsController : Controller
    {
        private readonly GameStoreContext _context;

        public FooterDetailsController(GameStoreContext context)
        {
            _context = context;
        }

        // GET: FooterDetails
        public async Task<IActionResult> Index()
        {
            return _context.FooterDetails != null ?
                        View(await _context.FooterDetails.ToListAsync()) :
                        Problem("Entity set 'GameStoreContext.FooterDetails'  is null.");
        }

        // GET: FooterDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FooterDetails == null)
            {
                return NotFound();
            }

            var FooterDetails = await _context.FooterDetails
                .FirstOrDefaultAsync(m => m.IdFooterDetail == id);
            if (FooterDetails == null)
            {
                return NotFound();
            }

            return View(FooterDetails);
        }

        // GET: FooterDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FooterDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFooterDetail,Title,Content")] FooterDetails FooterDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(FooterDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(FooterDetails);
        }

        // GET: FooterDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FooterDetails == null)
            {
                return NotFound();
            }

            var FooterDetails = await _context.FooterDetails.FindAsync(id);
            if (FooterDetails == null)
            {
                return NotFound();
            }
            return View(FooterDetails);
        }

        // POST: FooterDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFooterDetail,Title,Content")] FooterDetails FooterDetails)
        {
            if (id != FooterDetails.IdFooterDetail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(FooterDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FooterDetailsExists(FooterDetails.IdFooterDetail))
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
            return View(FooterDetails);
        }

        // GET: FooterDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FooterDetails == null)
            {
                return NotFound();
            }

            var FooterDetails = await _context.FooterDetails
                .FirstOrDefaultAsync(m => m.IdFooterDetail == id);
            if (FooterDetails == null)
            {
                return NotFound();
            }

            return View(FooterDetails);
        }

        // POST: FooterDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FooterDetails == null)
            {
                return Problem("Entity set 'GameStoreContext.FooterDetails'  is null.");
            }
            var FooterDetails = await _context.FooterDetails.FindAsync(id);
            if (FooterDetails != null)
            {
                _context.FooterDetails.Remove(FooterDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FooterDetailsExists(int id)
        {
            return (_context.FooterDetails?.Any(e => e.IdFooterDetail == id)).GetValueOrDefault();
        }
    }
}
