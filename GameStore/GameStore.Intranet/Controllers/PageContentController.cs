using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Intranet.Controllers
{
    public class PageContentController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<Page> _page;
        public PageContentController(GameStoreContext context)
        {
            _context = context;
            _page = _context.Page.ToList();
        }
        // GET: PageContent
        public async Task<IActionResult> Index()
        {
            return _context.PageContent != null ?
                        View(await _context.PageContent.ToListAsync()) :
                        Problem("Entity set 'GameStoreContext2023.PageContent'  is null.");
        }

        // GET: PageContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PageContent == null)
            {
                return NotFound();
            }

            var pageContent = await _context.PageContent
                .FirstOrDefaultAsync(m => m.IdPageContent == id);
            if (pageContent == null)
            {
                return NotFound();
            }

            return View(pageContent);
        }

        // GET: PageContent/Create
        public IActionResult Create()
        {
            ViewBag.Pages = new SelectList(_page, "IdPage", "TitleLink");
            return View();
        }

        // POST: PageContent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPageContent,Link,Icon,Title,Content,Description,Position,IdPage,Section")] PageContent pageContent)
        {
            ViewBag.Pages = new SelectList(_page, "IdPage", "TitleLink");
            if (!ModelState.IsValid)
            {
                _context.Add(pageContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageContent);
        }

        // GET: PageContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PageContent == null)
            {
                return NotFound();
            }

            var pageContent = await _context.PageContent.FindAsync(id);
            if (pageContent == null)
            {
                return NotFound();
            }
            ViewBag.Pages = new SelectList(_page, "IdPage", "TitleLink");
            return View(pageContent);
        }

        // POST: PageContent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPageContent,Link,Icon,Title,Content,Description,Position,IdPage,Section")] PageContent pageContent)
        {
            if (id != pageContent.IdPageContent)
            {
                return NotFound();
            }
            ViewBag.Pages = new SelectList(_page, "IdPage", "TitleLink");
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageContentExists(pageContent.IdPageContent))
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
            return View(pageContent);
        }

        // GET: PageContent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PageContent == null)
            {
                return NotFound();
            }

            var pageContent = await _context.PageContent
                .FirstOrDefaultAsync(m => m.IdPageContent == id);
            if (pageContent == null)
            {
                return NotFound();
            }

            return View(pageContent);
        }

        // POST: PageContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PageContent == null)
            {
                return Problem("Entity set 'GameStoreContext2023.PageContent'  is null.");
            }
            var pageContent = await _context.PageContent.FindAsync(id);
            if (pageContent != null)
            {
                _context.PageContent.Remove(pageContent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageContentExists(int id)
        {
            return (_context.PageContent?.Any(e => e.IdPageContent == id)).GetValueOrDefault();
        }
    }
}

