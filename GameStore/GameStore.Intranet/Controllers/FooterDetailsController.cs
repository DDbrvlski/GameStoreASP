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
    public class FooterDetailsController : BaseController<FooterDetails>
    {
        public FooterDetailsController(GameStoreContext context) : base(context)
        {
        }

        public override Task<FooterDetails> CreateEntityWithImage(FooterDetails entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override Task<FooterDetails> EditEntityWithImage(FooterDetails entity, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public override async Task<FooterDetails> GetEntity(int id)
        {
            return await _context.FooterDetails.FirstOrDefaultAsync(p => p.IdFooterDetail == id);
        }

        public override async Task<int> GetEntityId(FooterDetails entity)
        {
            return entity.IdFooterDetail;
        }

        public override Task<List<FooterDetails>> GetEntityList()
        {
            return _context.FooterDetails.ToListAsync();
        }

        public override async Task RemoveSelectedElement(int id)
        {
            var item = await GetEntity(id);
            _context.FooterDetails.Remove(item);
        }

        protected override bool EntityExists(int id)
        {
            return (_context.FooterDetails?.Any(x => x.IdFooterDetail == id)).GetValueOrDefault();
        }

    }
}
