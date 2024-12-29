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

namespace TheWorldOfRecipes.Pages.RatingsAndComments
{
    public class EditModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public EditModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
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

            var ratingandcomment =  await _context.RatingAndComments.FirstOrDefaultAsync(m => m.RatingAndCommentID == id);
            if (ratingandcomment == null)
            {
                return NotFound();
            }
            RatingAndComment = ratingandcomment;
           ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
           ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
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

            return RedirectToPage("./Index");
        }

        private bool RatingAndCommentExists(int id)
        {
            return _context.RatingAndComments.Any(e => e.RatingAndCommentID == id);
        }
    }
}
