using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace TheWorldOfRecipes.Pages.RatingsAndComments
{
    public class IndexModel : PageModel
    {
        private readonly TheWorldOfRecipesContext _context;

        public IndexModel(TheWorldOfRecipesContext context)
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
