using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Data.Data;
using GameStore.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Intranet.Controllers
{
    public class FooterLinksController : BaseController<FooterLinks>
    {
        public FooterLinksController(GameStoreContext context) : base(context)
        {
        }

        public override Task<FooterLinks> CreateEntityWithImage(FooterLinks entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<FooterLinks> EditEntityWithImage(FooterLinks entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<FooterLinks> GetEntity(int id)
        {
            return await _context.FooterLinks.FirstOrDefaultAsync(p => p.IdFooterLink == id);
        }

        public override async Task<int> GetEntityId(FooterLinks entity)
        {
            return entity.IdFooterLink;
        }

        public override Task<List<FooterLinks>> GetEntityList()
        {
            return _context.FooterLinks.ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            _context.FooterLinks.Remove(item);
        }

        protected override bool EntityExists(int id)
        {
            return (_context.FooterLinks?.Any(x => x.IdFooterLink == id)).GetValueOrDefault();
        }
    }
}
