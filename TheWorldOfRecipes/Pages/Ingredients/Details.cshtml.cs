using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;


namespace TheWorldOfRecipes.Pages.Ingredients
{
    public class DetailsModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public DetailsModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public Ingredient Ingredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(m => m.IngredientID == id);

            if (ingredient is not null)
            {
                Ingredient = ingredient;

                return Page();
            }

            return NotFound();
        }
    }
}
