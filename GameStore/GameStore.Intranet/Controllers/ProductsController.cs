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
    public class ProductsController : BaseController<Products>
    {
        private List<Categories> _categories;
        private List<Platforms> _platforms;
        private List<Producers> _producers;
        private List<Publishers> _publishers;
        private List<TypesOfProducts> _typesofproducts;

        public ProductsController(GameStoreContext context) : base(context)
        {
            _categories = _context.Categories.ToList();
            _platforms = _context.Platforms.ToList();
            _producers = _context.Producers.ToList();
            _publishers = _context.Publishers.ToList();
            _typesofproducts = _context.TypesOfProducts.ToList();
        }

        //Wyswietla wszystkie towary
        public override async Task<List<Products>> GetEntityList()
        {
            return await _context.Products.Where(x => x.IsActive == true).Include(p => p.Category).ToListAsync();
        }

        //Ustawia comboboxy
        public override async Task SetSelectList()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
            ViewBag.Platforms = new SelectList(_platforms, "IdPlatform", "Name");
            ViewBag.Producers = new SelectList(_producers, "IdProducer", "Name");
            ViewBag.Publishers = new SelectList(_publishers, "IdPublisher", "Name");
            ViewBag.TypesOfProducts = new SelectList(_typesofproducts, "IdTypesOfProducts", "Name");
        }

        //Zwraca produkt o podanym id
        public override async Task<Products> GetEntity(int id)
        {
            var product = _context.Products
                        .Include(p => p.Category)
                        .Include(p => p.TypeOfProduct)
                        .Include(p => p.Producer)
                        .Include(p => p.Publisher)
                        .Include(p => p.Platform)
                        .Include(p => p.Image)
                        .FirstOrDefaultAsync(p => p.IdProduct == id);
            //Przypisywanie pierwszego zdjecia z listy w celu unikniecia bledow
            //zwiazanych z brakiem image w produkcie
            if (product.Result.IdImage == null)
            {
                product.Result.IdImage = _context.Images.First().IdImage;
                product.Result.Image = _context.Images.First();
            }
            return await product;
        }
        public override async Task<Products> CreateEntityWithImage(Products products, IFormFile? file)
        {
            if (file != null && file.Length > 0)
            {
                //Tworzenie nowego Image w celu uzyskania IdImage dla Product
                var newImage = await AddNewImage(file);
                _context.Images.Add(newImage);
                await _context.SaveChangesAsync();

                //Ustawianie pozostałych pól dla Product
                products.IdImage = newImage.IdImage;
                products.Image = newImage;
                products.IsActive = true;
                _context.Add(products);
                await _context.SaveChangesAsync();

                //Ustawianie id nowego produktu dla nowego image
                newImage.IdProduct = products.IdProduct;
                _context.Update(newImage);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        //Usuwa element o podanym id
        public override async Task RemoveSelectedElement(int id)
        {
            var element = await _context.Products.FindAsync(id);
            element.IsActive = false;
        }

        public override async Task<int> GetEntityId(Products entity)
        {
            return entity.IdProduct;
        }

        protected override bool EntityExists(int id)
        {
            return (_context.Products?.Any(x => x.IdProduct == id)).GetValueOrDefault();
        }

        public override async Task<Products> EditEntityWithImage(Products products, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var image = _context.Images.Where(x => x.IdImage == products.IdImage).FirstOrDefault();

                //Zabezpieczenie przed dodaniem zdjęcia o takiej samej nazwie dla produktu
                if (Path.GetFileName(file.FileName) != image.Image)
                {
                    var newImage = await AddNewImage(file);
                    image.IsActive = false;
                    _context.Images.Add(newImage);
                    await _context.SaveChangesAsync();
                    products.IdImage = newImage.IdImage;
                    products.Image = newImage;
                }
            }
            _context.Update(products);

            await _context.SaveChangesAsync();
            return null;
        }
        private async Task<Images> AddNewImage(IFormFile file)
        {
            //Dodanie zdjęcia do folderu wwwroot/images
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            //Utworzenie nowego Image dla dodanego zdjęcia
            var newImage = new Images
            {
                Name = fileName,
                Image = $"{fileName}",
                ImageFile = file,
                Position = 0,
                IsActive = true
            };
            return newImage;
        }
    }
}
