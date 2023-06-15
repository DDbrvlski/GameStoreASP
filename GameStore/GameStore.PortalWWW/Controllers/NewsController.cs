using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using GameStore.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameStore.PortalWWW.Controllers
{
    public class News : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<FooterLinks> _flinks;
        private readonly FooterDetails _fdetails;
        private readonly List<Page> _pages;
        private readonly List<PageContent> _pageContent;

        public News(GameStoreContext context)
        {
            _context = context;
            _flinks = _context.FooterLinks.ToList();
            _fdetails = _context.FooterDetails.First();
            _pages = _context.Page.OrderBy(p => p.Position).ToList();
            _pageContent = _context.PageContent.ToList();
        }

        public async Task<IActionResult> Index(int? id)
        {
            SetViewBags(id);
            if (id == null)
            {
                id = _context.News.First().IdNews;
            }
            
            var item = await _context.News.FindAsync(id);
            return View(item);
        }
        private void SetViewBags(int? id)
        {
            ViewBag.FootLinks = _flinks;
            ViewBag.FootDetails = _fdetails;
            ViewBag.Pages = _pages;
            ViewBag.FooterLinksTitle = GetContentBySectionAndTitle("Footer_title", "Links");
            ViewBag.FooterMediaTitle = GetContentBySectionAndTitle("Footer_title", "Media");
        }
        private string GetContentBySectionAndTitle(string section, string title)
        {
            return _pageContent.First(x => x.Section == section && x.Title == title).Content;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}