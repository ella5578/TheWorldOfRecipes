using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWorldOfRecipes.Data;
using TheWorldOfRecipes.Models;

namespace TheWorldOfRecipes.Pages.RecipeIngredients
{
    public class DeleteModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public DeleteModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
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
