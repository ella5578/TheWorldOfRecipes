using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheWorldOfRecipes.Data;
using TheWorldOfRecipes.Models;

namespace TheWorldOfRecipes.Pages.RecipeIngredients
{
    public class EditModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public EditModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
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

            var recipeingredient =  await _context.RecipeIngredients.FirstOrDefaultAsync(m => m.RecipeIngredientID == id);
            if (recipeingredient == null)
            {
                return NotFound();
            }
            RecipeIngredient = recipeingredient;
           ViewData["IngredientID"] = new SelectList(_context.Ingredients, "IngredientID", "IngredientID");
           ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RecipeIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(RecipeIngredient.RecipeIngredientID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RecipeIngredientExists(int id)
        {
            return _context.RecipeIngredients.Any(e => e.RecipeIngredientID == id);
        }
    }
}
