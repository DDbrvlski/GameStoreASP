using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Data.Media;
using GameStore.Data.Data;
using GameStore.Data.Data.Shop;

namespace GameStore.Intranet.Controllers
{
    public class ImagesController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<Products> _products;

        public ImagesController(GameStoreContext context)
        {
            _context = context;
            _products = _context.Products.ToList();
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
              return _context.Images != null ? 
                          View(await _context.Images.ToListAsync()) :
                          Problem("Entity set 'GameStoreContext2023.Images'  is null.");
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images
                .FirstOrDefaultAsync(m => m.IdImage == id);
            if (images == null)
            {
                return NotFound();
            }

            return View(images);
        }

        // GET: Images/Create
        public IActionResult Create()
        {
            ViewBag.Products = new SelectList(_products, "IdProduct", "Name");
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdImage,Name,Image,IdProduct,IsActive,Position")] Images images, IFormFile file)
        {
            ViewBag.Products = new SelectList(_products, "IdProduct", "Name");

            if (!ModelState.IsValid)
            {
                try
                {
                    if (file != null && file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        images.Name = fileName;
                        images.Image = fileName;
                        images.ImageFile = file;
                    }
                    _context.Add(images);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Wystąpił błąd: " + ex.Message);
                }
            }

            return View(images);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Products = new SelectList(_products, "IdProduct", "Name");
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images.FindAsync(id);
            if (images == null)
            {
                return NotFound();
            }
            return View(images);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdImage,Name,Image,IdProduct,IsActive,Position")] Images images, IFormFile file)
        {
            ViewBag.Products = new SelectList(_products, "IdProduct", "Name");
            if (id != images.IdImage)
            {
                return NotFound();
            }

                try
                {
                    if (file != null && file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        images.Name = fileName;
                        images.Image = fileName;
                        images.ImageFile = file;
                    }
                    _context.Update(images);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagesExists(images.IdImage))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Wystąpił błąd: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        ModelState.AddModelError(string.Empty, "Inner exception: " + ex.InnerException.Message);
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(images);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var images = await _context.Images
                .FirstOrDefaultAsync(m => m.IdImage == id);
            if (images == null)
            {
                return NotFound();
            }

            return View(images);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Images == null)
            {
                return Problem("Entity set 'GameStoreContext2023.Images'  is null.");
            }
            var images = await _context.Images.FindAsync(id);
            if (images != null)
            {
                _context.Images.Remove(images);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagesExists(int id)
        {
          return (_context.Images?.Any(e => e.IdImage == id)).GetValueOrDefault();
        }
    }
}
