﻿using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using GameStore.Data.Data.Media;
using GameStore.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameStore.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly List<FooterLinks> _flinks;
        private readonly FooterDetails _fdetails;
        private readonly List<Page> _pages;
        private readonly List<PageContent> _pageContent;
        private readonly List<TypesOfProducts> _typesOfProducts;
        private readonly List<Producers> _producers;
        private readonly List<Publishers> _publishers;
        private readonly List<Platforms> _platforms;
        private List<Products> _products;
        private List<Products> _productsToDisplay;
        public ShopController(GameStoreContext context)
        {
            _context = context;
            _flinks = _context.FooterLinks.ToList();
            _fdetails = _context.FooterDetails.First();
            _pages = _context.Page.OrderBy(p => p.Position).ToList();
            _pageContent = _context.PageContent.ToList();
            _typesOfProducts = _context.TypesOfProducts.ToList();
            _producers = _context.Producers.ToList();
            _publishers = _context.Publishers.ToList();
            _platforms = _context.Platforms.ToList();
            _products = _context.Products.Include(t => t.Category).Include(x => x.Image).ToList();
        }
        public async Task<IActionResult> Index(int id, string search, int[] selectedTypes, int[] selectedProducers, int[] selectedPlatforms, int[] selectedPublishers, int minPrice, int maxPrice, int page = 1, int pageSize = 3)
        {
            ViewData["searchString"] = search;
            ViewData["selectedTypes"] = selectedTypes;
            ViewData["minPrice"] = minPrice;
            ViewData["maxPrice"] = maxPrice;
            ViewData["categoryId"] = id;

            _productsToDisplay = _products.Where(x => x.IdCategory == id).ToList();

            // Search
            if (!String.IsNullOrEmpty(search))
            {
                _productsToDisplay = _productsToDisplay.Where(s => s.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // Typ filter
            if (selectedTypes != null && selectedTypes.Length > 0)
            {
                var typeIds = selectedTypes.Select(t => (int?)t).ToList();
                _productsToDisplay = _productsToDisplay.Where(item => typeIds.Contains(item.IdTypesOfProducts)).ToList();
            }

            // Price filter
            if (minPrice >= 0 && maxPrice > minPrice && maxPrice != null)
            {
                _productsToDisplay = _productsToDisplay.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
            }

            // Producer filter
            if (selectedProducers != null && selectedProducers.Length > 0)
            {
                var typeIds = selectedProducers.Select(t => (int?)t).ToList();
                _productsToDisplay = _productsToDisplay.Where(item => typeIds.Contains(item.IdProducer)).ToList();
            }

            // Publisher filter
            if (selectedPublishers != null && selectedPublishers.Length > 0)
            {
                var typeIds = selectedPublishers.Select(t => (int?)t).ToList();
                _productsToDisplay = _productsToDisplay.Where(item => typeIds.Contains(item.IdPublisher)).ToList();
            }

            // Platforms filter
            if (selectedPlatforms != null && selectedPlatforms.Length > 0)
            {
                var typeIds = selectedPlatforms.Select(t => (int?)t).ToList();
                _productsToDisplay = _productsToDisplay.Where(item => typeIds.Contains(item.IdPlatform)).ToList();
            }

            var totalItems = _productsToDisplay.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            SetViewBags();
            SetFilterViewBags(id);

            _productsToDisplay = _productsToDisplay.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.Products = _productsToDisplay;
            return View(_productsToDisplay);
        }
        public async Task<IActionResult> Details(int? id)
        {
            SetViewBags();
            var allRatesAndCommentsForProduct = _context.RatesProductsAccounts.Where(r => r.IdProduct == id);
            string message = "";
            if (allRatesAndCommentsForProduct != null && allRatesAndCommentsForProduct.Any())
            {
                var allComments = allRatesAndCommentsForProduct
                                    .Include(r => r.Comment)
                                    .Include(r => r.Account)
                                    .Include(r => r.Rate)
                                    .Where(r => r.IdComment != null);
                if (allComments != null && allComments.Any())
                {
                    ViewBag.Comments = allComments;
                }
                double numberOfAllRates = allRatesAndCommentsForProduct.Count();
                double allPositiveRates = allRatesAndCommentsForProduct.Count(r => r.Rate.Rating == "Pozytywna");

                double rating = (allPositiveRates / numberOfAllRates) * 100;
                switch (rating)
                {
                    case > 60:
                        message = $"<div class='chip' style='margin: 0 0 1rem 0;color: green;'>W większości pozytywne ({rating}%)</div>";
                        break;
                    case > 40:
                        message = $"<div class='chip' style='margin: 0 0 1rem 0;color: orange;'>Mieszane ({rating}%)</div>";
                        break;
                    case >= 0:
                        message = $"<div class='chip' style='margin: 0 0 1rem 0; color: red;'>W większości negatywne ({rating}%)</div>";
                        break;
                    default:
                        message = "< div class='chip' style='margin: 0 0 1rem 0;'>Brak ocen</div>";
                        break;
                }
            }
            else
            {
                message = "<div class='chip' style='margin: 0 0 1rem 0;'>Brak ocen</div>";
            }

            

            ViewBag.Rating = message;

            ViewBag.GalleryImages = _context.Images.Where(x => x.IsActive == true && x.IdProduct == id && x.Position > 0).OrderBy(p => p.Position).ToList();
            return View(await _context.Products.Include(t => t.Category).Include(x => x.Image).FirstOrDefaultAsync(p => p.IdProduct == id));
        }

        private void SetFilterViewBags(int id)
        {
            ViewBag.TypesOfProducts = _typesOfProducts.Where(x => x.IdCategory == id);
            ViewBag.Publishers = _publishers.Where(x => x.IdCategory == id);
            ViewBag.Producers = _producers.Where(x => x.IdCategory == id);
            ViewBag.Platforms = _platforms.Where(x => x.IdCategory == id);
        }

        private void SetViewBags()
        {
            ViewBag.FootLinks = _flinks;
            ViewBag.FootDetails = _fdetails;
            ViewBag.Pages = _pages;
            ViewBag.FooterLinksTitle = GetContentBySectionAndTitle("Footer_title", "Links");
            ViewBag.FooterMediaTitle = GetContentBySectionAndTitle("Footer_title", "Media");
            ViewBag.FooterSiteTitle = _pages.First().Content;
        }
        private string GetContentBySectionAndTitle(string section, string title)
        {
            return _pageContent.First(x => x.Section == section && x.Title == title).Content;
        }
    }
}
