using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using GameStore.Data.Data.Shop;

namespace GameStore.Intranet.Controllers
{
    public class NewsController : BaseController<News>
    {
        public NewsController(GameStoreContext context) : base(context)
        {
        }

        public override Task<News> CreateEntityWithImage(News entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<News> EditEntityWithImage(News entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<News> GetEntity(int id)
        {
            return await _context.News.FirstOrDefaultAsync(p => p.IdNews == id);
        }

        public override async Task<int> GetEntityId(News entity)
        {
            return entity.IdNews;
        }

        public override Task<List<News>> GetEntityList()
        {
            return _context.News.ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            _context.News.Remove(item);
        }

        protected override bool EntityExists(int id)
        {
            return (_context.News?.Any(x => x.IdNews == id)).GetValueOrDefault();
        }
    }
}
