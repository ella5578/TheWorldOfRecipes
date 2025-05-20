using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;


namespace TheWorldOfRecipes.Pages.RecipeIngredients
{
    public class DetailsModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public DetailsModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

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
    }
}
