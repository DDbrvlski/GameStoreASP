using GameStore.Data.Data.CMS;
using GameStore.Data.Data;
using Microsoft.AspNetCore.Mvc;
using GameStore.PortalWWW.Models.BusinessLogic;
using static GameStore.PortalWWW.Models.BusinessLogic.AccountB;
using GameStore.Data.Data.Account;
using GameStore.Data.Data.Shop;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace GameStore.PortalWWW.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(GameStoreContext context, AccountB accountB) : base(context, accountB)
        {
        }
        #region Widoki
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public IActionResult AccountDetails(int id)
        {
            SetViewBags();
            if (CheckIfUserIsLoggedIn())
            {
                GetInputs(id);
                var item = _context.Accounts.Find(id);

                return View(item);
            }
            else
            {
                return RedirectToLogin();
            }
        }
        public IActionResult AccountEdit(int id)
        {
            SetViewBags();
            if (CheckIfUserIsLoggedIn())
            {
                GetInputs(id);
                var item = _context.Accounts.Find(id);

                return View(item);
            }
            else
            {
                return RedirectToLogin();
            }
        }
        public IActionResult Register(int id)
        {
            if (!CheckIfUserIsLoggedIn())
            {
                SetViewBags();
                GetInputs(id);
                ViewBag.PageButtons = _pages.Where(x => x.IdPage == id).ToList();
                var item = _context.Page.Find(id);
                //if (TempData["RegistrationError"] != null)
                //{
                //    ViewBag.Error = TempData["RegistrationError"];
                //}
                return View(item);
            }
            else
            {
                return RedirectToAccountDetails();
            }
        }
        public IActionResult Login(int id)
        {
            if (!CheckIfUserIsLoggedIn())
            {
                SetViewBags();
                GetInputs(id);
                ViewBag.PageButtons = _pages.Where(x => x.IdPage == id || x.IdPage == id + 1).ToList();
                var item = _context.Page.Find(id);

                return View(item);
            }
            else
            {
                return RedirectToAccountDetails();
            }

        }
        public IActionResult ChangePassword(int id)
        {
            SetViewBags();
            if (CheckIfUserIsLoggedIn())
            {
                GetInputs(id);
                var item = _context.Accounts.Find(id);

                return View(item);
            }
            else
            {
                return RedirectToLogin();
            }
        }
        public IActionResult RateProduct(int id)
        {
            SetViewBags();
            if (CheckIfUserIsLoggedIn())
            {
                ViewBag.PozytywnaOcena = _context.Rates.Where(x => x.Rating == "Pozytywna").First().IdRate;
                ViewBag.NegatywnaOcena = _context.Rates.Where(x => x.Rating == "Negatywna").First().IdRate;
                var isAlreadyRated = _context.RatesProductsAccounts
                    .Where(x => x.IdProduct == id)
                    .Where(x => x.IsActive == true)
                    .Where(x => x.IdAccount == _accountB.GetUserId())
                    .Include(x => x.Rate)
                    .Include(x => x.Product)
                    .Include(x => x.Comment)
                    .Include(x => x.Product.Image);
                if (isAlreadyRated == null || isAlreadyRated.Count() == 0)
                {
                    var newItem = new RatesProductsAccounts()
                    {
                        IdProduct = id,
                        Product = _context.Products.Include(p => p.Image).FirstOrDefault(p => p.IdProduct == id)
                    };
                    return View(newItem);
                }
                return View(isAlreadyRated.First());
            }
            else
            {
                return RedirectToLogin();
            }
        }
        public IActionResult Orders(int id)
        {
            SetViewBags();
            if (CheckIfUserIsLoggedIn())
            {
                return View(_context.Order.Where(x => x.IdAccount == id).Include(x => x.OrderElements));
            }
            else
            {
                return RedirectToLogin();
            }
        }
        public IActionResult OrderDetails(int id)
        {
            SetViewBags();
            if (CheckIfUserIsLoggedIn())
            {
                return View(_context.OrderElement.Where(x => x.IdOrder == id).Include(x => x.Product).Include(x => x.Product.Image));
            }
            else
            {
                return RedirectToLogin();
            }
        }
        #endregion
        #region Funkcje
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AccountEdit(int id, [Bind("IdAccount,UserName,PhoneNumber,Email,FirstName,LastName")] Accounts account)
        {
            if (id != account.IdAccount)
            {
                return NotFound();
            }
            ModelState.Remove("RatesProductsAccounts");
            ModelState.Remove("AccountType");
            ModelState.Remove("Orders");
            ModelState.Remove("Password");
            ModelState.Remove("CreatedDate");
            ModelState.Remove("IsActive");
            ModelState.Remove("IdAccountType");
            if (ModelState.IsValid)
            {
                var itemToEdit = _context.Accounts.Find(id);
                itemToEdit.PhoneNumber = account.PhoneNumber;
                itemToEdit.Email = account.Email;
                itemToEdit.FirstName = account.FirstName;
                itemToEdit.LastName = account.LastName;
                _context.Update(itemToEdit);
                await _context.SaveChangesAsync();
                return RedirectToAccountDetails();
            }

            return RedirectToLogin();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(int id, string OldPassword, [Bind("IdAccount, Password")] Accounts account)
        {
            if (id != account.IdAccount)
            {
                return NotFound();
            }
            ModelState.Remove("RatesProductsAccounts");
            ModelState.Remove("AccountType");
            ModelState.Remove("Orders");
            ModelState.Remove("CreatedDate");
            ModelState.Remove("IsActive");
            ModelState.Remove("IdAccountType");
            ModelState.Remove("UserName");
            ModelState.Remove("PhoneNumber");
            ModelState.Remove("Email");
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            if (ModelState.IsValid)
            {
                var itemToEdit = _context.Accounts.Find(id);
                if (itemToEdit.Password == OldPassword)
                {
                    itemToEdit.Password = account.Password;
                    _context.Update(itemToEdit);
                    await _context.SaveChangesAsync();
                    return RedirectToAccountDetails();
                }
                else
                {
                    return RedirectToAction("ChangePassword", new { id = account.IdAccount });
                }
            }

            return RedirectToLogin();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountB.LoginUser(username, password);

                switch (result)
                {
                    case LoginResult.Success:
                        return RedirectToRegister();
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

            return RedirectToLogin();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string username, string password, string email, string firstName, string lastName, string phoneNumber)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountB.RegisterUser(username, password, email, firstName, lastName, phoneNumber);

                switch (result)
                {
                    case RegistrationResult.Success:
                        return RedirectToLogin();
                    case RegistrationResult.UserNameTaken:
                        TempData["UserNameError"] = "Nazwa użytkownika jest już zajęta.";
                        break;
                    case RegistrationResult.EmailTaken:
                        TempData["EmailError"] = "Adres e-mail jest już zajęty.";
                        break;
                    case RegistrationResult.Failure:
                        TempData["RegistrationError"] = "Wystąpił błąd podczas rejestracji.";
                        break;
                }
            }
            return RedirectToRegister();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RateProduct(int id, string comment, int[] rate, int IdRatesProductsAccounts)
        {
            SetViewBags();
            //Sprawdzanie czy dodajemy czy edytujemy ocene
            if (IdRatesProductsAccounts == 0)
            {
                if (comment == null && rate.Count() == 0)
                {
                    ViewBag.PozytywnaOcena = _context.Rates.Where(x => x.Rating == "Pozytywna").First().IdRate;
                    ViewBag.NegatywnaOcena = _context.Rates.Where(x => x.Rating == "Negatywna").First().IdRate;
                    return View(_context.Products.Include(x => x.Image).FirstOrDefault(x => x.IdProduct == id));
                }
                else if (rate.Count() > 0)
                {
                    Comments newComment;
                    if (comment == null)
                    {
                        comment = "";
                    }
                    newComment = new Comments()
                    {
                        CommentTitle = "Komentarz",
                        CommentContent = comment,
                    };
                    _context.Comments.Add(newComment);
                    await _context.SaveChangesAsync();
                    var newRate = new RatesProductsAccounts()
                    {
                        IdAccount = _accountB.GetUserId(),
                        IdProduct = id,
                        IdComment = newComment.IdComment,
                        IdRate = rate.First()
                    };
                    _context.RatesProductsAccounts.Add(newRate);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                var rateToEdit = _context.RatesProductsAccounts.Find(IdRatesProductsAccounts);
                rateToEdit.IdRate = rate.First();
                var commentToEdit = _context.Comments.Find(rateToEdit.IdComment);
                commentToEdit.CommentContent = comment != null ? comment : "";
                _context.Update(rateToEdit);
                _context.Update(commentToEdit);
                await _context.SaveChangesAsync();
            }
            return RedirectToAccountDetails();
        }

        public async Task<RedirectToActionResult> Logout()
        {
            await _accountB.LogoutUser();
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Redirect to Login page
        /// </summary>
        /// <returns>RedirectToActionResult</returns>
        private RedirectToActionResult RedirectToLogin()
        {
            var loginPage = _context.Page.FirstOrDefault(x => x.Title == "Login");
            return RedirectToAction("Login", new { id = loginPage.IdPage });
        }
        /// <summary>
        /// Redirect to Register page
        /// </summary>
        /// <returns>RedirectToActionResult</returns>
        private RedirectToActionResult RedirectToRegister()
        {
            var registerPage = _context.Page.FirstOrDefault(x => x.Title == "Register");
            return RedirectToAction("Register", new { id = registerPage.IdPage });
        }
        /// <summary>
        /// Redirect to AccountDetails page
        /// </summary>
        /// <returns>RedirectToActionResult</returns>
        private RedirectToActionResult RedirectToAccountDetails()
        {
            return RedirectToAction("AccountDetails", new { id = _accountB.GetUserId() });
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
