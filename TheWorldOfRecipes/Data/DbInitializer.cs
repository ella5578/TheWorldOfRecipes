﻿using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;

namespace TheWorldOfRecipes.Data
{
    //public static class DbInitializer
    //{
    //    public static void Initialize(TheWorldOfRecipesContext context)
    //    {
    //        // Look for any Users.
    //        if (context.Users.Any())
    //        {
    //            return;   // DB has been seeded
    //        }

    //        var users = new User[]
    //        {
    //            new User{UserName="Carson",Password="Alexander",Email="user@gmail.com", IsAdmin=false,FirstName="Carson",LastName="Alexander",RegistrationDate=DateTime.Parse("2019-09-01")},
    //            new User{UserName="Meredith",Password="Alonso",Email="user@gmail.com", IsAdmin=false, FirstName="merdith", LastName="ggg"},
               
    //        };

    //        context.Users.AddRange(users);
    //        context.SaveChanges();


    //        var categories = new Category[]
    //        {
    //            new Category { CategoryName = "קינוחים", ImageUrl = "desserts.jpg" },
    //            new Category { CategoryName = "מנות עיקריות", ImageUrl="maindishes.jpg"},
    //            new Category { CategoryName = "ארוחות בוקר", ImageUrl = "breakfast.jpg" },
    //            new Category { CategoryName = "סלטים", ImageUrl = "salad.jpg" },
    //            new Category { CategoryName = "ארוחות צהריים", ImageUrl = "lunch.jpg" },
    //            new Category { CategoryName = "מאפים", ImageUrl="bread.jpg"  }
                

    //        };
    //        foreach (var category in categories)
    //        {
    //            context.Categories.Add(category);
    //        }
    //        context.SaveChanges();

    //        var recipes = new Recipe[]
    //        {
    //            new Recipe{RecipeName="Apple Pie", Description="pie", CategoryID = 1,
    //                TimerMinutes=60, VideoURL="KbyahTnzbKA?si=KRYAchT3Bd8e8my-"
    //                //"https://youtu.be/KbyahTnzbKA?si=kgAr_Dbzh30MW_7H"
    //            },
    //            new Recipe{Description="cake", CategoryID = 1, TimerMinutes=30, VideoURL="EBAE91Os2VA?si=m7bn3GyeGy7t_-9B"},
    //            new Recipe{Description="cookie", CategoryID = 1},
    //            new Recipe{Description="soup", CategoryID = 2},
    //            new Recipe{Description="Trigonometry", CategoryID = 3}
                
    //        };

    //        context.Recipes.AddRange(recipes);
    //        context.SaveChanges();

    //        var ratingsandcomments = new RatingAndComment[]
    //        {
    //            new RatingAndComment{UserID=1,RecipeID=1,Rating=5},
    //            new RatingAndComment{UserID=1,RecipeID=2,Rating=4},
    //            new RatingAndComment{UserID=2,RecipeID=3,Rating=3}
    //        };

    //        context.RatingAndComments.AddRange(ratingsandcomments);
    //        context.SaveChanges();

    //        context.Database.EnsureCreated();

    //        //// בדיקה אם כבר יש קטגוריות
    //        //if (context.Categories.Any())
    //        //{
    //        //    return; // אם כבר יש נתונים, לא מוסיפים שוב
    //        //}

    //        var ingredients = new Ingredient[]
    //        {
    //            new Ingredient{/*IngredientID = 1, */IngredientName = "ביצים"},
    //            new Ingredient{/*IngredientID = 2, */IngredientName = "חלב"},
    //            new Ingredient{/*IngredientID = 3,*/ IngredientName = "קמח"},
    //            new Ingredient{/*IngredientID = 4,*/ IngredientName = "שוקולד"},
    //            new Ingredient{/*IngredientID = 5,*/ IngredientName = "סוכר"},
    //            new Ingredient{/*IngredientID = 6,*/ IngredientName = "תפוזים"},
    //            new Ingredient{/*IngredientID = 7,*/ IngredientName = "בשר טחון"},
    //            new Ingredient{/*IngredientID = 8,*/ IngredientName = "חזה עוף"},
    //            new Ingredient{/*IngredientID = 9,*/ IngredientName = "אורז"},
    //            new Ingredient{/*IngredientID = 10,*/ IngredientName = "פסטה"},
    //            new Ingredient{/*IngredientID = 11,*/ IngredientName = "רסק עגבניות"},
    //            new Ingredient{/*IngredientID = 12,*/ IngredientName = "שמנת מתוקה"},
    //            new Ingredient{/*IngredientID = 13,*/ IngredientName = "מלח"},
    //            new Ingredient{/*IngredientID = 14,*/ IngredientName = "פטריות"},
    //            new Ingredient{/*IngredientID = 15,*/ IngredientName = "בצל"}
    //        };

