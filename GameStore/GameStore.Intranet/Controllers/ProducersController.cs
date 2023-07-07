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
    public class ProducersController : BaseController<Producers>
    {
        private List<Categories> _categories;
        public ProducersController(GameStoreContext context) : base(context)
        {
            _categories = _context.Categories.ToList();
        }

        public override Task<Producers> CreateEntityWithImage(Producers entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<Producers> EditEntityWithImage(Producers entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<Producers> GetEntity(int id)
        {
            return await _context.Producers.Include(x => x.Category).FirstOrDefaultAsync(p => p.IdProducer == id);
        }

        public override async Task<int> GetEntityId(Producers entity)
        {
            return entity.IdProducer;
        }

        public override Task<List<Producers>> GetEntityList()
        {
            return _context.Producers.Where(x => x.IsActive == true).Include(x => x.Category).ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            item.IsActive = false;
        }
        public override async Task SetSelectList()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
        }
        protected override bool EntityExists(int id)
        {
            return (_context.Producers?.Any(x => x.IdProducer == id)).GetValueOrDefault();
        }
    }
}
