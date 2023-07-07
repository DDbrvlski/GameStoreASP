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
using Microsoft.CodeAnalysis;
using System.Security.Policy;

namespace GameStore.Intranet.Controllers
{
    public class ImagesController : BaseController<Images>
    {
        private readonly List<Products> _products;

        public ImagesController(GameStoreContext context) : base(context)
        {
            _products = _context.Products.ToList();
        }
        
        public override Task<List<Images>> GetEntityList()
        {
            return _context.Images.Where(x => x.IsActive == true).Include(x => x.Product).ToListAsync();
        }

        public override async Task<Images> GetEntity(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(p => p.IdImage == id);
        }

        public override async Task<int> GetEntityId(Images entity)
        {
            return entity.IdImage;
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            item.IsActive = false;
        }

        protected override bool EntityExists(int id)
        {
            return (_context.Images?.Any(x => x.IdImage == id)).GetValueOrDefault();
        }

        public override async Task<Images> CreateEntityWithImage(Images images, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                await UploadImageAsync(file);
                string fileName = Path.GetFileName(file.FileName);

                images.Name = fileName;
                images.Image = fileName;
                images.ImageFile = file;
            }
            return null;
        }

        public override async Task<Images> EditEntityWithImage(Images images, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                await UploadImageAsync(file);
                string fileName = Path.GetFileName(file.FileName);

                images.Name = fileName;
                images.Image = fileName;
                images.ImageFile = file;
            }
            _context.Update(images);

            await _context.SaveChangesAsync();
            return null;
        }
        public override async Task SetSelectList()
        {
            ViewBag.Products = new SelectList(_products, "IdProduct", "Name");
        }
        private async Task UploadImageAsync(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

        } 
    }
}
