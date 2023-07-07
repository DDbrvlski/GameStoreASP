using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using GameStore.PortalWWW.Models;
using GameStore.PortalWWW.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameStore.PortalWWW.Controllers
{
    public class News : BaseController
    {
        public News(GameStoreContext context, AccountB accountB) : base(context, accountB)
        {
        }

        public async Task<IActionResult> Index(int? id)
        {
            SetViewBags();
            if (id == null)
            {
                id = _context.News.First().IdNews;
            }

            var item = await _context.News.FindAsync(id);
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}