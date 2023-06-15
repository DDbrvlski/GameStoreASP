using GameStore.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.PortalWWW.Controllers
{
    public class CategoriesComponent : ViewComponent
    {
        private readonly GameStoreContext _context;
        public CategoriesComponent(GameStoreContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("CategoriesComponent", await _context.Categories.ToListAsync());
        }
    }
}