    //        // הוספת המרכיבים לבסיס הנתונים
    //        context.Ingredients.AddRange(ingredients);
    //        context.SaveChanges();


    //        var recipeIngredients = new RecipeIngredient[]
    //        {  
    //           // מתכון 1: עוגה שוקולד  
    //           new RecipeIngredient { RecipeID = 1, IngredientID = 3, Quantity = 200, Units = "grams", Ingredient = ingredients[2], Recipe = recipes[0] },   // קמח  
    //           new RecipeIngredient { RecipeID = 1, IngredientID = 5, Quantity = 100, Units = "grams", Ingredient = ingredients[4], Recipe = recipes[0] },   // סוכר  
    //           new RecipeIngredient { RecipeID = 1, IngredientID = 1, Quantity = 2, Units = "eggs", Ingredient = ingredients[0], Recipe = recipes[0] },      // ביצים  
    //           new RecipeIngredient { RecipeID = 1, IngredientID = 4, Quantity = 1, Units = "cup", Ingredient = ingredients[3], Recipe = recipes[0] },        // שוקולד  
    //           new RecipeIngredient { RecipeID = 1, IngredientID = 2, Quantity = 1, Units = "tsp", Ingredient = ingredients[1], Recipe = recipes[0] },        // קינמון  

    //           // מתכון 2: סלט ירקות  
    //           new RecipeIngredient { RecipeID = 2, IngredientID = 6, Quantity = 1, Units = "cup", Ingredient = ingredients[5], Recipe = recipes[1] },        // מלפפון  
    //           new RecipeIngredient { RecipeID = 2, IngredientID = 7, Quantity = 1, Units = "cup", Ingredient = ingredients[6], Recipe = recipes[1] },        // עגבניה  
    //           new RecipeIngredient { RecipeID = 2, IngredientID = 13, Quantity = 2, Units = "tsp", Ingredient = ingredients[12], Recipe = recipes[1] },       // מלח  
    //           new RecipeIngredient { RecipeID = 2, IngredientID = 12, Quantity = 3, Units = "tsp", Ingredient = ingredients[11], Recipe = recipes[1] },       // שמן זית  
    //           new RecipeIngredient { RecipeID = 2, IngredientID = 11, Quantity = 1, Units = "tbsp", Ingredient = ingredients[10], Recipe = recipes[1] },      // חומץ  

    //           // מתכון 3: חומוס  
    //           new RecipeIngredient { RecipeID = 3, IngredientID = 9, Quantity = 300, Units = "grams", Ingredient = ingredients[8], Recipe = recipes[2] },    // חומוס יבש  
    //           new RecipeIngredient { RecipeID = 3, IngredientID = 8, Quantity = 3, Units = "tsp", Ingredient = ingredients[7], Recipe = recipes[2] },        // טחינה  
    //           new RecipeIngredient { RecipeID = 3, IngredientID = 15, Quantity = 1, Units = "tsp", Ingredient = ingredients[14], Recipe = recipes[2] },       // שום כתוש  
    //           new RecipeIngredient { RecipeID = 3, IngredientID = 6, Quantity = 2, Units = "tbsp", Ingredient = ingredients[5], Recipe = recipes[2] },       // לימון סחוט  
    //           new RecipeIngredient { RecipeID = 3, IngredientID = 10, Quantity = 1, Units = "cup", Ingredient = ingredients[9], Recipe = recipes[2] },       // מים  
    //        };

    //        // הוספת מרכיבי המתכונים לבסיס הנתונים
    //        context.RecipeIngredients.AddRange(recipeIngredients);
    //        context.SaveChanges();


    //    }
    //}
}
