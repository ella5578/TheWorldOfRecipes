using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;


namespace TheWorldOfRecipes.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public CreateModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public new User User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // כששולחים את הטופס, שומרים את המידע למסד נתונים  
        public async Task<IActionResult> OnPostAsync()
        {
            // Initialize required properties to avoid CS9035 errors  
            User emptyUser = new User
            {
                Email = string.Empty,
                UserName = string.Empty,
                PasswordHash = string.Empty,
                PasswordSalt = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty
            };

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.  
                u => u.FirstName, u => u.LastName, u => u.RegistrationDate, u => u.Email,
                u => u.IsAdmin, u => u.UserName, u => u.Password))
            {
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }

}
