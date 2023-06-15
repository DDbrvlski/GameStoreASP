using GameStore.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Intranet.Controllers
{
    //To jest kontroler bazowy
    //z niego beda dziedziczyc wszystkie kontrolery realizujace operacje elementarne
    //czyli CRUD

    //Klasa basecontroller uzywa typu generycznego TEntity pod ktory w przypadku towarow zostanie wyswietlony towar
    //Jezeli klasa ma conajmnije jedna funkcje abstrakcyjna to tez musi byc abstrakcyjna
    public abstract class BaseController<TEntity> : Controller
    {
        protected readonly GameStoreContext _context;
        public BaseController(GameStoreContext context)
        {
            _context = context;
        }
        //funkcja jest abstrakcyjna jezeli nie ma bloku (nie wiemy jak ja napisac, dopiero wiemy jak napisac w klasach dziedziczacych)
        public abstract Task<List<TEntity>> GetEntityList();
        //Index wyswietla wszystkie towary
        public async Task<IActionResult> Index()
        {
            return View(await GetEntityList());
        }
        //funkcja setselectlist inicjalizuje dane do wyboru w comboboxie
        //jezeli tabela(encja) bedzie miala klucze obce to wtedy nadpiszemy tę funckje w klasach dziedziczacych
        //jezeli tabela nie bedzie miala kluczy obcych to nie bedziemy tej funkcji nadpisywac i zwrocimy nulla
        public virtual Task SetSelectList() // ta funkcja ustawia dane do comboboxa
        {
            return null;
        }
        //ta funkcja create wywołuje się przy wejściu na widok dodawania rekordów
        public async Task<IActionResult> Create()
        {
            await SetSelectList(); // uwaga przed wywolaniem widoku inicjalizujemy comboboxy funkcja setselectlist
            return View();
        }
        //to jest funkcja która wywołuje się po naciśnięciu przycisku dodaj
        [HttpPost]
        public async Task<IActionResult> Create(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
