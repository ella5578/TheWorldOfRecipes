using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace TheWorldOfRecipes.Pages.RecipeIngredients
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
        ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID");
        ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
            return Page();
        }

        [BindProperty]
        public RecipeIngredient RecipeIngredient { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecipeIngredients.Add(RecipeIngredient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
