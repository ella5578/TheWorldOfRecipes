using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;



namespace TheWorldOfRecipes.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public CreateModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
