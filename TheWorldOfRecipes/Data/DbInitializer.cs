using TheWorldOfRecipes.Models;
using System.Diagnostics;

namespace TheWorldOfRecipes.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TheWorldOfRecipesContext context)
        {
            // Look for any Users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Username="Carson",Password="Alexander",Email="user@gmail.com", IsAdmin=false,FirstName="Carson",LastName="Alexander",RegistrationDate=DateTime.Parse("2019-09-01")},
                new User{Username="Meredith",Password="Alonso",Email="user@gmail.com", IsAdmin=false, FirstName="merdith", LastName="ggg"},
               
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var recipes = new Recipe[]
            {
                new Recipe{RecipeID=1050,Description="pie"},
                new Recipe{RecipeID=4022,Description="cake"},
                new Recipe{RecipeID=4041,Description="cookie"},
                new Recipe{RecipeID=1045,Description="soup"},
                new Recipe{RecipeID=3141,Description="Trigonometry"}
                
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();

            var enrollments = new RatingAndComment[]
            {
                new RatingAndComment{UserID=1,RecipeID=1050,Rating=5},
                new RatingAndComment{UserID=1,RecipeID=4022,Rating=4},
                new RatingAndComment{UserID=1,RecipeID=4041,Rating=3}
            };

            context.RatingAndComments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
