using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;


namespace TheWorldOfRecipes.Pages.RecipeIngredients
{
    public class IndexModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public IndexModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public IList<RecipeIngredient> RecipeIngredient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RecipeIngredient = await _context.RecipeIngredients
                .Include(r => r.Ingredient)
                .Include(r => r.Recipe).ToListAsync();
        }
    }
}
