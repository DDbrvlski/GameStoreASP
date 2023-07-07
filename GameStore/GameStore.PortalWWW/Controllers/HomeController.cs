using GameStore.Data.Data;
using GameStore.Data.Data.Account;
using GameStore.Data.Data.CMS;
using GameStore.PortalWWW.Models;
using GameStore.PortalWWW.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameStore.PortalWWW.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(GameStoreContext context, AccountB accountB) : base(context, accountB)
        {
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                id = _pages.First().IdPage;
            }
            SetViewBags();
            ViewBag.NewsTitle = GetContentBySectionAndTitle("Section_title", "News");
            ViewBag.SaleTitle = GetContentBySectionAndTitle("Section_title", "Sale");
            ViewBag.News = _context.News.OrderBy(p => p.Position).ToList();
            //ViewBag.SectionTitles = _pageContent.Where(x => x.Section == "Section_title").OrderBy(p => p.Position).ToList();
            var item = _context.Page.Find(id);

            return View(item);
        }

        public IActionResult Contact(int id)
        {
            SetViewBags();
            GetInputs(id);
            ViewBag.TextTitle = _pageContent.First(x => x.Section == "Text" && x.IdPage == id).Content;
            ViewBag.PageButtons = _pageContent.Where(x => x.Section == "Button" && x.IdPage == id).ToList();
            var item = _context.Page.Find(id);

            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}