using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWorldOfRecipes.Data;
using TheWorldOfRecipes.Models;

namespace TheWorldOfRecipes.Pages.RatingsAndComments
{
    public class DetailsModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public DetailsModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
        {
            _context = context;
        }

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
    }
}
