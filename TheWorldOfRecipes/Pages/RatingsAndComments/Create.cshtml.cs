using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

            // קבלת שם המשתמש מה־Claims
            var userName = User.Identity?.Name;

            // בדיקה שהמשתמש מחובר
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/Auth/Login");
            }

            // שליפת ה־UserID מהמסד לפי שם המשתמש
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "משתמש לא נמצא");
                return Page();
            }

            RatingAndComment.UserID = user.UserID;
            _context.RatingAndComments.Add(RatingAndComment);

            // הגדלת LikesCount אם הדירוג הוא 5
            if (RatingAndComment.Rating == 5)
            {
                var recipe = await _context.Recipes.FindAsync(RatingAndComment.RecipeID);
                if (recipe != null)
                {
                    recipe.LikesCount++;
                }
            }

            await _context.SaveChangesAsync();

            // הפנייה חזרה לדף פרטי המתכון
            return RedirectToPage("/Recipes/Details", new { id = RatingAndComment.RecipeID });
        }
    }
}
