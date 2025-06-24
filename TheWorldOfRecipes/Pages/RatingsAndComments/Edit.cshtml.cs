using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TheWorldOfRecipes.Pages.RatingsAndComments
{
    public class EditModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public EditModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RatingAndComment RatingAndComment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingandcomment = await _context.RatingAndComments.FirstOrDefaultAsync(m => m.RatingAndCommentID == id);
            if (ratingandcomment == null)
            {
                return NotFound();
            }
            RatingAndComment = ratingandcomment;
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // שליפת הדירוג הקודם מה-DB
            var original = await _context.RatingAndComments
                .AsNoTracking()
                .FirstOrDefaultAsync(rc => rc.RatingAndCommentID == RatingAndComment.RatingAndCommentID);

            if (original == null)
                return NotFound();

            var recipe = await _context.Recipes.FindAsync(RatingAndComment.RecipeID);

            // בדיקת שינוי דירוג והשפעה על LikesCount
            if (recipe != null)
            {
                bool wasLike = original.Rating == 5;
                bool isLike = RatingAndComment.Rating == 5;

                if (!wasLike && isLike)
                {
                    recipe.LikesCount++;
                }
                else if (wasLike && !isLike && recipe.LikesCount > 0)
                {
                    recipe.LikesCount--;
                }
            }

            _context.Attach(RatingAndComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingAndCommentExists(RatingAndComment.RatingAndCommentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // הפניה לדף פרטי המתכון
            return RedirectToPage("/Recipes/Details", new { id = RatingAndComment.RecipeID });
        }


        private bool RatingAndCommentExists(int id)
        {
            return _context.RatingAndComments.Any(e => e.RatingAndCommentID == id);
        }
    }
}
