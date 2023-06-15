 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Data.Shop;
using GameStore.Data.Data;
using System.Drawing;
using GameStore.Data.Data.Media;

namespace GameStore.Intranet.Controllers
{
    public class ProductsController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<Categories> _categories;
        private readonly List<Platforms> _platforms;
        private readonly List<Producers> _producers;
        private readonly List<Publishers> _publishers;
        private readonly List<TypesOfProducts> _typesofproducts;

        public ProductsController(GameStoreContext context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
            _platforms = _context.Platforms.ToList();
            _producers = _context.Producers.ToList();
            _publishers = _context.Publishers.ToList();
            _typesofproducts = _context.TypesOfProducts.ToList();
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.Where(x => x.IsActive == true).ToListAsync()) :
                          Problem("Entity set 'GameStoreContext2023.Products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Image)
                        .FirstOrDefaultAsync(p => p.IdProduct == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            GetAllViewBags();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,Name,Price,Description,IsActive,IdCategory,IdPublisher,IdProducer,IdTypesOfProducts,IdPlatform")] Products products, IFormFile file)
        {
            GetAllViewBags();
            if (!ModelState.IsValid)
            {

                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    var newImage = new Images
                    {
                        Name = fileName,
                        Image = $"{fileName}",
                        ImageFile = file,
                        Position = 0,
                        IsActive = true
                    };
                    _context.Images.Add(newImage);
                    await _context.SaveChangesAsync();
                    products.IdImage = newImage.IdImage;
                    products.Image = newImage;
                    products.IsActive = true;
                    _context.Add(products);
                    await _context.SaveChangesAsync();
                    newImage.IdProduct = products.IdProduct;
                    _context.Update(newImage);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                products.IsActive = true;
                _context.Add(products);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            GetAllViewBags();
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,IdImage,IsActive,Name,Price,Description,IdCategory,IdPublisher,IdProducer,IdTypesOfProducts,IdPlatform")] Products products, IFormFile file)
        {
            GetAllViewBags();
            if (id != products.IdProduct)
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
                        var newImage = new Images
                        {
                            Name = fileName,
                            Image = $"{fileName}",
                            ImageFile = file,
                            IdProduct = products.IdProduct,
                            Position = 0,
                            IsActive = true
                        };
                        products.Image.IsActive = false;
                        _context.Images.Add(newImage);
                        await _context.SaveChangesAsync();
                        products.IdImage = newImage.IdImage;
                        products.Image = newImage;
                    }
                    _context.Update(products);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.IdProduct))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                        .Include(p => p.Category)
                        .Include(p => p.Image)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'GameStoreContext2023.Products'  is null.");
            }
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                products.IsActive = false;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
          return (_context.Products?.Any(e => e.IdProduct == id)).GetValueOrDefault();
        }


        // help function
        public void GetAllViewBags()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            ViewBag.Platforms = new SelectList(_platforms, "IdPlatform", "Name");
            ViewBag.Producers = new SelectList(_producers, "IdProducer", "Name");
            ViewBag.Publishers = new SelectList(_publishers, "IdPublisher", "Name");
            ViewBag.TypesOfProducts = new SelectList(_typesofproducts, "IdTypesOfProducts", "Name");
        }
    }
}
