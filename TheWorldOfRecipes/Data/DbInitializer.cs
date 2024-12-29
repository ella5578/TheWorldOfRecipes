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

            var ratingsandcomments = new RatingAndComment[]
            {
                new RatingAndComment{UserID=1,RecipeID=1050,Rating=5},
                new RatingAndComment{UserID=1,RecipeID=4022,Rating=4},
                new RatingAndComment{UserID=1,RecipeID=4041,Rating=3}
            };

            context.RatingAndComments.AddRange(ratingsandcomments);
            context.SaveChanges();

            context.Database.EnsureCreated();

            // בדיקה אם כבר יש קטגוריות
            if (context.Categories.Any())
            {
                return; // אם כבר יש נתונים, לא מוסיפים שוב
            }

            var categories = new Category[]
            {
                new Category { CategoryName = "קינוחים" },
                new Category { CategoryName = "מנות עיקריות" },
                new Category { CategoryName = "ארוחות בוקר" },
                new Category { CategoryName = "סלטים" },
                new Category { CategoryName = "ארוחות צהריים" },
                new Category { CategoryName = "צמחונים" },
                new Category { CategoryName = "מאכלים דיאטטים" }

            };
            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var ingredients = new Ingredient[]
            {
                new Ingredient{IngredientID = 1, IngredientName = "ביצים"},
                new Ingredient{IngredientID = 2, IngredientName = "חלב"},
                new Ingredient{IngredientID = 3, IngredientName = "קמח"},
                new Ingredient{IngredientID = 4, IngredientName = "שוקולד"},
                new Ingredient{IngredientID = 5, IngredientName = "סוכר"},
                new Ingredient{IngredientID = 6, IngredientName = "תפוזים"},
                new Ingredient{IngredientID = 7, IngredientName = "בשר טחון"},
                new Ingredient{IngredientID = 8, IngredientName = "חזה עוף"},
                new Ingredient{IngredientID = 9, IngredientName = "אורז"},
                new Ingredient{IngredientID = 10, IngredientName = "פסטה"},
                new Ingredient{IngredientID = 11, IngredientName = "רסק עגבניות"},
                new Ingredient{IngredientID = 12, IngredientName = "שמנת מתוקה"},
                new Ingredient{IngredientID = 13, IngredientName = "מלח"},
                new Ingredient{IngredientID = 14, IngredientName = "פטריות"},
                new Ingredient{IngredientID = 15, IngredientName = "בצל"}
            };

            // הוספת המרכיבים לבסיס הנתונים
            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();


            var recipeIngredients = new RecipeIngredient[]
             {
                // מתכון 1: עוגה שוקולד
                new RecipeIngredient { RecipeID = 1, IngredientID = 3, Quantity = 200, Units = "grams" },   // קמח
                new RecipeIngredient { RecipeID = 1, IngredientID = 5, Quantity = 100, Units = "grams" },   // סוכר
                new RecipeIngredient { RecipeID = 1, IngredientID = 1, Quantity = 2, Units = "eggs" },      // ביצים
                new RecipeIngredient { RecipeID = 1, IngredientID = 4, Quantity = 1, Units = "cup" },        // שוקולד
                new RecipeIngredient { RecipeID = 1, IngredientID = 2, Quantity = 1, Units = "tsp" },        // קינמון

                // מתכון 2: סלט ירקות
                new RecipeIngredient { RecipeID = 2, IngredientID = 6, Quantity = 1, Units = "cup" },        // מלפפון
                new RecipeIngredient { RecipeID = 2, IngredientID = 7, Quantity = 1, Units = "cup" },        // עגבניה
                new RecipeIngredient { RecipeID = 2, IngredientID = 13, Quantity = 2, Units = "tsp" },       // מלח
                new RecipeIngredient { RecipeID = 2, IngredientID = 12, Quantity = 3, Units = "tsp" },       // שמן זית
                new RecipeIngredient { RecipeID = 2, IngredientID = 11, Quantity = 1, Units = "tbsp" },      // חומץ

                // מתכון 3: חומוס
                new RecipeIngredient { RecipeID = 3, IngredientID = 9, Quantity = 300, Units = "grams" },    // חומוס יבש
                new RecipeIngredient { RecipeID = 3, IngredientID = 8, Quantity = 3, Units = "tsp" },        // טחינה
                new RecipeIngredient { RecipeID = 3, IngredientID = 15, Quantity = 1, Units = "tsp" },       // שום כתוש
                new RecipeIngredient { RecipeID = 3, IngredientID = 6, Quantity = 2, Units = "tbsp" },       // לימון סחוט
                new RecipeIngredient { RecipeID = 3, IngredientID = 10, Quantity = 1, Units = "cup" },       // מים
             };

            // הוספת מרכיבי המתכונים לבסיס הנתונים
            context.RecipeIngredients.AddRange(recipeIngredients);
            context.SaveChanges();


        }
    }
}
