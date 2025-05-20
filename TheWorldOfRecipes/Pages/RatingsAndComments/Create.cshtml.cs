using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult OnGet()
        {
        ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
        ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Email");
            return Page();
        }

        [BindProperty]
        public RatingAndComment RatingAndComment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RatingAndComments.Add(RatingAndComment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
