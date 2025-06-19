using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using EllaRecipes.Shared.Data;

namespace TheWorldOfRecipes.Pages.Auth
{
    public class DeleteAccountModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public DeleteAccountModel(TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                int userId = int.Parse(userIdClaim.Value);

                var user = await _context.Users
                    .Include(u => u.RatingsAndComments)
                    .FirstOrDefaultAsync(u => u.UserID == userId);

                if (user != null)
                {
                    if (user.RatingsAndComments != null)
                    {
                        _context.RatingAndComments.RemoveRange(user.RatingsAndComments);
                    }
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}
