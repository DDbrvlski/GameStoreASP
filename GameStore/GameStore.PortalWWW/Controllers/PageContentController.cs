using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PortalWWW.Controllers
{
    public class PageContentController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<Page> _pages;
        public PageContentController(GameStoreContext context)
        {
            _context = context;
            _pages = _context.Page.OrderBy(p => p.Position).ToList();
        }
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                id = _pages.First().IdPage;
            }

            var item = _context.Page.Find(id);

            return View(item);
        }
    }
}
