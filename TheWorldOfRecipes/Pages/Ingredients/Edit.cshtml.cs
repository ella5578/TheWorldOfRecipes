using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;

namespace TheWorldOfRecipes.Pages.Ingredients
{
    public class EditModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public EditModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient =  await _context.Ingredients.FirstOrDefaultAsync(m => m.IngredientID == id);
            if (ingredient == null)
            {
                return NotFound();
            }
            Ingredient = ingredient;
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

            _context.Attach(Ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(Ingredient.IngredientID))
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

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientID == id);
        }
    }
}
