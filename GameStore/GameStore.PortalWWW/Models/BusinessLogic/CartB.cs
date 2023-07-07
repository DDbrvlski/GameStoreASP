using GameStore.Data.Data;
using GameStore.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace GameStore.PortalWWW.Models.BusinessLogic
{
    public class CartB
    {
        private readonly GameStoreContext _context;
        private string IdSession;
        public CartB(GameStoreContext context, HttpContext httpContext)
        {
            _context = context;
            this.IdSession = GetIdSession(httpContext);
        }
        private string GetIdSession(HttpContext httpContext)
        {
            //Jeżeli w Sesji IdSesjiKoszyka jest null-em
            if (httpContext.Session.GetString("IdSession") == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdSession", httpContext.User.Identity.Name);
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempIdSession = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    httpContext.Session.SetString("IdSession", tempIdSession.ToString());
                }
            }
            return httpContext.Session.GetString("IdSession").ToString();
        }
        public void AddToCart(Products product)
        {
            //Najpierw sprawdzamy czy dany towar już istnieje w koszyku danego klienta
            var cartElement =
               (
                   from element in _context.CartElement
                   where element.IdSession == this.IdSession && element.IdProduct == product.IdProduct
                   select element
               ).FirstOrDefault();
            // jeżeli brak tego towaru w koszyku
            if (cartElement == null)
            {
                // Wtedy tworzymy nowy element w koszyku
                cartElement = new CartElement()
                {
                    IdSession = this.IdSession,
                    IdProduct = product.IdProduct,
                    Product = _context.Products.Find(product.IdProduct),
                    Amount = 1,
                    CreatedDate = DateTime.Now
                };
                //i dodajemy do kolekcji lokalne
                _context.CartElement.Add(cartElement);
            }
            else
            {
                // Jeżeli dany towar istnieje już w koszyku to liczbe sztuk zwiekszamy o 1
                cartElement.Amount++;
            }
            // Zapisujemy zmiany do bazy
            _context.SaveChanges();
        }
        public async Task<List<CartElement>> GetCartElements()
        {
            return await
               _context.CartElement.Where(e => e.IdSession == this.IdSession).Include(e => e.Product).Include(x => x.Product.Image).ToListAsync();
        }
        /// <summary>
        /// Returns price of all elements in cart
        /// </summary>
        /// <returns>decimal</returns>
        public async Task<decimal> GetFullPrice()
        {
            var item =
                (
                from element in _context.CartElement
                where element.IdSession == this.IdSession
                select (decimal?)element.Amount * element.Product.Price
                );
            return await item.SumAsync() ?? decimal.Zero;
        }
        /// <summary>
        /// Returns number of all elements in cart
        /// </summary>
        /// <returns>int</returns>
        public async Task<int> GetAmountOfItems()
        {
            var item = _context.CartElement.Where(x => x.IdSession == this.IdSession).Select(x => x.Amount);
            return await item.SumAsync();
        }
        /// <summary>
        /// Remove element from cart
        /// </summary>
        /// <param name="id"></param>
        public void RemoveElement(int id)
        {
            _context.CartElement.Remove(_context.CartElement.Where(x => x.IdCartElement == id).FirstOrDefault());
            _context.SaveChanges();
        }
        /// <summary>
        /// Changes amount of element in cart
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void ChangeAmountOfElement(int id, int amount)
        {
            var item = _context.CartElement.Where(x => x.IdCartElement == id).FirstOrDefault();
            item.Amount += amount;
            if (item.Amount > 0)
            {
                _context.CartElement.Update(item);
            }
            else
            {
                _context.CartElement.Remove(item);
            }
            _context.SaveChanges();
        }

    }
}
