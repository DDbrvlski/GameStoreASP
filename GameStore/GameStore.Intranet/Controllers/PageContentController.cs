using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using GameStore.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Intranet.Controllers
{
    public class PageContentController : BaseController<PageContent>
    {
        private readonly List<Page> _page;
        public PageContentController(GameStoreContext context) : base(context)
        {
            _page = _context.Page.ToList();
        }

        public override Task<PageContent> CreateEntityWithImage(PageContent entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<PageContent> EditEntityWithImage(PageContent entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<PageContent> GetEntity(int id)
        {
            return await _context.PageContent.Include(x => x.Page).FirstOrDefaultAsync(p => p.IdPageContent == id);
        }

        public override async Task<int> GetEntityId(PageContent entity)
        {
            return entity.IdPageContent;
        }

        public override Task<List<PageContent>> GetEntityList()
        {
            return _context.PageContent.Include(x => x.Page).ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            _context.PageContent.Remove(item);
        }

        protected override bool EntityExists(int id)
        {
            return (_context.PageContent?.Any(x => x.IdPageContent == id)).GetValueOrDefault();
        }
        public override async Task SetSelectList()
        {
            ViewBag.Categories = new SelectList(_page, "IdPage", "Name");
        }

    }
}

