using EllaRecipes.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Data;




namespace TheWorldOfRecipes.Pages.RecipeIngredients
{
    public class DeleteModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public DeleteModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeIngredient RecipeIngredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeingredient = await _context.RecipeIngredients.FirstOrDefaultAsync(m => m.RecipeIngredientID == id);

            if (recipeingredient is not null)
            {
                RecipeIngredient = recipeingredient;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeingredient = await _context.RecipeIngredients.FindAsync(id);
            if (recipeingredient != null)
            {
                RecipeIngredient = recipeingredient;
                _context.RecipeIngredients.Remove(RecipeIngredient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
