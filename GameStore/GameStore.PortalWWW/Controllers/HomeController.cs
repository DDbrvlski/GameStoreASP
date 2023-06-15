using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using GameStore.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameStore.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<FooterLinks> _flinks;
        private readonly FooterDetails _fdetails;
        private readonly List<Page> _pages;
        private readonly List<PageContent> _pageContent;

        public HomeController(GameStoreContext context)
        {
            _context = context;
            _flinks = _context.FooterLinks.ToList();
            _fdetails = _context.FooterDetails.First();
            _pages = _context.Page.OrderBy(p => p.Position).ToList();
            _pageContent = _context.PageContent.ToList();
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                id = _pages.First().IdPage;
            }
            SetViewBags(id);
            ViewBag.NewsTitle = GetContentBySectionAndTitle("Section_title", "News");
            ViewBag.SaleTitle = GetContentBySectionAndTitle("Section_title", "Sale");
            ViewBag.News = _context.News.OrderBy(p => p.Position).ToList();
            //ViewBag.News = _context.Products.Include(t=>t.Category).Include(x=>x.Image).ToList();
            ViewBag.SectionTitles = _pageContent.Where(x => x.Section == "Section_title").OrderBy(p => p.Position).ToList();
            var item = _context.Page.Find(id);

            return View(item);
        }

        public IActionResult Contact(int id)
        {
            SetViewBags(id);
            GetInputs(id);
            ViewBag.TextTitle = _pageContent.First(x => x.Section == "Text" && x.IdPage == id).Content;
            ViewBag.PageButtons = _pageContent.Where(x => x.Section == "Button" && x.IdPage == id).ToList();
            var item = _context.Page.Find(id);

            return View(item);
        }

        public IActionResult Login(int id)
        {
            SetViewBags(id);
            GetInputs(id);
            ViewBag.PageButtons = _pages.Where(x => x.IdPage == id || x.IdPage == id+1).ToList();
            var item = _context.Page.Find(id);

            return View(item);
        }

        public IActionResult Register(int id)
        {
            SetViewBags(id);
            GetInputs(id);
            ViewBag.PageButtons = _pages.Where(x => x.IdPage == id).ToList();
            var item = _context.Page.Find(id);

            return View(item);
        }

        private void SetViewBags(int? id)
        {
            ViewBag.FootLinks = _flinks;
            ViewBag.FootDetails = _fdetails;
            ViewBag.Pages = _pages;
            ViewBag.FooterLinksTitle = GetContentBySectionAndTitle("Footer_title", "Links");
            ViewBag.FooterMediaTitle = GetContentBySectionAndTitle("Footer_title", "Media");
            ViewBag.FooterSiteTitle = _pages.First().Content;
        }

        private void GetInputs(int id)
        {
            ViewBag.PageInputs = _pageContent.Where(x => x.IdPage == id && x.Section == "Input").OrderBy(p => p.Position).ToList();
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