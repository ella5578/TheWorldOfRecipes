using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;

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
               new User{UserName="Carson",Password="Alexander",Email="user@gmail.com", IsAdmin=false,FirstName="Carson",LastName="Alexander",RegistrationDate=DateTime.Parse("2019-09-01")},
               new User{UserName="Meredith",Password="Alonso",Email="user@gmail.com", IsAdmin=false, FirstName="merdith", LastName="ggg"},
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var categories = new Category[]
            {
               new Category { CategoryName = "קינוחים", ImageUrl = "desserts.jpg" },
               new Category { CategoryName = "מנות עיקריות", ImageUrl="maindishes.jpg"},
               new Category { CategoryName = "ארוחות בוקר", ImageUrl = "breakfast.jpg" },
               new Category { CategoryName = "סלטים", ImageUrl = "salad.jpg" },
               new Category { CategoryName = "ארוחות צהריים", ImageUrl = "lunch.jpg" },
               new Category { CategoryName = "מאפים", ImageUrl="bread.jpg"  }
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var recipes = new Recipe[]
                {
                new Recipe
                {
                    RecipeName = "Apple Pie",
                    Description = "pie",
                    CategoryID = 1,
                    Category = categories.First(c => c.CategoryID == 1),
                    TimerMinutes = 60,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/KbyahTnzbKA?si=KRYAchT3Bd8e8my-"
                },
                new Recipe
                {
                    RecipeName = "Chocolate Cake",
                    Description = "cake",
                    CategoryID = 1,
                    Category = categories.First(c => c.CategoryID == 1),
                    TimerMinutes = 30,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/EBAE91Os2VA?si=m7bn3GyeGy7t_-9B"
                },
                new Recipe
                {
                    RecipeName = "Chocolate Chip Cookie",
                    Description = "cookie",
                    CategoryID = 1,
                    Category = categories.First(c => c.CategoryID == 1),
                    TimerMinutes = 20,
                    LikesCount = 0,
                    VideoURL = null
                },
                new Recipe
                {
                    RecipeName = "Tomato Soup",
                    Description = "soup",
                    CategoryID = 2,
                    Category = categories.First(c => c.CategoryID == 2),
                    TimerMinutes = 25,
                    LikesCount = 0,
                    VideoURL = null
                },
                new Recipe
                {
                    RecipeName = "Trigonometry Pie",
                    Description = "Trigonometry",
                    CategoryID = 3,
                    Category = categories.First(c => c.CategoryID == 3),
                    TimerMinutes = 45,
                    LikesCount = 0,
                    VideoURL = null
                }
                };


            context.Recipes.AddRange(recipes);
            context.SaveChanges();

            var ratingsandcomments = new RatingAndComment[]
            {
               new RatingAndComment{UserID=1,RecipeID=1,Rating=5},
               new RatingAndComment{UserID=1,RecipeID=2,Rating=4},
               new RatingAndComment{UserID=2,RecipeID=3,Rating=3}
            };

            context.RatingAndComments.AddRange(ratingsandcomments);
            context.SaveChanges();

            context.Database.EnsureCreated();

            //// בדיקה אם כבר יש קטגוריות  
            //if (context.Categories.Any())  
            //{  
            //    return; // אם כבר יש נתונים, לא מוסיפים שוב  
            //}  

            var ingredients = new Ingredient[]
            {
               new Ingredient{/*IngredientID = 1, */IngredientName = "ביצים"},
               new Ingredient{/*IngredientID = 2, */IngredientName = "חלב"},
               new Ingredient{/*IngredientID = 3,*/ IngredientName = "קמח"},
               new Ingredient{/*IngredientID = 4,*/ IngredientName = "שוקולד"},
               new Ingredient{/*IngredientID = 5,*/ IngredientName = "סוכר"},
               new Ingredient{/*IngredientID = 6,*/ IngredientName = "תפוזים"},
               new Ingredient{/*IngredientID = 7,*/ IngredientName = "בשר טחון"},
               new Ingredient{/*IngredientID = 8,*/ IngredientName = "חזה עוף"},
               new Ingredient{/*IngredientID = 9,*/ IngredientName = "אורז"},
               new Ingredient{/*IngredientID = 10,*/ IngredientName = "פסטה"},
               new Ingredient{/*IngredientID = 11,*/ IngredientName = "רסק עגבניות"},
               new Ingredient{/*IngredientID = 12,*/ IngredientName = "שמנת מתוקה"},
               new Ingredient{/*IngredientID = 13,*/ IngredientName = "מלח"},
               new Ingredient{/*IngredientID = 14,*/ IngredientName = "פטריות"},
               new Ingredient{/*IngredientID = 15,*/ IngredientName = "בצל"}
            };

            // הוספת המרכיבים לבסיס הנתונים  
            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();


            var recipeIngredients = new RecipeIngredient[]
            {  
                   // Recipe 1: Chocolate Cake  
                   new RecipeIngredient
                   {
                       RecipeID = 1,
                       IngredientID = 3,
                       Quantity = 200,
                       Units = "grams",
                       Recipe = recipes.First(r => r.RecipeID == 1),
                       Ingredient = ingredients.First(i => i.IngredientID == 3)
                   },
                   new RecipeIngredient
                   {
                       RecipeID = 1,
                       IngredientID = 5,
                       Quantity = 100,
                       Units = "grams",
                       Recipe = recipes.First(r => r.RecipeID == 1),
                       Ingredient = ingredients.First(i => i.IngredientID == 5)
                   },
                   new RecipeIngredient
                   {
                       RecipeID = 1,
                       IngredientID = 1,
                       Quantity = 2,
                       Units = "eggs",
                       Recipe = recipes.First(r => r.RecipeID == 1),
                       Ingredient = ingredients.First(i => i.IngredientID == 1)
                   },
                   new RecipeIngredient
                   {
                       RecipeID = 1,
                       IngredientID = 4,
                       Quantity = 1,
                       Units = "cup",
                       Recipe = recipes.First(r => r.RecipeID == 1),
                       Ingredient = ingredients.First(i => i.IngredientID == 4)
                   },
                   new RecipeIngredient
                   {
                       RecipeID = 1,
                       IngredientID = 2,
                       Quantity = 1,
                       Units = "tsp",
                       Recipe = recipes.First(r => r.RecipeID == 1),
                       Ingredient = ingredients.First(i => i.IngredientID == 2)
                   }
            };

            context.RecipeIngredients.AddRange(recipeIngredients);
            context.SaveChanges();
        }
    }
}