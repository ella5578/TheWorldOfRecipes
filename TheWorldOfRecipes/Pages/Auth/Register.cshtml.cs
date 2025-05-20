using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;



using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TheWorldOfRecipes.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public RegisterModel(TheWorldOfRecipesContext context)
        {
            _context = context;  /*קו תחתון - פרטי*/
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public DateTime RegistrationDate { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                ErrorMessage = "Please fill in all fields.";
                return Page();
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == UserName);
            if (existingUser != null)
            {
                ErrorMessage = "Username already exists.";
                return Page();
            }

            var user = new User
            {
                UserName = UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(Password),
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,

                RegistrationDate = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Auth/Login");
        }
    }
}