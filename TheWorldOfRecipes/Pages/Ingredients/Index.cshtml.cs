using EllaRecipes.Shared.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using EllaRecipes.Shared.Data;





namespace TheWorldOfRecipes.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public IndexModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public IList<Ingredient> Ingredient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredients.ToListAsync();
        }
    }
}
