using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheWorldOfRecipes.Models;

namespace TheWorldOfRecipes.Data
{
    public class TheWorldOfRecipesContext : DbContext
    {
        public TheWorldOfRecipesContext (DbContextOptions<TheWorldOfRecipesContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RatingAndComment> RatingAndComments { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<RatingAndComment>().ToTable("RatingAndComment");
            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbSet<TheWorldOfRecipes.Models.User> User { get; set; } = default!;
    }
}
