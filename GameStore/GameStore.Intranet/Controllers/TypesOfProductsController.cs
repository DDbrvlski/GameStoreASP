using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Data.Shop;
using GameStore.Data.Data;

namespace GameStore.Intranet.Controllers
{
    public class TypesOfProductsController : BaseController<TypesOfProducts>
    {
        private readonly GameStoreContext _context;
        private readonly List<Categories> _categories;

        public TypesOfProductsController(GameStoreContext context) : base(context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
        }

        public override Task<TypesOfProducts> CreateEntityWithImage(TypesOfProducts entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<TypesOfProducts> EditEntityWithImage(TypesOfProducts entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<TypesOfProducts> GetEntity(int id)
        {
            return await _context.TypesOfProducts.Include(x => x.Category).FirstOrDefaultAsync(p => p.IdTypesOfProducts == id);
        }

        public override async Task<int> GetEntityId(TypesOfProducts entity)
        {
            return entity.IdTypesOfProducts;
        }

        public override Task<List<TypesOfProducts>> GetEntityList()
        {
            return _context.TypesOfProducts.Where(x => x.IsActive == true).Include(x => x.Category).ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            item.IsActive = false;
        }

        protected override bool EntityExists(int id)
        {
            return (_context.TypesOfProducts?.Any(x => x.IdTypesOfProducts == id)).GetValueOrDefault();
        }
        public override async Task SetSelectList()
        {
            ViewBag.Categories = new SelectList(_categories, "IdCategory", "Name");
        }
    }
}
