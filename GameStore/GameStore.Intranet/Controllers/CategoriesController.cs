using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Data.Shop;
using GameStore.Data.Data;
using GameStore.Data.Data.CMS;

namespace GameStore.Intranet.Controllers
{
    public class CategoriesController : BaseController<Categories>
    {
        public CategoriesController(GameStoreContext context) : base(context)
        {
        }

        public override Task<Categories> CreateEntityWithImage(Categories entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<Categories> EditEntityWithImage(Categories entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<Categories> GetEntity(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.IdCategory == id);
        }

        public override async Task<int> GetEntityId(Categories entity)
        {
            return entity.IdCategory;
        }

        public override Task<List<Categories>> GetEntityList()
        {
            return _context.Categories.ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            item.IsActive = false;
        }

        protected override bool EntityExists(int id)
        {
            return (_context.Categories?.Any(x => x.IdCategory == id)).GetValueOrDefault();
        }
    }
}
