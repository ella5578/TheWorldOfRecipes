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

        public async Task<IActionResult> OnPostAsync()
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

            try
            {
                if (!BCrypt.Net.BCrypt.Verify(Password, user.Password))
                {
                    ErrorMessage = "Invalid username or password.";
                    return Page();
                }
            }
            catch (BCrypt.Net.SaltParseException)
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }

            var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.Name, user.UserName)
               };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("/Index");
        }
    }
}
