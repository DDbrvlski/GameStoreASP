using GameStore.Data.Data.CMS;
using GameStore.Data.Data;
using GameStore.PortalWWW.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.PortalWWW.Controllers
{
    public class BaseController : Controller
    {
        protected readonly GameStoreContext _context;
        protected readonly List<FooterLinks> _flinks;
        protected readonly FooterDetails _fdetails;
        protected readonly List<Page> _pages;
        protected readonly List<PageContent> _pageContent;
        protected readonly AccountB _accountB;
        public BaseController(GameStoreContext context, AccountB accountB)
        {
            _context = context;
            _flinks = _context.FooterLinks.ToList();
            _fdetails = _context.FooterDetails.First();
            _pages = _context.Page.OrderBy(p => p.Position).ToList();
            _pageContent = _context.PageContent.ToList();
            _accountB = accountB;
        }
        protected void SetViewBags()
        {
            ViewBag.FootLinks = _flinks;
            ViewBag.FootDetails = _fdetails;
            ViewBag.Pages = _pages;
            ViewBag.FooterLinksTitle = GetContentBySectionAndTitle("Footer_title", "Links");
            ViewBag.FooterMediaTitle = GetContentBySectionAndTitle("Footer_title", "Media");
            ViewBag.FooterSiteTitle = _pages.First().Content;
            ViewBag.UserId = _accountB.GetUserId();
        }

        protected void GetInputs(int id)
        {
            ViewBag.PageInputs = _pageContent.Where(x => x.IdPage == id && x.Section == "Input").OrderBy(p => p.Position).ToList();
        }

        protected string GetContentBySectionAndTitle(string section, string title)
        {
            return _pageContent.First(x => x.Section == section && x.Title == title).Content;
        }
    }
}
