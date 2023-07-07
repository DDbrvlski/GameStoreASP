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
    public class PlatformsController : BaseController<Platforms>
    {
        private readonly List<Categories> _categories;

        public PlatformsController(GameStoreContext context) : base(context)
        {
            _categories = _context.Categories.ToList();
        }

        public override Task<Platforms> CreateEntityWithImage(Platforms entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<Platforms> EditEntityWithImage(Platforms entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<Platforms> GetEntity(int id)
        {
            return await _context.Platforms.Include(x => x.Category).FirstOrDefaultAsync(p => p.IdPlatform == id);
        }

        public override async Task<int> GetEntityId(Platforms entity)
        {
            return entity.IdPlatform;
        }

        public override Task<List<Platforms>> GetEntityList()
        {
            return _context.Platforms.Where(x => x.IsActive == true).Include(x => x.Category).ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            item.IsActive = false;
        }

        protected override bool EntityExists(int id)
        {
            return (_context.Platforms?.Any(x => x.IdPlatform == id)).GetValueOrDefault();
        }
        public override async Task SetSelectList()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
        }

    }
}
