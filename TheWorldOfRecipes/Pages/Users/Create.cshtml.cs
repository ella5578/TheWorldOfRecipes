using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheWorldOfRecipes.Data;
using TheWorldOfRecipes.Models;
using System;
using System.Threading.Tasks;

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
            var emptyUser = new User();

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                u => u.FirstName, u => u.LastName, u => u.RegistrationDate, u=>u.Email, 
                u=>u.IsAdmin, u=>u.Username, u =>u.Password))
            {
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

        }
    }

}
