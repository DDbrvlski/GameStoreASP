using Microsoft.AspNetCore.Mvc;

namespace GameStore.PortalWWW.Controllers
{
    public class ProductDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
