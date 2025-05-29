using EllaRecipes.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EllaRecipes.Shared.Data

{
    public class TheWorldOfRecipesContext : DbContext
    {
        public TheWorldOfRecipesContext(DbContextOptions<TheWorldOfRecipesContext> options)
            : base(options)
        {
        }

        public TheWorldOfRecipesContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<RatingAndComment> RatingAndComments { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<EllaRecipes.Shared.Models.User> User { get; set; } = default!;
    }
}
