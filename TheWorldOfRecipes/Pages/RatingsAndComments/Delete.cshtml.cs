using EllaRecipes.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Data;



namespace TheWorldOfRecipes.Pages.RatingsAndComments
{
    public class DeleteModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public DeleteModel(TheWorldOfRecipesContext context)
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

            if (ratingandcomment is not null)
            {
                RatingAndComment = ratingandcomment;

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

            var ratingandcomment = await _context.RatingAndComments.FindAsync(id);
            if (ratingandcomment != null)
            {
                RatingAndComment = ratingandcomment;
                _context.RatingAndComments.Remove(RatingAndComment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
