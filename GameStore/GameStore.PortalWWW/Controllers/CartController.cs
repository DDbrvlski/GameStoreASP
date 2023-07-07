using GameStore.Data.Data.CMS;
using GameStore.Data.Data;
using Microsoft.AspNetCore.Mvc;
using GameStore.PortalWWW.Models.BusinessLogic;
using GameStore.PortalWWW.Models.Shop;
using GameStore.Data.Data.Account;
using static GameStore.PortalWWW.Models.BusinessLogic.AccountB;

namespace GameStore.PortalWWW.Controllers
{
    public class CartController : BaseController
    {
        public CartController(GameStoreContext context, AccountB accountB) : base(context, accountB)
        {
        }
        #region Widoki
        public async Task<IActionResult> Index()
        {
            SetViewBags();
            CartB cart = new CartB(this._context, this.HttpContext);
            var cartDetails = new CartDetails
            {
                CartElements = await cart.GetCartElements(),
                FullPrice = await cart.GetFullPrice()
            };
            return View(cartDetails);
        }
        public async Task<ActionResult> Order()
        {
            SetViewBags();
            if (CheckIfUserIsLoggedIn())
            {
                var account = _context.Accounts.FirstOrDefault(x => x.IdAccount == _accountB.GetUserId());
                await AddItemsFromCartToOrder(account);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion
        #region Funkcje
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order([Bind("FirstName, LastName, Email, PhoneNumber")] Accounts account)
        {
            account.IdAccountType = _context.AccountType.FirstOrDefault(x => x.Name == "Anonymous").IdAccountType;
            account.IsActive = true;
            account.CreatedDate = DateTime.Now;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            await AddItemsFromCartToOrder(account);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderByLogin(string userName, string password)
        {
            if (userName != null && password != null)
            {
                var result = await _accountB.LoginUser(userName, password);

                switch (result)
                {
                    case LoginResult.Success:
                        await AddItemsFromCartToOrder(_context.Accounts.FirstOrDefault(x => x.UserName == userName));
                        return RedirectToAction("Index", "Home");
                    case LoginResult.UsernameValid:
                        TempData["RegistrationError"] = "Podana nazwa użytkownika jest błędna.";
                        break;
                    case LoginResult.PasswordValid:
                        TempData["RegistrationError"] = "Podane hasło jest błędne.";
                        break;
                    case LoginResult.Failure:
                        TempData["RegistrationError"] = "Wystąpił błąd podczas rejestracji.";
                        break;
                }
            }
            return View("Order");
        }

        [HttpGet]
        public async Task<IActionResult> GetAmountOfItems()
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            int amount = await cart.GetAmountOfItems();

            return Json(new { amount });
        }

        public async Task<ActionResult> AddToCart(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            cart.AddToCart(await _context.Products.FindAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            cart.RemoveElement(id);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> IncreaseByOne(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            cart.ChangeAmountOfElement(id, 1);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> DecreaseByOne(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            cart.ChangeAmountOfElement(id, -1);
            return RedirectToAction("Index");
        }
        private async Task AddItemsFromCartToOrder(Accounts account)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            var cartItems = await cart.GetCartElements();

            var order = new Order();
            order.IdAccount = account.IdAccount;
            order.Account = account;
            order.IsActive = true;
            order.FullPrice = await cart.GetFullPrice();
            order.Amount = await cart.GetAmountOfItems();
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            foreach (var cartItem in cartItems)
            {
                var orderElement = new OrderElement()
                {
                    IsActive = true,
                    OrderDate = DateTime.Now,
                    IdOrder = order.IdOrder,
                    Order = order,
                    IdProduct = cartItem.IdProduct,
                    Product = cartItem.Product,
                    Amount = cartItem.Amount,
                    Price = (decimal)(cartItem.Product.Price * cartItem.Amount),
                };
                _context.CartElement.Remove(cartItem);
                _context.OrderElement.Add(orderElement);
            }
            await _context.SaveChangesAsync();

        }
        /// <summary>
        ///  Checks if user is logged in
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckIfUserIsLoggedIn()
        {
            if (_accountB.GetUserId() == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

