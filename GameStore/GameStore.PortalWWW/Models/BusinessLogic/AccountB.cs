using GameStore.Data.Data;
using GameStore.Data.Data.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace GameStore.PortalWWW.Models.BusinessLogic
{
    public class AccountB
    {
        private readonly GameStoreContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountB(GameStoreContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        #region Podstawowe funkcje
        public async Task<RegistrationResult> RegisterUser(string username, string password, string email, string firstName, string lastName, string phoneNumber)
        {
            if (await IsUsernameTaken(username))
            {
                return RegistrationResult.UserNameTaken;
            }
            if (await IsEmailTaken(email))
            {
                return RegistrationResult.EmailTaken;
            }

            var user = new Accounts { UserName = username, Password = password, Email = email, FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, IsActive = true, CreatedDate = DateTime.Now, IdAccountType = _context.AccountType.Where(x => x.Name == "User").Select(x => x.IdAccountType).FirstOrDefault() };

            _context.Accounts.Add(user);
            await _context.SaveChangesAsync();

            return RegistrationResult.Success;
        }

        public async Task<LoginResult> LoginUser(string username, string password)
        {
            if (!await IsUsernameValid(username))
            {
                return LoginResult.UsernameValid;
            }
            if (!await IsPasswordValid(password, username))
            {
                return LoginResult.PasswordValid;
            }

            SetAuthenticationCookie(username);


            return LoginResult.Success;
        }

        private void SetAuthenticationCookie(string username)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("AuthCookie", username, cookieOptions);
        }

        /// <summary>
        /// Returns Id of logged user, if user is not logged in then returns -1
        /// </summary>
        /// <returns>Int</returns>
        public int GetUserId()
        {
            var authCookie = _httpContextAccessor.HttpContext.Request.Cookies["AuthCookie"];
            if (!string.IsNullOrEmpty(authCookie))
            {
                return _context.Accounts.FirstOrDefault(x => x.UserName == authCookie).IdAccount;
            }
            return -1;
        }

        public async Task LogoutUser()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("AuthCookie");
        }
        #endregion
        #region Funckje sprawdzajace poprawnosc danych
        /// <summary>
        /// Checks if username is already used
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _context.Accounts.AnyAsync(x => x.UserName == username);
        }
        /// <summary>
        /// Checks if email is already used
        /// </summary>
        /// <param name="email"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsEmailTaken(string email)
        {
            return await _context.Accounts.AnyAsync(x => x.Email == email);
        }
        /// <summary>
        /// Checks if username is valid
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsUsernameValid(string username)
        {
            return await _context.Accounts.AnyAsync(x => x.UserName == username);
        }
        /// <summary>
        /// Checks if password is valid
        /// </summary>
        /// <param name="password"></param>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        public async Task<bool> IsPasswordValid(string password, string username)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(x => x.UserName == username);
            if (user != null)
            {
                return user.Password == password;
            }
            return false;
        }

        #endregion

        public enum RegistrationResult
        {
            Success,
            UserNameTaken,
            EmailTaken,
            Failure
        }
        public enum LoginResult
        {
            Success,
            UsernameValid,
            PasswordValid,
            Failure
        }
    }
}
