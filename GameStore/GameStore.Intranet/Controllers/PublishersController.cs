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
    public class PublishersController : BaseController<Publishers>
    {
        private readonly List<Categories> _categories;

        public PublishersController(GameStoreContext context) : base(context)
        {
            _categories = _context.Categories.ToList();
        }

        public override Task<Publishers> CreateEntityWithImage(Publishers entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<Publishers> EditEntityWithImage(Publishers entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<Publishers> GetEntity(int id)
        {
            return await _context.Publishers.Include(x => x.Category).FirstOrDefaultAsync(p => p.IdPublisher == id);
        }

        public override async Task<int> GetEntityId(Publishers entity)
        {
            return entity.IdPublisher;
        }

        public override Task<List<Publishers>> GetEntityList()
        {
            return _context.Publishers.Where(x => x.IsActive == true).Include(x => x.Category).ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            item.IsActive = false;
        }

        protected override bool EntityExists(int id)
        {
            return (_context.Publishers?.Any(x => x.IdPublisher == id)).GetValueOrDefault();
        }
        public override async Task SetSelectList()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
        }

    }
}
