using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;


namespace TheWorldOfRecipes.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public IndexModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        [BindProperty(SupportsGet =true)]
        public int? SelectedCategoryId { get; set; }


        public async Task OnGetAsync()
        {
            if (SelectedCategoryId.HasValue)
            {
                Recipe = await _context.Recipes
                    .Where(r=>r.CategoryID== SelectedCategoryId)
                    .Include(r=>r.Category)
                    .ToListAsync();    
                   
                    
            }
            else
            {
                Recipe = await _context.Recipes
                               .Include(r => r.Category).ToListAsync();
            }

           
        }
    }
}
