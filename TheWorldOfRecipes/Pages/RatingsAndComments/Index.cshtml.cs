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
    public class IndexModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public IndexModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public IList<RatingAndComment> RatingAndComment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RatingAndComment = await _context.RatingAndComments
                .Include(r => r.Recipe)
                .Include(r => r.User).ToListAsync();
        }
    }
}
