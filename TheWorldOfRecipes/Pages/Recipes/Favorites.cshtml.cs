using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EllaRecipes.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using EllaRecipes.Shared.Data;


namespace TheWorldOfRecipes.Pages.Recipes
{
    public class FavoritesModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public FavoritesModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public List<Recipe> FavoriteRecipes { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("/Auth/Login");

            var userName = User.Identity.Name;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            if (user == null)
                return RedirectToPage("/Auth/Login");

            FavoriteRecipes = await _context.RatingAndComments
                .Where(rc => rc.UserID == user.UserID && rc.Rating == 5)
                .Include(rc => rc.Recipe)
                .Select(rc => rc.Recipe)
                .Distinct()
                .ToListAsync();

            return Page();
        }
    }
}
