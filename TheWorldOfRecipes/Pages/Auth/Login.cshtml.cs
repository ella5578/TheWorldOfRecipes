using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;



namespace TheWorldOfRecipes.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly EllaRecipes.Shared.Data.TheWorldOfRecipesContext _context;

        public LoginModel(EllaRecipes.Shared.Data.TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string RegistrationDate { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Please fill in all fields.";
                return Page();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == UserName);
            if (user == null)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            if (!ServiceLibrary.Helpers.PasswordHelper.VerifyPassword(Password, user.PasswordHash, user.PasswordSalt))
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString())
    };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            TempData["WelcomeUser"] = user.UserName;

            // אם לא הועבר returnUrl, הפנה לדף הבית
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToPage("/Index");
        }

    }
}
