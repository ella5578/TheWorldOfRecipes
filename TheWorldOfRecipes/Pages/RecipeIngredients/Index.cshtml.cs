using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheWorldOfRecipes.Data;
using TheWorldOfRecipes.Models;

namespace TheWorldOfRecipes.Pages.RecipeIngredients
{
    public class IndexModel : PageModel
    {
        private readonly TheWorldOfRecipes.Data.TheWorldOfRecipesContext _context;

        public IndexModel(TheWorldOfRecipes.Data.TheWorldOfRecipesContext context)
        {
            _context = context;
        }

        public IList<RecipeIngredient> RecipeIngredient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RecipeIngredient = await _context.RecipeIngredients
                .Include(r => r.Ingredient)
                .Include(r => r.Recipe).ToListAsync();
        }
    }
}
