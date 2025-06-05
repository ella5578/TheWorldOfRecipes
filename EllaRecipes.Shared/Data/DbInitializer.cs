using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;

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

            var ratingsandcomments = new RatingAndComment[]
            {
              new RatingAndComment{UserID=1,RecipeID=1,Rating=5, Comment = "Great!"},
              new RatingAndComment{UserID=2,RecipeID=1,Rating=5, Comment = "Great!"},
              new RatingAndComment{UserID=1,RecipeID=1,Rating=5, Comment = "מאוד טעים, יצא טוב"},
              new RatingAndComment{UserID=1,RecipeID=2,Rating=4, Comment = "Tasty."},
              new RatingAndComment{UserID=2,RecipeID=3,Rating=3, Comment = "Okay."}
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
              new Ingredient { IngredientName = "רוטב טריאקי" } // 47
                



            };


            // הוספת המרכיבים לבסיס הנתונים  
            context.Ingredients.AddRange(ingredients);
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

            var recipeIngredients = new RecipeIngredient[]
            {    
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








            };





            context.RecipeIngredients.AddRange(recipeIngredients);
            context.SaveChanges();
        }
    }
}