using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWorldOfRecipes.Data;
using TheWorldOfRecipes.Models;

namespace TheWorldOfRecipes.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public DetailsModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // חיפוש המשתמש כולל כל השדות החדשים ונתוני RatingsAndComments
            User = await _context.Users
                .Include(u => u.RatingsAndComments) // טעינת הקשרים
                .ThenInclude(rc => rc.Recipe) // טעינת פרטי המתכון
                .AsNoTracking() // הבטחת קריאה בלבד ללא מעקב אחר שינויים
                .FirstOrDefaultAsync(u => u.UserID == id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
