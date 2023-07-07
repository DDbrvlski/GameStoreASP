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
    public class PageController : BaseController<Page>
    {
        public PageController(GameStoreContext context) : base(context)
        {
        }

        public override Task<Page> CreateEntityWithImage(Page entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<Page> EditEntityWithImage(Page entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<Page> GetEntity(int id)
        {
            return await _context.Page.FirstOrDefaultAsync(p => p.IdPage == id);
        }

        public override async Task<int> GetEntityId(Page entity)
        {
            return entity.IdPage;
        }

        public override Task<List<Page>> GetEntityList()
        {
            return _context.Page.ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            _context.Page.Remove(item);
        }

        protected override bool EntityExists(int id)
        {
            return (_context.Page?.Any(x => x.IdPage == id)).GetValueOrDefault();
        }

    }
}
