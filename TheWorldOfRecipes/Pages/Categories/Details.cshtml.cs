using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;


namespace TheWorldOfRecipes.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public DetailsModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryID == id);

            if (category is not null)
            {
                Category = category;

                return Page();
            }

            return NotFound();
        }
    }
}
