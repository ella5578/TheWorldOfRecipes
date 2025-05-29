using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;



namespace TheWorldOfRecipes.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public DetailsModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; } = default!;

        public IList<(string IngredientName, int Quantity, string Units)> Ingredients { get; set; } = new List<(string, int, string)>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (recipe is not null)
            {
                Recipe = recipe;

                Ingredients = await _context.RecipeIngredients
                    .Where(ri => ri.RecipeID == id)
                    .Join(_context.Ingredients,
                          ri => ri.IngredientID,
                          i => i.IngredientID,
                          (ri, i) => new ValueTuple<string, int, string>(i.IngredientName, ri.Quantity, ri.Units))
                    .ToListAsync();

                return Page();
            }

            return NotFound();
        }
    }
}
