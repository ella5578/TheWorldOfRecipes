using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheWorldOfRecipes.Data;
using TheWorldOfRecipes.Models;

namespace TheWorldOfRecipes.Pages.RecipeIngredients
{
    public class CreateModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public CreateModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
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
