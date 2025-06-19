
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EllaRecipes.Shared.Models;
using EllaRecipes.Shared.Data;

namespace TheWorldOfRecipes.Pages.RatingsAndComments
{
    public class CreateModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public CreateModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RatingAndComment RatingAndComment { get; set; } = default!;

        // קבלת RecipeID מה-QueryString
        public IActionResult OnGet(int? recipeId)
        {
            if (recipeId == null)
            {
                return NotFound();
            }

            RatingAndComment = new RatingAndComment
            {
                RecipeID = recipeId.Value
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // שיוך אוטומטי של UserID (אם יש מערכת התחברות)
            // RatingAndComment.UserID = ...;

            _context.RatingAndComments.Add(RatingAndComment);
            await _context.SaveChangesAsync();

            // הפנייה חזרה לדף פרטי המתכון
            return RedirectToPage("/Recipes/Details", new { id = RatingAndComment.RecipeID });
        }
    }
}

