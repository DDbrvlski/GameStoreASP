using GameStore.Data.Data;
using GameStore.Data.Data.Media;
using GameStore.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Intranet.Controllers
{
    
    public abstract class BaseController<TEntity> : Controller
    {
        protected readonly GameStoreContext _context;
        public BaseController(GameStoreContext context)
        {
            _context = context;
        }

        #region Widoki
        public async Task<IActionResult> Index()
        {
            return View(await GetEntityList());
        }
        public async Task<IActionResult> Create()
        {
            await SetSelectList();
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            SetSelectList();
            var selectedEntity = await GetEntity(id);

            if (selectedEntity == null)
            {
                return NotFound();
            }

            return View(selectedEntity);
        }
        public async Task<IActionResult> Delete(int id, TEntity entity)
        {
            if (id == null || entity == null)
            {
                return NotFound();
            }
            return View(await GetEntity(id));
        }
        #endregion
        #region Funkcje
        //Zwraca listę wszystkich elementów
        public abstract Task<List<TEntity>> GetEntityList();
        //Zwraca item o podanym id
        public abstract Task<TEntity> GetEntity(int id);
        //Zwraca id podanego itemu
        public abstract Task<int> GetEntityId(TEntity entity);
        //Ustawia pole IsActive danego elementu na false
        public abstract Task RemoveSelectedElement(int id);
        protected abstract bool EntityExists(int id);
        //Dodawanie elementow dla tabel ze zdjeciami
        public abstract Task<TEntity> CreateEntityWithImage(TEntity entity, IFormFile file);
        //Edycja elementu dla tabeli ze zdjeciami
        public abstract Task<TEntity> EditEntityWithImage(TEntity entity, IFormFile file);
        //Comboboxy
        public virtual Task SetSelectList()
        {
            return Task.CompletedTask;
        }
        //Zwraca wszystkie pola dla itemu
        public async Task<IActionResult> Details(int id, TEntity entity)
        {
            if (id == null || entity == null)
            {
                return NotFound();
            }

            var selectedEntity = await GetEntity(id);

            if (selectedEntity == null)
            {
                return NotFound();
            }
            return View(selectedEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TEntity entity, IFormFile? file)
        {
            SetSelectList();
            if (file != null)
            {
                await CreateEntityWithImage(entity, file);
            }
            else
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TEntity entity, IFormFile? file)
        {
            if (id != await GetEntityId(entity))
            {
                return NotFound();
            }

            SetSelectList();

            try
            {
                if (file == null)
                {
                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await EditEntityWithImage(entity, file);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(await GetEntityId(entity)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await GetEntity(id);

            if (entity == null)
            {
                return Problem("Entity is null.");
            }

            if (await GetEntity(id) != null)
            {
                await RemoveSelectedElement(id);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
