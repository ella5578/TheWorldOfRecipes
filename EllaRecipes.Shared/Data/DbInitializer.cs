using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TheWorldOfRecipes.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TheWorldOfRecipesContext context)
        {
            // Look for any Categories.  
            if (context.Categories.Any())
            {
                return;   // DB has been seeded  
            }

            var users = new User[]
            {
                new User
                {
                    UserName = "EmilyR",
                    Password = "Pass1234",
                    Email = "emily.rose@example.com",
                    IsAdmin = false,
                    FirstName = "Emily",
                    LastName = "Rose",
                    RegistrationDate = DateTime.Parse("2022-03-15")
                },
                new User
                {
                    UserName = "DavidK",
                    Password = "Secure789",
                    Email = "david.klein@example.com",
                    IsAdmin = true,
                    FirstName = "David",
                    LastName = "Klein",
                    RegistrationDate = DateTime.Parse("2021-11-30")
                },
                new User
                {
                    UserName = "NoaS",
                    Password = "NoaPass12",
                    Email = "noa.sasson@example.com",
                    IsAdmin = false,
                    FirstName = "Noa",
                    LastName = "Sasson",
                    RegistrationDate = DateTime.Parse("2023-06-20")
                },
                new User
                {
                    UserName = "LiorB",
                    Password = "Lior456!",
                    Email = "lior.ben@example.com",
                    IsAdmin = false,
                    FirstName = "Lior",
                    LastName = "Ben-David",
                    RegistrationDate = DateTime.Parse("2020-01-10")
                },
                new User
                {
                    UserName = "SarahM",
                    Password = "Sarah987",
                    Email = "sarah.mizrahi@example.com",
                    IsAdmin = false,
                    FirstName = "Sarah",
                    LastName = "Mizrahi",
                    RegistrationDate = DateTime.Parse("2024-04-05")
                }

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
                   RecipeName = "בראוניז",
                   Description = "לחתוך תפוחים ולטגן עם סוכר, להוסיף לתבנית עם הבצק לשטח ולפזר קינמון. ובתיאבון!",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   ImageUrl = "brauniz.jpg",
                   TimerMinutes = 60,
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/KbyahTnzbKA?si=KRYAchT3Bd8e8my-"
               },
               new Recipe
               {
                   RecipeName = "עוגת שוקולד",
                   Description = "cake",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   TimerMinutes = 30,
                   ImageUrl = "chocolatecake.jpg",
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/EBAE91Os2VA?si=m7bn3GyeGy7t_-9B"
               },
               new Recipe
               {
                   RecipeName = "עוגיות שוקולד ציפ",
                   Description = "cookie",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   TimerMinutes = 20,
                   ImageUrl = "cookie.jpg",
                   LikesCount = 0,
                   VideoURL = null
               },

               new Recipe
               {
                   RecipeName = "כדורי שוקולד",
                   Description = "לפורר חבילת ביסקוויטים להמיס שוקולד לערבב, לקרר להכין כדורים ולעטוף אותם בבסוכריות או בקוקוס ובתאבון!",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   ImageUrl = "chocolateballs.jpg",
                   TimerMinutes = 35,
                   LikesCount = 0,
                   VideoURL = null
               },  

               // מנות עיקריות  
               new Recipe
               {
                   RecipeName = "שניצל קלאסי",
                   Description = "חזה עוף בציפוי פריך של פירורי לחם, מטוגן עד להזהבה. מומלץ להגיש עם פירה או אורז.",
                   CategoryID = 2,
                   Category = categories.First(c => c.CategoryID == 2),
                   ImageUrl = "schnitzel.jpg",
                   TimerMinutes = 40,
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/bbKb-l4mM8I"
               },
               new Recipe
               {
                   RecipeName = "קציצות ברוטב עגבניות",
                   Description = "קציצות בקר עסיסיות מבושלות ברוטב עגבניות עשיר. מושלם עם אורז לבן.",
                   CategoryID = 2,
                   Category = categories.First(c => c.CategoryID == 2),
                   ImageUrl = "meatballs.jpg",
                   TimerMinutes = 50,
                   LikesCount = 0,
                   VideoURL = null
               },  

               // ארוחות בוקר  
               new Recipe
               {
                   RecipeName = "שקשוקה קלאסית",
                   Description = "ביצים מבושלות ברוטב עגבניות חריף עם בצל, שום ופלפל. מושלם עם חלה טרייה.",
                   CategoryID = 3,
                   Category = categories.First(c => c.CategoryID == 3),
                   ImageUrl = "shakshuka.jpg",
                   TimerMinutes = 25,
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/VZzRzqKYK-8"
               },
               new Recipe
               {
                   RecipeName = "פנקייקים אמריקאים",
                   Description = "פנקייקים רכים ואווריריים מוגשים עם סירופ מייפל ופירות יער.",
                   CategoryID = 3,
                   Category = categories.First(c => c.CategoryID == 3),
                   ImageUrl = "pancakes.jpg",
                   TimerMinutes = 20,
                   LikesCount = 0,
                   VideoURL = null
               },  

               // סלטים  
               new Recipe
               {
                   RecipeName = "סלט קיסר",
                   Description = "עלי חסה פריכים, קרוטונים, גבינת פרמזן ורוטב קיסר מיוחד.",
                   CategoryID = 4,
                   Category = categories.First(c => c.CategoryID == 4),
                   ImageUrl = "caesar_salad.jpg",
                   TimerMinutes = 15,
                   LikesCount = 0,
                   VideoURL = null
               },
               new Recipe
               {
                   RecipeName = "פסטה שמנת פטריות",
                   Description = "לטגן בצל עד שנהייה שקוף להוסיף את הפטריות חתוכות עד שמתרככות להוסיף שום ולערבב, שמנת מלח פלפל אבקת מרק ואגוז מוסקט לערבב ולחכות לרתיחה ואז להעביר לאש הקטנה להוסיף את הפסטה ובתיאבון!",
                   CategoryID = 5,
                   Category = categories.First(c => c.CategoryID == 5),
                   ImageUrl = "pasta1.jpg",
                   TimerMinutes = 40,
                   LikesCount = 0,
                   VideoURL = null
               },  

               // ארוחות צהריים  
               new Recipe
               {
                   RecipeName = "מוקפץ אסייתי",
                   Description = "רצועות עוף, ירקות צבעוניים ורוטב סויה-ג'ינג'ר מוקפצים בווק. טעים ובריא.",
                   CategoryID = 5,
                   Category = categories.First(c => c.CategoryID == 5),
                   ImageUrl = "stirfry.jpg",
                   TimerMinutes = 30,
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/xY6nM7WmU3g"
               },
               new Recipe
               {
                   RecipeName = "קארי ירקות עם אורז",
                   Description = "תבשיל קארי עשיר בירקות טריים וחלב קוקוס. מנה טבעונית ומלאת טעם.",
                   CategoryID = 5,
                   Category = categories.First(c => c.CategoryID == 5),
                   ImageUrl = "veggie_curry.jpg",
                   TimerMinutes = 40,
                   LikesCount = 0,
                   VideoURL = null
               },  

               // מאפים  
               new Recipe
               {
                   RecipeName = "לחם שום ביתי",
                   Description = "לחם פריך מבחוץ ורך מבפנים עם חמאת שום, פטרוזיליה וגבינה צהובה.",
                   CategoryID = 6,
                   Category = categories.First(c => c.CategoryID == 6),
                   ImageUrl = "garlic_bread.jpg",
                   TimerMinutes = 35,
                   LikesCount = 0,
                   VideoURL = null
               },
               new Recipe
               {
                   RecipeName = "בייגל ירושלמי",
                   Description = "מאפה שמרים ארוך עם שומשום, קראנצ'י מבחוץ ורך מבפנים – מושלם עם טחינה.",
                   CategoryID = 6,
                   Category = categories.First(c => c.CategoryID == 6),
                   ImageUrl = "jerusalem_bagel.jpg",
                   TimerMinutes = 90,
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/UZ7RhFq-VOY"
               },
               new Recipe
                {
                    RecipeName = "טירמיסו קלאסי",
                    Description = "קינוח איטלקי עם שכבות של בישקוטים, מסקרפונה וקפה.",
                    CategoryID = 1,
                    Category = categories.First(c => c.CategoryID == 1),
                    ImageUrl = "tiramisu.jpg",
                    TimerMinutes = 45,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/6TEZfDIr-pM"
                },
               new Recipe
                {
                    RecipeName = "חזה עוף ברוטב טריאקי",
                    Description = "חזה עוף מוקפץ ברוטב טריאקי מתקתק עם ירקות אסייתיים.",
                    CategoryID = 2,
                    Category = categories.First(c => c.CategoryID == 2),
                    ImageUrl = "teriyaki_chicken.jpg",
                    TimerMinutes = 35,
                    LikesCount = 0,
                    VideoURL = null
                },
                new Recipe
                 {
                      RecipeName = "פיצה מרגריטה",
                      Description = "פיצה קלאסית עם רוטב עגב tomatoes, גבינת מוצרלה ובזיליקום טרי.",
                      CategoryID = 6,
                      Category = categories.First(c => c.CategoryID == 6),
                      ImageUrl = "margherita_pizza.jpg",
                      TimerMinutes = 30,
                      LikesCount = 0,
                      VideoURL = "https://youtu.be/1j4b2k3f5a8"
                  },
                new Recipe
                {
                    RecipeName = "טוסט אבוקדו וביצה",
                    Description = "פרוסת לחם קלוי עם ממרח אבוקדו וביצה עלומה מעל. פשוט ובריא.",
                    CategoryID = 3,
                    Category = categories.First(c => c.CategoryID == 3),
                    ImageUrl = "avocado_toast.jpg",
                    TimerMinutes = 15,
                    LikesCount = 0,
                    VideoURL = null
                },
                new Recipe
                {
                    RecipeName = "סלט קינואה צבעוני",
                    Description = "סלט בריא עם קינואה, ירקות טריים, גרגרי רימון ותיבול לימוני.",
                    CategoryID = 4,
                    Category = categories.First(c => c.CategoryID == 4),
                    ImageUrl = "quinoa_salad.jpg",
                    TimerMinutes = 25,
                    LikesCount = 0,
                    VideoURL = null
                },
                new Recipe
                {
                    RecipeName = "פסטה פסטו עם עגבניות שרי",
                    Description = "פסטה עם רוטב פסטו טרי ועגבניות שרי קלות. מנה קלה ומהירה.",
                    CategoryID = 5,
                    Category = categories.First(c => c.CategoryID == 5),
                    ImageUrl = "pesto_pasta.jpg",
                    TimerMinutes = 20,
                    LikesCount = 0,
                    VideoURL = null
                },
                new Recipe
                {
                    RecipeName = "מאפינס בננה ושוקולד צ'יפס",
                    Description = "מאפים רכים ומתוקים בטעם בננה עם שוקולד צ'יפס. מושלם לקפה.",
                    CategoryID = 6,
                    Category = categories.First(c => c.CategoryID == 6),
                    ImageUrl = "banana_muffins.jpg",
                    TimerMinutes = 30,
                    LikesCount = 0,
                    VideoURL = null
                }
                






            };


            context.Recipes.AddRange(recipes);
            context.SaveChanges();
            var schnitzel = context.Recipes.First(r => r.RecipeName == "שניצל קלאסי");
            var caesarSalad = context.Recipes.First(r => r.RecipeName == "סלט קיסר");
            var chocolateCake = context.Recipes.First(r => r.RecipeName == "עוגת שוקולד");
            var brownies = context.Recipes.First(r => r.RecipeName == "בראוניז");
            var chocolateBalls = context.Recipes.First(r => r.RecipeName == "כדורי שוקולד");
            var chocolateChipCookies = context.Recipes.First(r => r.RecipeName == "עוגיות שוקולד ציפ");
            var meatballs = context.Recipes.First(r => r.RecipeName == "קציצות ברוטב עגבניות");
            var shakshuka = context.Recipes.First(r => r.RecipeName == "שקשוקה קלאסית");
            var pancakes = context.Recipes.First(r => r.RecipeName == "פנקייקים אמריקאים");
            var pastaMushroom = context.Recipes.First(r => r.RecipeName == "פסטה שמנת פטריות");
            var stirFry = context.Recipes.First(r => r.RecipeName == "מוקפץ אסייתי");
            var veggieCurry = context.Recipes.First(r => r.RecipeName == "קארי ירקות עם אורז");
            var garlicBread = context.Recipes.First(r => r.RecipeName == "לחם שום ביתי");
            var jerusalemBagel = context.Recipes.First(r => r.RecipeName == "בייגל ירושלמי");
            var bananaMuffins = context.Recipes.First(r => r.RecipeName == "מאפינס בננה ושוקולד צ'יפס");
            var pestoPasta = context.Recipes.First(r => r.RecipeName == "פסטה פסטו עם עגבניות שרי");
            var creamyMushroomPasta = context.Recipes.First(r => r.RecipeName == "פסטה שמנת פטריות");
            var quinoaSalad = context.Recipes.First(r => r.RecipeName == "סלט קינואה צבעוני");
            var teriyakiChicken = context.Recipes.First(r => r.RecipeName == "חזה עוף ברוטב טריאקי");
            var pizza = context.Recipes.First(r => r.RecipeName == "פיצה מרגריטה");
            var tiramisu = context.Recipes.First(r => r.RecipeName == "טירמיסו קלאסי");


            var ratingsandcomments = new RatingAndComment[]
            {
                new RatingAndComment { UserID = 3, RecipeID = schnitzel.RecipeID, Rating = 5, Comment = "המתכון הכי טוב שניסיתי לשניצל!" },
                new RatingAndComment { UserID = 4, RecipeID = shakshuka.RecipeID, Rating = 2, Comment = "היה טעים, אבל הייתי מוסיף עוד קצת תבלינים." },
                new RatingAndComment { UserID = 5, RecipeID = garlicBread.RecipeID, Rating = 1, Comment = "לא יצא מוצלח, משהו היה חסר." },
                new RatingAndComment { UserID = 1, RecipeID = bananaMuffins.RecipeID, Rating = 5, Comment = "פשוט מושלם. הילדים אהבו מאוד." },
                new RatingAndComment { UserID = 2, RecipeID = 6, Rating = 3, Comment = "בסדר, אבל הציפיתי ליותר טעם." },
                new RatingAndComment { UserID = 3, RecipeID = pizza.RecipeID, Rating = 4, Comment = "הבצק יצא רך ונעים, אחלה מתכון." },
                new RatingAndComment { UserID = 4, RecipeID = veggieCurry.RecipeID, Rating = 1, Comment = "לא אהבנו בכלל, המתכון מבלבל." },
                new RatingAndComment { UserID = 5, RecipeID = 8, Rating = 5, Comment = "מדהים! קל, מהיר וטעים בטירוף." },
                new RatingAndComment { UserID = 1, RecipeID = 9, Rating = 4, Comment = "סלט טעים, מתאים לחורף." },
                new RatingAndComment { UserID = 2, RecipeID = 10, Rating = 3, Comment = "נחמד, אבל לא אחזור עליו." },
                new RatingAndComment { UserID = 3, RecipeID = chocolateChipCookies.RecipeID, Rating = 5, Comment = "עוגיות מושלמות! יצאו פריכות בדיוק כמו שאני אוהב." },
                new RatingAndComment { UserID = 4, RecipeID = pastaMushroom.RecipeID, Rating = 4, Comment = "פסטה טעימה מאוד, הוספתי גם פרמזן." },
                new RatingAndComment { UserID = 5, RecipeID = brownies.RecipeID, Rating = 5, Comment = "הבראוניז האלה זה פשע. אי אפשר להפסיק לאכול!" },
                new RatingAndComment { UserID = 2, RecipeID = pizza.RecipeID, Rating = 2, Comment = "הבצק לא תפח כמו שצריך." },
                new RatingAndComment { UserID = 1, RecipeID = shakshuka.RecipeID, Rating = 5, Comment = "השקשוקה יצאה מדהימה, בדיוק כמו במסעדה." },
                new RatingAndComment { UserID = 3, RecipeID = 8, Rating = 3, Comment = "טעים אבל דרש יותר זמן הכנה ממה שכתוב." },
                new RatingAndComment { UserID = 4, RecipeID = teriyakiChicken.RecipeID, Rating = 5, Comment = "אהבתי מאוד את הרוטב טריאקי. נעים ומתקתק." },
                new RatingAndComment { UserID = 5, RecipeID = pizza.RecipeID, Rating = 1, Comment = "פיצה יבשה מדי, הבצק לא התרומם בכלל." },
                new RatingAndComment { UserID = 1, RecipeID = chocolateChipCookies.RecipeID, Rating = 4, Comment = "טוב, אבל לדעתי צריך להוסיף עוד שוקולד צ’יפס." },
                new RatingAndComment { UserID = 2, RecipeID = quinoaSalad.RecipeID, Rating = 5, Comment = "מושלם לארוחת ערב קלילה, כל המשפחה נהנתה." }

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
              new Ingredient { IngredientName = "ביצים" },
              new Ingredient { IngredientName = "חלב" },
              new Ingredient { IngredientName = "פירורי לחם" },
              new Ingredient { IngredientName = "קמח" },
              new Ingredient { IngredientName = "שוקולד" },
              new Ingredient { IngredientName = "סוכר" },
              new Ingredient { IngredientName = "תפוזים" },
              new Ingredient { IngredientName = "בשר טחון" },
              new Ingredient { IngredientName = "חזה עוף" },
              new Ingredient { IngredientName = "אורז" },
              new Ingredient { IngredientName = "פסטה" },
              new Ingredient { IngredientName = "רסק עגבניות" },
              new Ingredient { IngredientName = "שמנת מתוקה" },
              new Ingredient { IngredientName = "מלח" },
              new Ingredient { IngredientName = "פטריות" },
              new Ingredient { IngredientName = "בצל" },  

              // מצרכים נוספים לפי המתכונים  
              new Ingredient { IngredientName = "חמאה" },
              new Ingredient { IngredientName = "קקאו" },
              new Ingredient { IngredientName = "וניל" },
              new Ingredient { IngredientName = "שוקולד צ’יפס" },
              new Ingredient { IngredientName = "פירורי פתי בר" },
              new Ingredient { IngredientName = "קוקוס" },
              new Ingredient { IngredientName = "אבקת אפייה" },
              new Ingredient { IngredientName = "מים" },
              new Ingredient { IngredientName = "מיונז" },
              new Ingredient { IngredientName = "מיץ לימון" },
              new Ingredient { IngredientName = "שום" },
              new Ingredient { IngredientName = "גבינת פרמזן" },
              new Ingredient { IngredientName = "שמרים" },
              new Ingredient { IngredientName = "שמן" },
              new Ingredient { IngredientName = "פלפל שחור" },
              new Ingredient { IngredientName = "ירקות מוקפצים" },
              new Ingredient { IngredientName = "תבלין קארי" },
              new Ingredient { IngredientName = "לחם" }, // או בגט
              new Ingredient { IngredientName = "חסה" },       // 35
              new Ingredient { IngredientName = "אנשובי" },             // 36
              new Ingredient { IngredientName = "קרוטונים" },           // 37
              new Ingredient { IngredientName = "עגבניות" },            // 38
              new Ingredient { IngredientName = "מלפפונים" },           // 39
              new Ingredient { IngredientName = "גזר" },                 // 40
              new Ingredient { IngredientName = "פלפל מתוק" },           // 41
              new Ingredient { IngredientName = "רוטב פסטו" }, 
              new Ingredient { IngredientName = "עגבניות שרי" },
              new Ingredient { IngredientName = "שמן זית" },
              new Ingredient { IngredientName = "בננה" },
              new Ingredient { IngredientName = "קינואה" }, // 46
              new Ingredient { IngredientName = "עשבי תיבול" }, // 47
              new Ingredient { IngredientName = "רוטב טריאקי" }, // 48
              new Ingredient { IngredientName = "פטרוזיליה קצוצה" },//49
              new Ingredient { IngredientName = "גבינה צהובה מגוררת" }//50





            };


            // הוספת המרכיבים לבסיס הנתונים  
            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();

 
            var recipeIngredients = new RecipeIngredient[]
            {
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 32, // ירקות מוקפצים
                    Quantity = 300,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 32)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 9, // חזה עוף
                    Quantity = 300,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 9)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 47, // עשבי תיבול
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 47)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 48, // תבלין קארי
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 48)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 45, // שמן זית
                    Quantity = 1,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 45)
                },

                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 5, // שוקולד
                    Quantity = 100,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 5)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 6, // סוכר
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 3,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 13, // שמנת מתוקה
                    Quantity = 250,
                    Units = "ml",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 13)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 18, // וניל
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 18)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 17, // קקאו
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },

                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 49, // פטרוזיליה קצוצה  
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 35)
                },
                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 50, // גבינה צהובה מגוררת  
                    Quantity = 100,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 36)
                },
                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 31, // פלפל שחור  
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },

                // Recipe 10: Curry with Rice
                
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 15, // פטריות  
                    Quantity = 200,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 15)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 29, // שמן  
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 29)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 16, // בצל  
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 13, // שמנת מתוקה  
                    Quantity = 200,
                    Units = "ml",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 13)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 33, // תבלין קארי  
                    Quantity = 1,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 33)
                },
                new RecipeIngredient
                {
                    RecipeID =veggieCurry.RecipeID,
                    IngredientID = 10, // אורז  
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 10)
                },

                // Recipe 9: American Pancakes
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 4, // קמח  
                    Quantity = 1,
                    Units = "cups",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 6, // סוכר  
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 1, // ביצים  
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 2, // חלב  
                    Quantity = 2,
                    Units = "cups",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 2)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 23, // אבקת אפייה  
                    Quantity = 1,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 23)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 17, // חמאה  
                    Quantity = 50,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },

                // Recipe 8: Shakshuka
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 1, // ביצים  
                    Quantity = 4,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 12, // רסק עגבניות  
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 12)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 38, // עגבניות  
                    Quantity = 3,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 38)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 16, // בצל  
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 28, // שום  
                    Quantity = 2,
                    Units = "cloves",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 28)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 14, // מלח  
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 31, // פלפל שחור  
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },

                 // Recipe 5: Schnitzel  
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 9, // חזה עוף  
                   Quantity = 500,
                   Units = "grams",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 9)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 1, // ביצים  
                   Quantity = 2,
                   Units = "units",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 1)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 3, // פירורי לחם  
                   Quantity = 1,
                   Units = "cup",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 3)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 14, // מלח  
                   Quantity = 1,
                   Units = "tsp",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 14)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 31, // פלפל שחור  
                   Quantity = 1,
                   Units = "tsp",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 31)
               },
               new RecipeIngredient
               {
                  RecipeID = schnitzel.RecipeID,
                   IngredientID = 30, // שמן  
                   Quantity = 1,
                   Units = "liter",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 30)
               },
               new RecipeIngredient
               {
                  RecipeID = schnitzel.RecipeID,
                   IngredientID = 4, // קמח  
                   Quantity = 1,
                   Units = "cup",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 4)
               },  
               // Recipe 4: Chocolate Balls  
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 17, // חמאה  
                   Quantity = 100,
                   Units = "grams",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 17)
               },
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 5, // שוקולד  
                   Quantity = 200,
                   Units = "grams",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 5)
               },
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 22, // קוקוס  
                   Quantity = 100,
                   Units = "gram",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 22)
               },
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 21, // פירורי פתי בר  
                   Quantity = 500,
                   Units = "grams",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 21)
               },
               new RecipeIngredient
               {
                  RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 2, // חלב  
                   Quantity = 1,
                   Units = "cup",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 2)
               },
               // Recipe 5: Caesar Salad
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 35, // חסה 
                    Quantity = 1,
                    Units = "head",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 35)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 36, // אנשובי
                    Quantity = 4,
                    Units = "filets",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 36)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 25, // מיונז
                    Quantity = 3,
                    Units = "tablespoons",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 25)
                },
                new RecipeIngredient
                {
                   RecipeID = caesarSalad.RecipeID,
                    IngredientID = 28, // גבינת פרמזן
                    Quantity = 50,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 28)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 26, // מיץ לימון
                    Quantity = 1,
                    Units = "tablespoon",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 26)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 27, // שום
                    Quantity = 1,
                    Units = "clove",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 30, // שמן (שמן זית)
                    Quantity = 2,
                    Units = "tablespoons",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 37, // קרוטונים
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 37)
                },
                // Recipe X: Meatballs in Red Sauce with Rice
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 8, // בשר טחון
                    Quantity = 500,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 8)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 3, // פירורי לחם
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 3)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 15, // בצל
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 15)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 30, // פלפל שחור
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 27, // שום
                    Quantity = 2,
                    Units = "cloves",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 31, // רסק עגבניות
                    Quantity = 3,
                    Units = "tablespoons",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 2,
                    Units = "tablespoons",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 38, // אורז
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 38)
                },
                // Recipe Y: Chocolate Cake
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 5, // שוקולד
                    Quantity = 200,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 5)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 17, // חמאה
                    Quantity = 200,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 4,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 4, // קמח
                    Quantity = 200,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 2, // חלב
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 2)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 19, // סוכר
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 19)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 20, // אבקת אפייה
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 20)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 4, // קמח
                    Quantity = 1,
                    Units = "cups",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 2,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 6, // סוכר
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 29, // שמן
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 29)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 24, // אבקת אפייה
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 24)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 20, // שוקולד צ’יפס
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 20)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 45, // בננה
                    Quantity = 2,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 45)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 11, // פסטה
                    Quantity = 250,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 11)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 42, // רוטב פסטו
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 42)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 41, // עגבניות שרי
                    Quantity = 10,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 41)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 44, // שמן זית
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 44)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 11, // פסטה
                    Quantity = 250,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 11)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 14, // שמנת מתוקה
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 15, // פטריות
                    Quantity = 200,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 15)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 16, // בצל
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 31, // פלפל שחור
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 46, // קינואה
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 46)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 39, // מלפפונים
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 39)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 38, // עגבניות
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 38)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 47, // עשבי תיבול
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 47)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 27, // מיץ לימון
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 44, // שמן זית
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 44)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 9, // חזה עוף
                    Quantity = 500,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 9)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 47, // רוטב טריאקי
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 47)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 31, // פלפל שחור
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 16, // בצל
                    Quantity = 1,
                    Units = "unit",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                // Recipe 6: Brownies  
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 5, // שוקולד  
                    Quantity = 200,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 5)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 6, // סוכר  
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 1, // ביצים  
                    Quantity = 3,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 17, // חמאה  
                    Quantity = 150,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 4, // קמח  
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 18, // קקאו  
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 18)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 23, // אבקת אפייה  
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 23)
                },
                // Recipe 7: Chocolate Chip Cookies
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 17, // חמאה  
                    Quantity = 150,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 6, // סוכר  
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 1, // ביצים  
                    Quantity = 2,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 4, // קמח  
                    Quantity = 2,
                    Units = "cups",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 19, // וניל  
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 19)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 20, // שוקולד צ’יפס  
                    Quantity = 1,
                    Units = "cup",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 20)
                },
                // Recipe: פיצה מרגריטה
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 4, // קמח
                    Quantity = 3,
                    Units = "cups",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 23, // אבקת אפייה
                    Quantity = 1,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 23)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 24, // מים
                    Quantity = 1,
                    Units = "cups",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 24)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 12, // רסק עגבניות
                    Quantity = 5,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 12)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "tsp",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 28, // גבינת פרמזן
                    Quantity = 100,
                    Units = "grams",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 28)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 43, // עגבניות שרי
                    Quantity = 6,
                    Units = "units",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 43)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 47, // עשבי תיבול
                    Quantity = 2,
                    Units = "tbsp",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 47)
                }









            };





            context.RecipeIngredients.AddRange(recipeIngredients);
            context.SaveChanges();
        }
    }
}