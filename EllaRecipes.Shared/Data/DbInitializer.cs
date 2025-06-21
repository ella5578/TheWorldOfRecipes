using EllaRecipes.Shared.Data;
using EllaRecipes.Shared.Models;
using System.IO;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;

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
                    UserName = "aryeh",
                    Email = "aryeh@example.com",
                    PasswordHash = "b5vIFu4ggiBkxbr4Jpdmylv4v/BT2Xizv5lHnDpCH+k=",
                    PasswordSalt = "54kLVUii1hvgeiDpmZHr3Q==",
                    IsAdmin = true,
                    FirstName = "Aryeh",
                    LastName = "Wiesen",
                    RegistrationDate = DateTime.Parse("2022-03-15")
                },
                new User
                {
                    UserName = "EmilyR",
                    Email = "emily.rose@example.com",
                    PasswordHash = "b5vIFu4ggiBkxbr4Jpdmylv4v/BT2Xizv5lHnDpCH+k=",
                    PasswordSalt = "54kLVUii1hvgeiDpmZHr3Q==",
                    IsAdmin = false,
                    FirstName = "Emily",
                    LastName = "Rose",
                    RegistrationDate = DateTime.Parse("2022-03-15")
                },
                new User
                {
                    UserName = "DavidK",
                    PasswordHash = "b5vIFu4ggiBkxbr4Jpdmylv4v/BT2Xizv5lHnDpCH+k=",
                    PasswordSalt = "54kLVUii1hvgeiDpmZHr3Q==",
                    Email = "david.klein@example.com",
                    IsAdmin = true,
                    FirstName = "David",
                    LastName = "Klein",
                    RegistrationDate = DateTime.Parse("2021-11-30")
                },
                new User
                {
                    UserName = "NoaS",
                    PasswordHash = "b5vIFu4ggiBkxbr4Jpdmylv4v/BT2Xizv5lHnDpCH+k=",
                    PasswordSalt = "54kLVUii1hvgeiDpmZHr3Q==",
                    Email = "noa.sasson@example.com",
                    IsAdmin = false,
                    FirstName = "Noa",
                    LastName = "Sasson",
                    RegistrationDate = DateTime.Parse("2023-06-20")
                },
                new User
                {
                    UserName = "LiorB",
                    PasswordHash = "b5vIFu4ggiBkxbr4Jpdmylv4v/BT2Xizv5lHnDpCH+k=",
                    PasswordSalt = "54kLVUii1hvgeiDpmZHr3Q==",
                    Email = "lior.ben@example.com",
                    IsAdmin = false,
                    FirstName = "Lior",
                    LastName = "Ben-David",
                    RegistrationDate = DateTime.Parse("2020-01-10")
                },
                new User
                {
                    UserName = "SarahM",
                    PasswordHash = "b5vIFu4ggiBkxbr4Jpdmylv4v/BT2Xizv5lHnDpCH+k=",
                    PasswordSalt = "54kLVUii1hvgeiDpmZHr3Q==",
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
                   Description = "ממיסים חמאה ושוקולד יחד עד לקבלת תערובת אחידה, מוסיפים סוכר, ביצים, קמח וקקאו ומערבבים. יוצקים לתבנית מרובעת ואופים עד שהקצוות יציבים והמרכז לח מעט. מתקבל קינוח שוקולדי, עשיר ודחוס מבפנים עם קראסט עדין מבחוץ. מושלם לצד גלידה.",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   ImageUrl = "brauniz.jpg",
                   TimerMinutes = 60,
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/Cn0vE38OiNM?si=uuUCcfI82tG1qydV"
               },
               new Recipe
               {
                   RecipeName = "עוגת שוקולד",
                   Description = "מערבבים ביצים, סוכר, שמן, קקאו, מים רותחים, קמח ואבקת אפייה – עד קבלת בלילה חלקה. יוצקים לתבנית ואופים עד שקיסם יוצא יבש. מתקבלת עוגה שוקולדית, רכה ונימוחה שמתאימה לימי הולדת או כפינוק מתוק ליד הקפה. אפשר לצפות בגנאש שוקולד.",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   TimerMinutes = 30,
                   ImageUrl = "chocolatecake.jpg",
                   LikesCount = 10,
                   VideoURL = "https://youtu.be/EBAE91Os2VA?si=m7bn3GyeGy7t_-9B"
               },
               new Recipe
               {
                   RecipeName = "עוגיות שוקולד ציפ",
                   Description = "מערבבים חמאה רכה עם סוכר לבן וחום, מוסיפים ביצה, קמח, אבקת אפייה, וניל ושוקולד צ'יפס. יוצרים כדורים קטנים ואופים עד שהשוליים מזהיבים והמרכז עדיין רך. העוגיות יוצאות פריכות מבחוץ ורכות ונמסות בפנים – בדיוק כמו בקונדיטוריה.",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   TimerMinutes = 20,
                   ImageUrl = "cookie.jpg",
                   LikesCount = 7,
                   VideoURL = "https://www.youtube.com/embed/D8Tm4vaku2s?si=dguTgeyfD8GhYMkl"
               },

               new Recipe
               {
                   RecipeName = "כדורי שוקולד",
                   Description = "מפוררים חבילת פתי בר לקערה, ממיסים שוקולד עם חמאה, ומערבבים עם פירורים, קוקוס, קקאו ומעט מים או חלב. מקררים מעט, יוצרים כדורים קטנים ומגלגלים בקוקוס או סוכריות צבעוניות. קינוח קל, ללא אפייה – מושלם לילדים ולכל הגילאים.",
                   CategoryID = 1,
                   Category = categories.First(c => c.CategoryID == 1),
                   ImageUrl = "chocolateballs.jpg",
                   TimerMinutes = 35,
                   LikesCount = 9,
                   VideoURL = "https://youtu.be/uJ_QZzWW5CU?si=By6JccyT9elAsbOF"
               },  

               // מנות עיקריות  
               new Recipe
               {
                   RecipeName = "שניצל קלאסי",
                  Description = "חזה עוף פרוס דק מתובל במלח ופלפל, נטבל בביצה וקמח, מצופה בפירורי לחם ומטוגן בשמן חם עד להזהבה מושלמת. מתקבל ציפוי קריספי עם בשר עסיסי מבפנים. להגיש עם פירה, אורז או צ'יפס וקצת לימון בצד. קלאסיקה ישראלית מנצחת.",
                   CategoryID = 2,
                   Category = categories.First(c => c.CategoryID == 2),
                   ImageUrl = "schnitzel.jpg",
                   TimerMinutes = 40,
                   LikesCount = 12,
                   VideoURL = "https://youtu.be/yp1m9iuKYUk?si=Kjz32V-Cyc9HoS-K"
               },
               new Recipe
               {
                   RecipeName = "קציצות ברוטב עגבניות",
                   Description = "מערבבים בשר טחון עם ביצה, פירורי לחם, בצל ותיבול. יוצרים קציצות ומבשלים אותן ברוטב עשיר של רסק עגבניות, שום ותבלינים. הבישול מעניק לקציצות מרקם רך וטעמים עמוקים. מגישים לצד אורז לבן או פירה – מושלם לארוחת צהריים ביתית.",
                   CategoryID = 2,
                   Category = categories.First(c => c.CategoryID == 2),
                   ImageUrl = "meatballs.jpg",
                   TimerMinutes = 50,
                   LikesCount = 3,
                   VideoURL = "https://youtu.be/Zn6dEdJyTLU?si=7HB0a4b7wlsMrcv9"
               },  

               // ארוחות בוקר  
               new Recipe
               {
                   RecipeName = "שקשוקה קלאסית",
                  Description = "מטגנים בצל, שום ופלפל עד לריכוך, מוסיפים עגבניות קצוצות, רסק עגבניות ותבלינים ומבשלים לרוטב סמיך. שוברים ביצים ישירות לתוך הרוטב, מכסים ומבשלים עד שהחלבון מתייצב והחלמון נשאר נוזלי. מגישים עם חלה טרייה או פיתה לניגוב.",
                   CategoryID = 3,
                   Category = categories.First(c => c.CategoryID == 3),
                   ImageUrl = "shakshuka.jpg",
                   TimerMinutes = 25,
                   LikesCount = 0,
                   VideoURL = "https://youtu.be/EqnngTy9Jr4?si=73586MTPbI3INb8_"
               },
               new Recipe
                {
                    RecipeName = "פנקייקים אמריקאים",
                    Description = "מתכון קלאסי לפנקייקים אמריקאיים – רכים, אווריריים וזהובים מבחוץ. הכנה קלה ומהירה: מערבבים את החומרים היבשים והרטובים בנפרד, מאחדים לתערובת חלקה, ומטגנים על מחבת חמה משומנת עד שהפנקייקים תופחים ומשחימים. מגישים עם סירופ מייפל, פירות יער, אבקת סוכר או כל תוספת אהובה.",
                    CategoryID = 3,
                    Category = categories.First(c => c.CategoryID == 3),
                    ImageUrl = "pancakes.jpg",
                    TimerMinutes = 20,
                   LikesCount = 0,
                    VideoURL = "https://youtu.be/RTExkuPgxlI?si=_WT71MW4BWfSKJUh"
                },
  

               // סלטים  
               new Recipe
                {
                    RecipeName = "סלט קיסר",
                    Description = "חוצים עלי חסה רומאית, שוטפים ומייבשים היטב. מכינים רוטב קיסר קלאסי (חלמונים, חרדל, שום, אנשובי, לימון ושמן זית), יוצקים על החסה, מוסיפים קרוטונים וגבינת פרמזן מגורדת ומערבבים קלות. מתקבל סלט רענן, פריך וטעים במיוחד.",
                    CategoryID = 4,
                    Category = categories.First(c => c.CategoryID == 4),
                    ImageUrl = "caesar_salad.jpg",
                    TimerMinutes = 15,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/w7-ZkFaZdYw?si=PBnIGN1WyxacBswN"
                },
                new Recipe
                {
                    RecipeName = "פסטה שמנת פטריות",
                    Description = "מטגנים בצל קצוץ עד שקיפות, מוסיפים פטריות פרוסות ומבשלים עד ריכוך. מוסיפים שום, שמנת מתוקה, מלח, פלפל, אבקת מרק ואגוז מוסקט. מביאים לרתיחה ומבשלים על אש קטנה. מוסיפים את הפסטה המבושלת, מערבבים ומגישים חם.",
                    CategoryID = 5,
                    Category = categories.First(c => c.CategoryID == 5),
                    ImageUrl = "pasta1.jpg",
                    TimerMinutes = 40,
                    LikesCount = 5,
                    VideoURL = "https://youtu.be/Q6fMwdxqVng?si=z0gEs5wPubtajR2z"
                },
                new Recipe
                {
                    RecipeName = "מוקפץ אסייתי",
                    Description = "חותכים עוף לרצועות ומטגנים עם מעט שמן. מוסיפים ירקות קצוצים כמו גזר, קישוא, פלפל ובצל ירוק. מתבלים ברוטב סויה, ג'ינג'ר ושום. מקפיצים יחד בווק עד ריכוך. ניתן להוסיף אטריות ביצים או אורז מאודה בצד.",
                    CategoryID = 5,
                    Category = categories.First(c => c.CategoryID == 5),
                    ImageUrl = "stirfry.jpg",
                    TimerMinutes = 30,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/86BwNVUTh8U?si=bgt_j6OF7635KPCc"
                },
                new Recipe
                {
                    RecipeName = "קארי ירקות עם אורז",
                    Description = "מטגנים בצל, שום וג'ינג'ר טרי. מוסיפים תבליני קארי, קוביות תפוחי אדמה, גזר, קישוא ופלפל. יוצקים חלב קוקוס ומבשלים עד שהירקות רכים. מגישים עם אורז לבן או בסמטי. תבשיל טבעוני עשיר ומחמם.",
                    CategoryID = 5,
                    Category = categories.First(c => c.CategoryID == 5),
                    ImageUrl = "veggie_curry.jpg",
                    TimerMinutes = 40,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/-7MrKfR1E8w?si=sQ1FNlA7C0JqRMs8"
                },
                new Recipe
                {
                    RecipeName = "לחם שום ביתי",
                    Description = "פורסים בגט או לחם איטלקי לאורך. מערבבים חמאה רכה עם שום כתוש, פטרוזיליה קצוצה וגבינה צהובה מגורדת. מורחים על הלחם ואופים עד שהלחם פריך והחמאה נמסה. מעדן חם שמתאים לכל ארוחה.",
                    CategoryID = 6,
                    Category = categories.First(c => c.CategoryID == 6),
                    ImageUrl = "garlic_bread.jpg",
                    TimerMinutes = 35,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/bNKsZZgaibM?si=YgR_nquGyTPbjf2n"
                },
                new Recipe
                {
                    RecipeName = "בייגל ירושלמי",
                    Description = "מכינים בצק שמרים רך, מתפיחים, יוצרים צורת בייגל ארוכה, מברישים במים עם מעט סוכר וזורים שומשום. אופים בתנור חם עד להשחמה. טעים במיוחד עם טחינה, לבנה או גבינה מלוחה.",
                    CategoryID = 6,
                    Category = categories.First(c => c.CategoryID == 6),
                    ImageUrl = "jerusalem_bagel.jpg",
                    TimerMinutes = 90,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/SVzJG9M8BsU?si=C-4EnQr2X1che5Qj"
                },
                new Recipe
                {
                    RecipeName = "טירמיסו קלאסי",
                    Description = "טובלים בישקוטים בקפה חזק עם ליקר, מסדרים בתבנית בשכבות עם קרם מסקרפונה מוקצף. חוזרים על הפעולה, מסיימים באבקת קקאו. מקררים לפחות 4 שעות. קינוח איטלקי קלאסי, עשיר ואלגנטי.",
                    CategoryID = 1,
                    Category = categories.First(c => c.CategoryID == 1),
                    ImageUrl = "tiramisu.jpg",
                    TimerMinutes = 45,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/V3We5zttM04?si=RILy6HV0Lo4jXL5k"
                },
                new Recipe
                {
                    RecipeName = "חזה עוף בטריאקי",
                    Description = "חותכים חזה עוף לקוביות ומטגנים. מוסיפים רוטב טריאקי, מעט דבש, ג'ינג'ר ושום. מבשלים עד שהרוטב מצפה את העוף. מגישים עם אורז או ירקות מאודים. ארוחה פשוטה עם טעם אסייתי מובהק.",
                    CategoryID = 2,
                    Category = categories.First(c => c.CategoryID == 2),
                    ImageUrl = "teriyaki_chicken.jpg",
                    TimerMinutes = 35,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/37HIVx_NhmI?si=nXUAtgQ6j2CVO8od"
                },

                new Recipe
                 {
                      RecipeName = "פיצה מרגריטה",
                      Description = "1. מרדדים בצק פיצה דק על תבנית אפייה משומנת.\n2. מורחים שכבת רוטב עגבניות (רסק, שום כתוש, שמן זית, מלח ואורגנו).\n3. מפזרים מוצרלה פרוסה או מגוררת.\n4. אופים בתנור שחומם מראש ל־220 מעלות כ־10–15 דקות עד שהבצק זהוב.\n5. מוסיפים עלים של בזיליקום טרי ומזלפים מעט שמן זית לפני ההגשה.",
                      CategoryID = 6,
                      Category = categories.First(c => c.CategoryID == 6),
                      ImageUrl = "margherita_pizza.jpg",
                      TimerMinutes = 30,
                      LikesCount = 0,
                      VideoURL = "https://youtu.be/4bb3alO6w-Y?si=_VKDbe8nkwXJvcNn"
                  },
                new Recipe
                {
                    RecipeName = "טוסט אבוקדו וביצה",
                    Description = "1. קולים פרוסת לחם כפרי עד שהופכת זהובה ופריכה.\n2. מועכים אבוקדו בשל עם מיץ לימון, מלח ופלפל.\n3. מורחים את הממרח על הטוסט.\n4. מכינים ביצה עלומה: שוברים ביצה לקערה קטנה, יוצקים למים רותחים עם מעט חומץ ומבשלים 2–3 דקות.\n5. מניחים את הביצה על האבוקדו ומפזרים מעל פתיתי צ'ילי או שומשום שחור.",
                    CategoryID = 3,
                    Category = categories.First(c => c.CategoryID == 3),
                    ImageUrl = "avocado_toast.jpg",
                    TimerMinutes = 15,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/pqHt7vXfpJI?si=ns_TyyINnl_Va343"
                },
                new Recipe
                {
                    RecipeName = "סלט קינואה צבעוני",
                    Description = "1. מבשלים קינואה לפי ההוראות – 1 כוס קינואה עם 2 כוסות מים עד שהנוזלים נספגים.\n2. מצננים ומעבירים לקערה.\n3. מוסיפים עגבניות שרי חתוכות, מלפפון, פלפל צבעוני, בצל ירוק, פטרוזיליה וגרגרי רימון.\n4. מתבלים בשמן זית, מיץ לימון, מלח, פלפל ושום כתוש.\n5. מערבבים היטב ומגישים קר.",
                    CategoryID = 4,
                    Category = categories.First(c => c.CategoryID == 4),
                    ImageUrl = "quinoa_salad.jpg",
                    TimerMinutes = 25,
                    LikesCount = 1,
                    VideoURL = "https://youtu.be/jRpx4beVvb8?si=mVB6oOnVByfQFBR0"
                },

                new Recipe
                {
                    RecipeName = "פסטה פסטו",
                    Description = "1. מבשלים פסטה לפי ההוראות על האריזה.\n2. במחבת עם מעט שמן זית מקפיצים עגבניות שרי חצויות למשך 2–3 דקות.\n3. מוסיפים לפסטה רוטב פסטו מוכן (או ביתי: בזיליקום, שמן זית, צנוברים, שום ופרמזן בטחינה).\n4. מערבבים יחד עם העגבניות, מפזרים גבינת פרמזן ומגישים חם.",
                    CategoryID = 5,
                    Category = categories.First(c => c.CategoryID == 5),
                    ImageUrl = "pesto_pasta.jpg",
                    TimerMinutes = 20,
                    LikesCount = 2,
                    VideoURL = "https://youtu.be/8HdfGmQaabM?si=QjsmnpcGVHx6V66l"
                },
                new Recipe
                {
                    RecipeName = "מאפינס בננה ושוקולד",
                    Description =  "1. מועכים 2 בננות בשלות בקערה.\n2. מוסיפים ביצה, חצי כוס סוכר, רבע כוס שמן וקורט וניל – מערבבים היטב.\n3. מוסיפים 1 כוס קמח, 1 כפית אבקת אפייה וקמצוץ מלח.\n4. מקפלים שוקולד צ'יפס לפי הטעם.\n5. יוצקים לתבנית מאפינס ואופים כ־20–25 דקות בתנור שחומם מראש ל־180 מעלות עד שקיסם יוצא יבש.",
                    CategoryID = 6,
                    Category = categories.First(c => c.CategoryID == 6),
                    ImageUrl = "banana_muffins.jpg",
                    TimerMinutes = 30,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/-qVMQADWNFU?si=cG-MDvhF_qM7k9ub"
                },
                new Recipe
                {
                    RecipeName = "עוגת גבינה קרה",
                    Description = "1. מרסקים כ־200 גרם פתי בר ומערבבים עם 100 גרם חמאה מומסת.\n2. מהדקים לתבנית עגולה ושטוחים את התערובת לבסיס אחיד.\n3. מקציפים שמנת מתוקה עם אינסטנט פודינג וניל.\n4. מוסיפים גבינת שמנת וסוכר, וטורפים עד לקבלת תערובת אחידה.\n5. יוצקים את הקרם על הבסיס ומכניסים לקירור לשעתיים לפחות.\n6. ממיסים אבקת ג'לי עם מים רותחים, מצננים מעט ושופכים בעדינות מעל הקרם.\n7. מצננים עוד כשעה-שעתיים עד להתייצבות.",
                    CategoryID = 1,
                    Category = categories.First(c => c.CategoryID == 1),
                    TimerMinutes = 25,
                    ImageUrl = "cheesecake.jpg",
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/tpsywnPNDsw?si=pkUZAlQKjN185xfR"
                },
               new Recipe
                {
                    RecipeName = "עוגת מוס שוקולד",
                    Description = "1. ממיסים 200 גרם שוקולד מריר עם 100 גרם חמאה על בן מארי.\n2. בקערה נפרדת מקציפים שמנת מתוקה עם 2 כפות אבקת סוכר עד לקצפת רכה.\n3. מאחדים את השוקולד המומס עם השמנת בהדרגה בקיפולים עד לתערובת חלקה.\n4. יוצקים לתבנית או כוסות אישיות ומכניסים למקרר ל־4 שעות לפחות.\n5. לקישוט: אפשר להוסיף שבבי שוקולד, אגוזים קצוצים או קצפת מעל.",
                    CategoryID = 1,
                    Category = categories.First(c => c.CategoryID == 1),
                    TimerMinutes = 60,
                    ImageUrl = "mousse.jpg",
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/1u-0tNFMamg?si=-Xzt_nXj-6nRPOdg"
                },
                new Recipe
                {
                    RecipeName = "סלט ירקות טריים",
                    Description = "1. חותכים עגבניות, מלפפונים, פלפלים ובצל סגול לקוביות קטנות.\n2. קוצצים פטרוזיליה או כוסברה לפי הטעם.\n3. מתבלים במיץ לימון סחוט, שמן זית, מלח, פלפל וטיפת חומץ בלסמי.\n4. מערבבים היטב ומגישים מיד לשמירה על פריכות.",
                    CategoryID = 4,
                    Category = categories.First(c => c.CategoryID == 4),
                    TimerMinutes = 10,
                    ImageUrl = "salad1.jpg",
                    LikesCount = 0,
                    VideoURL = null
                },
                new Recipe
                {
                    RecipeName = "פסטה ברוטב עגבניות",
                    Description = "1. מבשלים את הפסטה לפי ההוראות על האריזה.\n2. במחבת עמוקה, מטגנים בצל ושום קצוצים עד להזהבה.\n3. מוסיפים 2–3 עגבניות מגוררות או קופסה של עגבניות מרוסקות.\n4. מתבלים במלח, פלפל, סוכר, בזיליקום יבש ואורגנו.\n5. מבשלים כ־15 דקות עד שהרוטב מצטמצם.\n6. מוסיפים את הפסטה למחבת, מערבבים ומבשלים יחד עוד 2 דקות.\n7. מגישים עם עלי בזיליקום טריים ופרמזן מגורר.",
                    CategoryID = 5,
                    Category = categories.First(c => c.CategoryID == 5),
                    TimerMinutes = 30,
                    ImageUrl = "pasta_tomato.jpg",
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/NQXpasFpcqw?si=XoMIg51cSHpXvcMb"
                },
                new Recipe
                {
                    RecipeName = "דג סלמון עם פירה",
                    Description = "1. מתבלים נתחי סלמון במלח, פלפל, מיץ לימון ושמן זית.\n2. אופים בתנור שחומם מראש ל־200 מעלות כ־15–20 דקות עד שהדג מתבשל.\n3. בינתיים, מקלפים וחותכים תפוחי אדמה ומבשלים במים עם מלח עד לריכוך.\n4. מסננים ומועכים למחית, מוסיפים חמאה, חלב חם, מלח ופלפל.\n5. מגישים את הסלמון על מצע של פירה חם עם עשבי תיבול לקישוט.",
                    CategoryID = 2,
                    Category = categories.First(c => c.CategoryID == 2),
                    TimerMinutes = 35,
                    ImageUrl = "salmon.jpg",
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/jT4BsDlNjFs?si=aTHT7_xzeRLHLUmp"
                },
                new Recipe
                {
                    RecipeName = "קציצות דגים",
                    Description = "1. טוחנים 500 גרם דג לבן נקי עם בצל, פטרוזיליה, ביצה, שן שום ותבלינים (כמון, מלח, פלפל).\n2. מוסיפים פירורי לחם עד שמתקבלת תערובת נוחה לעיצוב.\n3. יוצרים קציצות ומשטחים מעט.\n4. מטגנים בשמן חם עד להשחמה משני הצדדים או אופים בתנור.\n5. מגישים חם עם טחינה, סלט ופת לחם טרי.",
                    CategoryID = 2,
                    Category = categories.First(c => c.CategoryID == 2),
                    TimerMinutes = 30,
                    ImageUrl = "fish_cakes.jpg",
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/m09beHf1PXM?si=dGFiDWbweupqWmob"
                },
                new Recipe
                {
                    RecipeName = "פרנץ' טוסט",
                    Description = "1. טורפים בקערה 2 ביצים, חצי כוס חלב, כפית סוכר, קמצוץ קינמון ווניל.\n2. טובלים פרוסות לחם (עדיף בן יומיים) בתערובת מכל צד.\n3. ממיסים חמאה במחבת ומטגנים את הפרוסות כ-2–3 דקות מכל צד עד להשחמה.\n4. מגישים עם סירופ מייפל, אבקת סוכר, פירות טריים או קצפת.",
                    CategoryID = 3,
                    Category = categories.First(c => c.CategoryID == 3),
                    TimerMinutes = 15,
                    ImageUrl = "frenchtoast.jpg",
                    LikesCount = 4,
                    VideoURL = "https://youtu.be/mKrQGMKPqTs?si=4nfHeuoT0RYlirS0"
                },
                new Recipe
                {
                    RecipeName = "עראייס",
                    Description = "1. מערבבים חצי קילו בשר טחון (עדיף כבש), בצל קצוץ דק, צרור פטרוזיליה קצוצה, מלח, פלפל שחור וכף שמן זית.\n2. חוצים פיתות וממלאים כל חצי בתערובת.\n3. מורחים שמן זית מבחוץ וצולים על מחבת פסים או בתנור שחומם ל-200 מעלות.\n4. הופכים מדי פעם עד שהפיתה פריכה והבשר עשוי מבפנים (כ-10–12 דקות).\n5. מגישים עם טחינה, עמבה או סלט ירקות.",
                    CategoryID = 5,
                    Category = categories.First(c => c.CategoryID == 5),
                    TimerMinutes = 25,
                    ImageUrl = "arayes.jpg",
                    LikesCount = 3,
                    VideoURL = "https://youtu.be/a2muVNW1U3c?si=6FcJZzi2uYmk-xvv"
                },
                new Recipe
                {
                    RecipeName = "בורקס גבינה",
                    Description =  "1. מערבבים בקערה גבינה לבנה, גבינת בולגרית מפוררת וביצה אחת.\n2. פורסים בצק עלים מופשר וחותכים לריבועים.\n3. מניחים כפית מילוי במרכז כל ריבוע, מקפלים למשולש ומהדקים עם מזלג.\n4. מברישים בביצה טרופה ומפזרים שומשום.\n5. אופים בתנור שחומם מראש ל-190 מעלות כ-20–25 דקות עד להזהבה יפה.",
                    CategoryID = 6,
                    Category = categories.First(c => c.CategoryID == 6),
                    TimerMinutes = 25,
                    ImageUrl = "bourekas.jpg",
                    LikesCount = 2,
                    VideoURL = "https://youtu.be/7jaaOL3IVbE?si=Map8H-5FGTiApgXO"
                },
                new Recipe
                {
                    RecipeName = "פרפה וניל ופירות יער",
                    Description = "1. מקציפים שמנת מתוקה עם אבקת סוכר ותמצית וניל עד לקצפת יציבה.\n2. מקפלים פנימה גבינת מסקרפונה (או יוגורט יווני) לתערובת חלקה.\n3. מבשלים פירות יער קפואים עם מעט סוכר ולימון עד לקבלת רוטב סמיך.\n4. מוזגים שכבות לסירוגין של קרם ורוטב לכוסות הגשה.\n5. מקררים 3–4 שעות לפני ההגשה. ניתן לקשט בעוגיות או עלי נענע.",
                    CategoryID = 1,
                     Category = categories.First(c => c.CategoryID == 1),
                    ImageUrl = "parfait.jpg",
                    TimerMinutes = 25,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/J_4ppU2jA0I?si=hqcxT-Z8ToUwENmm"
                },
                new Recipe
                {
                    RecipeName = "עוגת שמרים שוקולד",
                    Description = "בקערה מערבבים קמח, סוכר, שמרים וביצים. מוסיפים חמאה וחלב ולשים לבצק רך. מתפיחים כשעה. בינתיים ממיסים שוקולד עם קקאו להכנת המלית. מרדדים את הבצק, מורחים את המלית ומגלגלים לרולדה. יוצרים בורג, מניחים בתבנית ומתפיחים שוב. אופים עד שהעוגה זהובה וריחנית. מתאימה להגשה חמה או קרה.",
                    CategoryID = 6,
                    Category = categories.First(c => c.CategoryID == 6),
                    ImageUrl = "chocolate_yeast_cake.jpg",
                    TimerMinutes = 120,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/-tX-ht5OpUo?si=Oev1V_PW9R54xkyg"
                },
                new Recipe
                {
                    RecipeName = "סלט עוף אסייאתי",
                    Description = "במחבת חמה חממי כף שמן וצלי את רצועות העוף כ־3–4 דקות מכל צד עד שהן מזהיבות ומבושלות היטב. הוציאי לצלחת. " +
                                  "באותה מחבת, הקפיצי את הירקות (כמו כרוב קצוץ, גזר מגורר, ופלפל אדום חתוך לרצועות דקות) עם מעט שמן למשך 2–3 דקות עד שהן מתרככות קלות אך שומרות על פריכות. " +
                                  "החזירי את רצועות העוף למחבת והוסיפי את רוטב הטריאקי, מלח ופלפל לפי הטעם. ערבבי היטב במשך דקה נוספת לאיחוד הטעמים. " +
                                  "בינתיים חתכי מלפפון לרצועות דקות ואת עגבניות השרי לחצאים. " +
                                  "סדרי בקערת סלט – תחילה בסיס של ירקות טריים (מלפפון, עגבניות שרי, חסה), מעליהם תערובת העוף והירקות החמים. " +
                                  "לפני ההגשה פזרי מעל עשבי תיבול קצוצים (כגון כוסברה או נענע). ניתן להגיש חם או בטמפרטורת החדר.",
                    CategoryID = 4,
                    Category = categories.First(c => c.CategoryID == 4), // סלטים
                    ImageUrl = "asian_chicken_salad.jpg",
                    TimerMinutes = 25,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/81pGxNcU1M4?si=qnvmtO1mO1wKLbC-"
                },
                new Recipe
                {
                    RecipeName = "מוזלי ביתי",
                    Description =
                    "1. בחרי יוגורט טבעי או יוגורט בטעמים לפי העדפתך (כמו יוגורט יווני או יוגורט דל שומן) ומזגי כמות של כ־200 מ״ל לקערה אישית.\n" +
                    "2. פזרי מעל כ־3 כפות גרנולה קראנצ'ית – ניתן להשתמש בגרנולה ביתית או קנויה. אם רוצים גרסה בריאה יותר, השתמשי בגרנולה ללא סוכר.\n" +
                    "3. הוסיפי מעל חופן פירות טריים חתוכים – מומלץ להשתמש בתותים, בננה, תפוח, קיווי או ענבים. ניתן גם להוסיף פירות יער קפואים שהופשרו.\n" +
                    "4. להמתקה קלה – הוסיפי כפית דבש, סירופ מייפל טבעי או מעט סילאן לפי הטעם.\n" +
                    "5. לקישוט וטעם עשיר יותר, הוסיפי אגוזים קצוצים, קוקוס קלוי או זרעי צ'יה.\n" +
                    "6. הגישי מיד – המוזלי טעים במיוחד כשהוא קר וטרי.",
                    CategoryID = 3, // ארוחות בוקר
                    Category = categories.First(c => c.CategoryID == 3),
                    ImageUrl = "muesli.jpg",
                    TimerMinutes = 10,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/mMIwWFi1LJg?si=Tka0LKOTD1gxrQY9"
                },
                new Recipe
                {
                    RecipeName = "פסטה בולונז",
                    Description =
                    "1. קצצי בצל ושום וטגני אותם בסיר עם כף שמן זית עד שהם מתרככים ושקופים.\n" +
                    "2. הוסיפי כ־400 גרם בשר טחון וטגני תוך ערבוב עד שהבשר משנה את צבעו ומתבשל.\n" +
                    "3. תבלי במלח, פלפל שחור, פפריקה, וקמצוץ סוכר (לאיזון החומציות).\n" +
                    "4. הוסיפי כוס רסק עגבניות, חצי כוס מים, ואפשר גם רסק עגבניות מרוכז (אם רוצים טעם עמוק יותר).\n" +
                    "5. הביאי לרתיחה, ואז הנמיכי את הלהבה ובשלי כ־15–20 דקות עד שהרוטב מסמיך והטעמים מתמזגים.\n" +
                    "6. במקביל, בשלי פסטה (פנה, ספגטי או פוזילי) לפי הוראות היצרן.\n" +
                    "7. סנני את הפסטה, והגישי עם רוטב הבולונז מעל. אפשר לפזר גבינת פרמזן מגוררת מעל להגשה.",
                    CategoryID = 5, // ארוחות צהריים
                    Category = categories.First(c => c.CategoryID == 5),
                    ImageUrl = "bolognese_pasta.jpg",
                    TimerMinutes = 40,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/_6tMM2dnaiY?si=7znCIZtsnqrcg2NG"
                },
                new Recipe
                {
                    RecipeName = "חלה ביתית רכה",
                    Description =
                    "1. בקערה גדולה, ערבבי 1 ק״ג קמח, 1 כף שמרים יבשים, חצי כוס סוכר וכפית מלח.\n" +
                    "2. הוסיפי 2 ביצים, רבע כוס שמן ו-1.5 כוסות מים פושרים (בהדרגה) ולושי עד קבלת בצק אחיד ורך.\n" +
                    "3. לכסי את הקערה והתפיחי כשעה במקום חמים, עד להכפלת נפח.\n" +
                    "4. חלקי את הבצק ל־2–3 חלות, צרי קליעות לפי בחירתך.\n" +
                    "5. הניחי על תבנית עם נייר אפייה, כסי שוב והתפיחי 30 דקות נוספות.\n" +
                    "6. הברישי בביצה טרופה ופזרי שומשום או פרג מעל.\n" +
                    "7. אפי בתנור שחומם מראש ל־180 מעלות במשך 25–30 דקות, עד שהחלה זהובה ומוכנה.",
                    CategoryID = 6, // מאפים
                    Category = categories.First(c => c.CategoryID == 6),
                    ImageUrl = "homemade_challah.jpg",
                    TimerMinutes = 120,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/6uJTqGiCbPo?si=subppIOiwb4fe1P0"
                },
                new Recipe
                {
                    RecipeName = "סלט חצילים קלויים",
                    Description =
                    "1. חרצי קלות 2–3 חצילים עם סכין וצלי אותם על גז פתוח או בתנור (220 מעלות) במשך כ־30–40 דקות, עד שהקליפה שרופה והחצילים רכים.\n" +
                    "2. קררי מעט, קלי את הקליפה, וקצצי את תוכן החצילים עם סכין או מועך.\n" +
                    "3. הוסיפי שן שום כתושה, כף מיץ לימון, כף שמן זית, מלח ופלפל שחור לפי הטעם.\n" +
                    "4. אפשר להוסיף מעט פטרוזיליה קצוצה או טחינה גולמית לתוספת טעם.\n" +
                    "5. הגישי בטמפרטורת החדר עם לחם טרי או חלה.",
                    CategoryID = 4, // סלטים
                    Category = categories.First(c => c.CategoryID == 4),
                    ImageUrl = "roasted_eggplant_salad.jpg",
                    TimerMinutes = 45,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/PmKKOnwpbak?si=5ayld0L_iFZuq0Nt"
                },
                new Recipe
                {
                    RecipeName = "תבשיל בשר עם פטריות",
                    Description =
                    "1. חתכי 500 גרם בשר בקר לקוביות (כמו כתף מס' 5 או צלי כתף) וצרבי בסיר רחב עם 2 כפות שמן מכל הצדדים עד להשחמה.\n" +
                    "2. הוסיפי בצל קצוץ וטגני עד שהוא מתרכך. הוסיפי גם 2 שיני שום כתושות.\n" +
                    "3. הוסיפי כוס פטריות פרוסות (טריות או משומרות), וערבבי יחד עם הבשר.\n" +
                    "4. תבלי במלח, פלפל שחור, פפריקה מתוקה, קמצוץ כמון ואם רוצים – מעט עלי טימין טריים.\n" +
                    "5. הוסיפי כוס מים רותחים וכף רסק עגבניות. הביאי לרתיחה, כסי, והנמיכי את הלהבה.\n" +
                    "6. בשלי על אש נמוכה כשעתיים–שעתיים וחצי, עד שהבשר רך ונימוח והרוטב מצטמצם.\n" +
                    "7. הגישי עם אורז לבן, פירה או קוסקוס.",
                    CategoryID = 2, // מנות עיקריות
                    Category = categories.First(c => c.CategoryID == 2),
                    ImageUrl = "beef_mushroom_stew.jpg",
                    TimerMinutes = 150,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/9vWI7ZpbGxU?si=SFk9UfoJBUEj9Qf0"
                },
                new Recipe
                {
                    RecipeName = "סלט כרוב במיונז",
                    Description =
                    "1. קצצי דק חצי כרוב לבן (כ־400 גרם) או גררי אותו בפומפייה גסה.\n" +
                    "2. גררי 1–2 גזרים (כ־150 גרם) והוסיפי לכרוב.\n" +
                    "3. חתכי 2 גבעולי בצל ירוק לפרוסות דקות והוסיפי לקערה.\n" +
                    "4. בקערית נפרדת ערבבי 3 כפות מיונז, כפית מיץ לימון, חצי כפית סוכר, ומעט מלח ופלפל שחור.\n" +
                    "5. שפכי את הרוטב על הסלט וערבבי היטב עד שכל המרכיבים מצופים.\n" +
                    "6. כסי את הקערה והכניסי למקרר למשך כחצי שעה לספיגת טעמים.\n" +
                    "7. הגישי קר לצד מנות עיקריות.",
                    CategoryID = 4, // סלטים
                    Category = categories.First(c => c.CategoryID == 4),
                    ImageUrl = "cabbage_salad.jpg",
                    TimerMinutes = 15,
                    LikesCount = 0,
                    VideoURL = "https://youtu.be/7m49zlV2jnM?si=-oCfYJcjuWwMgeQy",
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
            var bananaMuffins = context.Recipes.First(r => r.RecipeName == "מאפינס בננה ושוקולד");
            var pestoPasta = context.Recipes.First(r => r.RecipeName == "פסטה פסטו");
            var creamyMushroomPasta = context.Recipes.First(r => r.RecipeName == "פסטה שמנת פטריות");
            var quinoaSalad = context.Recipes.First(r => r.RecipeName == "סלט קינואה צבעוני");
            var teriyakiChicken = context.Recipes.First(r => r.RecipeName == "חזה עוף בטריאקי");
            var pizza = context.Recipes.First(r => r.RecipeName == "פיצה מרגריטה");
            var tiramisu = context.Recipes.First(r => r.RecipeName == "טירמיסו קלאסי");
            var avocadoToast = context.Recipes.First(r => r.RecipeName == "טוסט אבוקדו וביצה");
            var salad = context.Recipes.First(r => r.RecipeName == "סלט ירקות טריים");
            var pastaTomato = context.Recipes.First(r => r.RecipeName == "פסטה ברוטב עגבניות");
            var salmon = context.Recipes.First(r => r.RecipeName == "דג סלמון עם פירה");
            var fishCakes = context.Recipes.First(r => r.RecipeName == "קציצות דגים");
            var frenchToast = context.Recipes.First(r => r.RecipeName == "פרנץ' טוסט");
            var arayes = context.Recipes.First(r => r.RecipeName == "עראייס");
            var bourekas = context.Recipes.First(r => r.RecipeName == "בורקס גבינה");
            var parfait = context.Recipes.First(r => r.RecipeName == "פרפה וניל ופירות יער");
            var ChocolateMousse = context.Recipes.First(r => r.RecipeName == "עוגת מוס שוקולד");
            var cheesecake = context.Recipes.First(r => r.RecipeName == "עוגת גבינה קרה");
            var chocolateYeastCake = context.Recipes.First(r => r.RecipeName == "עוגת שמרים שוקולד");
            var asianChickenSalad = context.Recipes.First(r => r.RecipeName == "סלט עוף אסייאתי");
            var yogurtMuesli = context.Recipes.First(r => r.RecipeName == "מוזלי ביתי");
            var pastaBolognese = context.Recipes.First(r => r.RecipeName == "פסטה בולונז");
            var homemadeChallah = context.Recipes.First(r => r.RecipeName == "חלה ביתית רכה");
            var roastedEggplantSalad = context.Recipes.First(r => r.RecipeName == "סלט חצילים קלויים");
            var beefMushroomStew = context.Recipes.First(r => r.RecipeName == "תבשיל בשר עם פטריות");
            var cabbageSalad = context.Recipes.First(r => r.RecipeName == "סלט כרוב במיונז");


            var ratingsandcomments = new RatingAndComment[]
            {
                new RatingAndComment { UserID = 3, RecipeID = schnitzel.RecipeID, Rating = 5, Comment = "המתכון הכי טוב שניסיתי לשניצל!" },
                new RatingAndComment { UserID = 4, RecipeID = shakshuka.RecipeID, Rating = 2, Comment = "היה טעים, אבל הייתי מוסיף עוד קצת תבלינים." },
                new RatingAndComment { UserID = 5, RecipeID = garlicBread.RecipeID, Rating = 1, Comment = "לא יצא מוצלח, משהו היה חסר." },
                new RatingAndComment { UserID = 1, RecipeID = chocolateBalls.RecipeID, Rating = 5, Comment = "פשוט מושלם. הילדים אהבו מאוד." },
                new RatingAndComment { UserID = 2, RecipeID = 6, Rating = 3, Comment = "בסדר, אבל הציפיתי ליותר טעם." },
                new RatingAndComment { UserID = 2, RecipeID = chocolateBalls.RecipeID, Rating = 3, Comment = "טעים אבל מאוד מתוק." },
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
              new Ingredient { IngredientName = "פתי בר" },
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
              new Ingredient { IngredientName = "גבינה צהובה מגוררת" },//50
              new Ingredient { IngredientName = "ג’לי תות" },
              new Ingredient { IngredientName = "שוקולד מריר" },
              new Ingredient { IngredientName = "פירות יער קפואים" },
              new Ingredient { IngredientName = "בזיליקום" },
              new Ingredient { IngredientName = "פילה סלמון" },
              new Ingredient { IngredientName = "תפוחי אדמה" },
              new Ingredient { IngredientName = "דג טחון" },
             new Ingredient { IngredientName = "פיתה" },
              new Ingredient { IngredientName = "בצק עלים" },
              new Ingredient { IngredientName = "גבינה לבנה" },
              new Ingredient { IngredientName = "קינמון" }, //61
              new Ingredient { IngredientName = "שומשום" }, // 62
              new Ingredient { IngredientName = "יוגורט" },         // למוזלי63
            new Ingredient { IngredientName = "גרנולה" },         // 64
            new Ingredient { IngredientName = "דבש" },            // ל65י
            new Ingredient { IngredientName = "פירות טריים" },    // 66
            new Ingredient { IngredientName = "רוטב סויה" },      // 67
            new Ingredient { IngredientName = "חומץ אורז" },
            new Ingredient { IngredientName = "אגוזים קצוצים" },//69
            new Ingredient { IngredientName = "חצילים" }, // 70
              new Ingredient { IngredientName = "טימין" },   // 71
               new Ingredient { IngredientName = "נתח אונטריב / כתף" }, //72
               new Ingredient{ IngredientName = "אבוקדו" }, //73
               new Ingredient { IngredientName = "נס קפה דק" }, //74
               new Ingredient { IngredientName = "כרוב" },           // 75
               new Ingredient { IngredientName = "בצל ירוק" },       // 76



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
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 32)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 9, // חזה עוף
                    Quantity = 300,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 9)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 47, // עשבי תיבול
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 47)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 33, // תבלין קארי
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 33)
                },
                new RecipeIngredient
                {
                    RecipeID = stirFry.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == stirFry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },

                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 75, Quantity = 400, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 75) }, // כרוב  
                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 40, Quantity = 150, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 40) }, // גזר  
                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 76, Quantity = 2, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 76) }, // בצל ירוק  
                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 25, Quantity = 3, Units = "כף", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 25) }, // מיונז  
                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 26, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 26) }, // מיץ לימון  
                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 6, Quantity = 1, Units = "קורט", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 6) }, // סוכר  
                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 14, Quantity = 1, Units = "קורט", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
                new RecipeIngredient { RecipeID = cabbageSalad.RecipeID, IngredientID = 31, Quantity = 1, Units = "קורט", Recipe = recipes.First(r => r.RecipeID == cabbageSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור  

                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 74, // קפה
                    Quantity = 100,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 74)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 6, // סוכר
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 3,
                    Units = "יחידות",
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
                    IngredientID = 19, // וניל
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 19)
                },
                new RecipeIngredient
                {
                    RecipeID = tiramisu.RecipeID,
                    IngredientID = 18, // קקאו
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == tiramisu.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 18)
                },

                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 49, // פטרוזיליה קצוצה  
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 35)
                },
                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 27, //שום  
                    Quantity = 3,
                    Units = "שיניים",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 50, // גבינה צהובה מגוררת  
                    Quantity = 100,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 36)
                },
                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 31, // פלפל שחור  
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },
                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 17, // חמאה  
                    Quantity = 50,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },
                new RecipeIngredient
                {
                    RecipeID = garlicBread.RecipeID,
                    IngredientID = 34, // כיכר לחם  
                    Quantity = 6,
                    Units = "פרוסות",
                    Recipe = recipes.First(r => r.RecipeID == garlicBread.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 34)
                },
                // Recipe 10: Curry with Rice
                
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 15, // פטריות  
                    Quantity = 200,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 15)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 30, // שמן  
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 16, // בצל  
                    Quantity = 1,
                    Units = "יחידה",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 13, // שמנת מתוקה  
                    Quantity = 200,
                    Units = "מייל",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 13)
                },
                new RecipeIngredient
                {
                    RecipeID = veggieCurry.RecipeID,
                    IngredientID = 33, // תבלין קארי  
                    Quantity = 1,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 33)
                },
                new RecipeIngredient
                {
                    RecipeID =veggieCurry.RecipeID,
                    IngredientID = 10, // אורז  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == veggieCurry.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 10)
                },

                // Recipe 9: American Pancakes
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 4, // קמח  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 6, // סוכר  
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 1, // ביצים  
                    Quantity = 1,
                    Units = "יחידה",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 2, // חלב  
                    Quantity = 2,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == pancakes.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 2)
                },
                new RecipeIngredient
                {
                    RecipeID = pancakes.RecipeID,
                    IngredientID = 23, // אבקת אפייה  
                    Quantity = 1,
                    Units = "כף",
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
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 12, // רסק עגבניות  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 12)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 38, // עגבניות  
                    Quantity = 3,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 38)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 16, // בצל  
                    Quantity = 1,
                    Units = "יחידה",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 27, // שום  
                    Quantity = 2,
                    Units = "שיניים",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 14, // מלח  
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = shakshuka.RecipeID,
                    IngredientID = 31, // פלפל שחור  
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == shakshuka.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },

                 // Recipe 5: Schnitzel  
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 9, // חזה עוף  
                   Quantity = 500,
                   Units = "גרם",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 9)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 1, // ביצים  
                   Quantity = 2,
                   Units = "יחידות",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 1)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 3, // פירורי לחם  
                   Quantity = 1,
                   Units = "כוס",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 3)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 14, // מלח  
                   Quantity = 1,
                   Units = "כפית",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 14)
               },
               new RecipeIngredient
               {
                   RecipeID = schnitzel.RecipeID,
                   IngredientID = 31, // פלפל שחור  
                   Quantity = 1,
                   Units = "כפית",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 31)
               },
               new RecipeIngredient
               {
                  RecipeID = schnitzel.RecipeID,
                   IngredientID = 30, // שמן  
                   Quantity = 1,
                   Units = "ליטר",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 30)
               },
               new RecipeIngredient
               {
                  RecipeID = schnitzel.RecipeID,
                   IngredientID = 4, // קמח  
                   Quantity = 1,
                   Units = "כוס",
                   Recipe = recipes.First(r => r.RecipeID == schnitzel.RecipeID),
                   Ingredient = ingredients.First(i => i.IngredientID == 4)
               },  
               // Recipe 4: Chocolate Balls  
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 17, // חמאה  
                   Quantity = 100,
                   Units = "גרם",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 17)
               },
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 5, // שוקולד  
                   Quantity = 200,
                   Units = "גרם",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 5)
               },
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 22, // קוקוס  
                   Quantity = 100,
                   Units = "גרם",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 22)
               },
               new RecipeIngredient
               {
                   RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 21, // פירורי פתי בר  
                   Quantity = 500,
                   Units = "גרם",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 21)
               },
               new RecipeIngredient
               {
                  RecipeID = chocolateBalls.RecipeID,
                   IngredientID = 2, // חלב  
                   Quantity = 1,
                   Units = "כוס",
                   Recipe = recipes.First(r => r.RecipeID == 4),
                   Ingredient = ingredients.First(i => i.IngredientID == 2)
               },
               // Recipe 5: Caesar Salad
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 35, // חסה 
                    Quantity = 1,
                    Units = "חבילה",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 35)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 36, // אנשובי
                    Quantity = 4,
                    Units = "פילטים",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 36)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 25, // מיונז
                    Quantity = 3,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 25)
                },
                new RecipeIngredient
                {
                   RecipeID = caesarSalad.RecipeID,
                    IngredientID = 28, // גבינת פרמזן
                    Quantity = 50,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 28)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 26, // מיץ לימון
                    Quantity = 1,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 26)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 27, // שום
                    Quantity = 1,
                    Units = "שיניים",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 30, // שמן (שמן זית)
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = caesarSalad.RecipeID,
                    IngredientID = 37, // קרוטונים
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == caesarSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 37)
                },
                // Recipe X: Meatballs in Red Sauce with Rice
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 8, // בשר טחון
                    Quantity = 500,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 8)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 1,
                    Units = "יחידה",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 3, // פירורי לחם
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 3)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 15, // בצל
                    Quantity = 1,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 15)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 30, // פלפל שחור
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 27, // שום
                    Quantity = 2,
                    Units = "שיניים",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 31, // רסק עגבניות
                    Quantity = 3,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = meatballs.RecipeID,
                    IngredientID = 38, // אורז
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == meatballs.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 38)
                },
                // Recipe Y: Chocolate Cake
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 5, // שוקולד
                    Quantity = 200,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 5)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 17, // חמאה
                    Quantity = 200,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 4,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 4, // קמח
                    Quantity = 200,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 2, // חלב
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 2)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 6, // סוכר
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateCake.RecipeID,
                    IngredientID = 23, // אבקת אפייה
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == chocolateCake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 23)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 4, // קמח
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 1, // ביצים
                    Quantity = 2,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 6, // סוכר
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 23, // אבקת אפייה
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 23)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 20, // שוקולד צ’יפס
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 20)
                },
                new RecipeIngredient
                {
                    RecipeID = bananaMuffins.RecipeID,
                    IngredientID = 45, // בננה
                    Quantity = 2,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == bananaMuffins.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 45)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 11, // פסטה
                    Quantity = 250,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 11)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 42, // רוטב פסטו
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 42)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 43, // עגבניות שרי
                    Quantity = 10,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 43)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 44, // שמן זית
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 44)
                },
                new RecipeIngredient
                {
                    RecipeID = pestoPasta.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == pestoPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 11, // פסטה
                    Quantity = 250,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 11)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 13, // שמנת מתוקה
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 13)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 15, // פטריות
                    Quantity = 200,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 15)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 16, // בצל
                    Quantity = 1,
                    Units = "יחידה",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = creamyMushroomPasta.RecipeID,
                    IngredientID = 31, // פלפל שחור
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == creamyMushroomPasta.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 46, // קינואה
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 46)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 39, // מלפפונים
                    Quantity = 1,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 39)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 38, // עגבניות
                    Quantity = 1,
                    Units = "יחידות",
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
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 27)
                },
                new RecipeIngredient
                {
                    RecipeID = quinoaSalad.RecipeID,
                    IngredientID = 44, // שמן זית
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == quinoaSalad.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 44)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 9, // חזה עוף
                    Quantity = 500,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 9)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 48, // רוטב טריאקי
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 48)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 31, // פלפל שחור
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 31)
                },
                new RecipeIngredient
                {
                    RecipeID = teriyakiChicken.RecipeID,
                    IngredientID = 16, // בצל
                    Quantity = 1,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == teriyakiChicken.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 16)
                },
                // Recipe 6: Brownies  
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 5, // שוקולד  
                    Quantity = 200,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 5)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 6, // סוכר  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 1, // ביצים  
                    Quantity = 3,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 17, // חמאה  
                    Quantity = 150,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 4, // קמח  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 18, // קקאו  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 18)
                },
                new RecipeIngredient
                {
                    RecipeID = brownies.RecipeID,
                    IngredientID = 23, // אבקת אפייה  
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == brownies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 23)
                },
                // Recipe 7: Chocolate Chip Cookies
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 17, // חמאה  
                    Quantity = 150,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 6, // סוכר  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 1, // ביצים  
                    Quantity = 2,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 1)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 4, // קמח  
                    Quantity = 2,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 19, // וניל  
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 19)
                },
                new RecipeIngredient
                {
                    RecipeID = chocolateChipCookies.RecipeID,
                    IngredientID = 20, // שוקולד צ’יפס  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == chocolateChipCookies.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 20)
                },
                // Recipe: פיצה מרגריטה
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 4, // קמח
                    Quantity = 3,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 23, // אבקת אפייה
                    Quantity = 1,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 23)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 24, // מים
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 24)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 12, // רסק עגבניות
                    Quantity = 5,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 12)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 50, // רסק עגבניות
                    Quantity = 400,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 50)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 28, // גבינת פרמזן
                    Quantity = 100,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 28)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 43, // עגבניות שרי
                    Quantity = 6,
                    Units = "יחידות",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 43)
                },
                new RecipeIngredient
                {
                    RecipeID = pizza.RecipeID,
                    IngredientID = 47, // עשבי תיבול
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == pizza.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 47)
                },
                // Recipe: Cheesecake
                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 21, // פתי בר  
                    Quantity = 1,
                    Units = "חבילה",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 21)
                },

                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 17, // חמאה  
                    Quantity = 100,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 17)
                },

                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 60, // גבינה לבנה  
                    Quantity = 500,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 60)
                },

                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 13, // שמנת מתוקה  
                    Quantity = 250,
                    Units = "מייל",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 13)
                },

                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 6, // סוכר  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },

                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 19, // וניל  
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 19)
                },

                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 51, // ג’לי תות  
                    Quantity = 1,
                    Units = "חבילה",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 51)
                },

                new RecipeIngredient
                {
                    RecipeID = cheesecake.RecipeID,
                    IngredientID = 24, // מים  
                    Quantity = 1,
                    Units = "כוס",
                    Recipe = recipes.First(r => r.RecipeID == cheesecake.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 24)
                },

                // Recipe: Mousse
                new RecipeIngredient
                {
                    RecipeID = ChocolateMousse.RecipeID,
                    IngredientID = 52, // שוקולד מריר  
                    Quantity = 200,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == ChocolateMousse.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 52)
                },

                new RecipeIngredient
                {
                    RecipeID = ChocolateMousse.RecipeID,
                    IngredientID = 13, // שמנת מתוקה  
                    Quantity = 250,
                    Units = "מייל",
                    Recipe = recipes.First(r => r.RecipeID == ChocolateMousse.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 13)
                },

                

               new RecipeIngredient { RecipeID = salad.RecipeID, IngredientID = 38, Quantity = 2, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == salad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 38) }, // עגבניות  
               new RecipeIngredient { RecipeID = salad.RecipeID, IngredientID = 39, Quantity = 1, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == salad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 39) }, // מלפפונים  
               new RecipeIngredient { RecipeID = salad.RecipeID, IngredientID = 40, Quantity = 1, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == salad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 40) }, // גזר  
               new RecipeIngredient { RecipeID = salad.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == salad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
               new RecipeIngredient { RecipeID = salad.RecipeID, IngredientID = 44, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == salad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 44) }, // שמן זית

               new RecipeIngredient { RecipeID = pastaTomato.RecipeID, IngredientID = 11, Quantity = 300, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == pastaTomato.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 11) }, // פסטה  
               new RecipeIngredient { RecipeID = pastaTomato.RecipeID, IngredientID = 12, Quantity = 100, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == pastaTomato.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 12) }, // רסק עגבניות  
               new RecipeIngredient { RecipeID = pastaTomato.RecipeID, IngredientID = 54, Quantity = 5, Units = "עלים", Recipe = recipes.First(r => r.RecipeID == pastaTomato.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 54) }, // בזיליקום  
               new RecipeIngredient { RecipeID = pastaTomato.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == pastaTomato.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
               new RecipeIngredient { RecipeID = pastaTomato.RecipeID, IngredientID = 30, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == pastaTomato.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן  

               new RecipeIngredient { RecipeID = salmon.RecipeID, IngredientID = 55, Quantity = 2, Units = "נתחים", Recipe = recipes.First(r => r.RecipeID == salmon.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 55) }, // פילה סלמון  
               new RecipeIngredient { RecipeID = salmon.RecipeID, IngredientID = 56, Quantity = 3, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == salmon.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 56) }, // תפוחי אדמה  
               new RecipeIngredient { RecipeID = salmon.RecipeID, IngredientID = 17, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == salmon.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 17) }, // חמאה  
               new RecipeIngredient { RecipeID = salmon.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == salmon.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
               new RecipeIngredient { RecipeID = salmon.RecipeID, IngredientID = 31, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == salmon.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור
               new RecipeIngredient { RecipeID = salmon.RecipeID, IngredientID = 26, Quantity = 1, Units = "כוס", Recipe = recipes.First(r => r.RecipeID == salmon.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 26) }, // לימון
               new RecipeIngredient { RecipeID = salmon.RecipeID, IngredientID = 47, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == salmon.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 47) }, // עשבי תיבול  
               

               new RecipeIngredient { RecipeID = frenchToast.RecipeID, IngredientID = 1, Quantity = 2, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == frenchToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 1) }, // ביצים  
               new RecipeIngredient { RecipeID = frenchToast.RecipeID, IngredientID = 2, Quantity = 1, Units = "כוס", Recipe = recipes.First(r => r.RecipeID == frenchToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 2) }, // חלב  
               new RecipeIngredient { RecipeID = frenchToast.RecipeID, IngredientID = 34, Quantity = 4, Units = "פרוסות", Recipe = recipes.First(r => r.RecipeID == frenchToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 34) }, // לחם  
               new RecipeIngredient { RecipeID = frenchToast.RecipeID, IngredientID = 18, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == frenchToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 18) }, // חמאה  
               new RecipeIngredient { RecipeID = frenchToast.RecipeID, IngredientID = 61, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == frenchToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 61) }, // קינמון

               new RecipeIngredient { RecipeID = arayes.RecipeID, IngredientID = 8, Quantity = 300, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == arayes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 8) }, // בשר טחון  
               new RecipeIngredient { RecipeID = arayes.RecipeID, IngredientID = 16, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == arayes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 16) }, // בצל  
               new RecipeIngredient { RecipeID = arayes.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == arayes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
               new RecipeIngredient { RecipeID = arayes.RecipeID, IngredientID = 31, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == arayes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור  
               new RecipeIngredient { RecipeID = arayes.RecipeID, IngredientID = 58, Quantity = 4, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == arayes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 58) }, // פיתה  
               new RecipeIngredient { RecipeID = arayes.RecipeID, IngredientID = 30, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == arayes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן

               new RecipeIngredient { RecipeID = bourekas.RecipeID, IngredientID = 59, Quantity = 1, Units = "חבילה", Recipe = recipes.First(r => r.RecipeID == bourekas.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 59) }, // בצק עלים  
                new RecipeIngredient { RecipeID = bourekas.RecipeID, IngredientID = 60, Quantity = 250, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == bourekas.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 60) }, // גבינה לבנה  
                new RecipeIngredient { RecipeID = bourekas.RecipeID, IngredientID = 1, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == bourekas.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 1) }, // ביצים  
                new RecipeIngredient { RecipeID = bourekas.RecipeID, IngredientID = 50, Quantity = 50, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == bourekas.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 50) }, // גבינה צהובה מגוררת  
                new RecipeIngredient { RecipeID = bourekas.RecipeID, IngredientID = 30, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == bourekas.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן  

                new RecipeIngredient { RecipeID = parfait.RecipeID, IngredientID = 13, Quantity = 250, Units = "מייל", Recipe = recipes.First(r => r.RecipeID == parfait.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 13) }, // שמנת מתוקה  
                new RecipeIngredient { RecipeID = parfait.RecipeID, IngredientID = 19, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == parfait.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 19) }, // וניל  
                new RecipeIngredient { RecipeID = parfait.RecipeID, IngredientID = 53, Quantity = 100, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == parfait.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 53) }, // פירות יער קפואים  
                new RecipeIngredient { RecipeID = parfait.RecipeID, IngredientID = 6, Quantity = 3, Units = "כף", Recipe = recipes.First(r => r.RecipeID == parfait.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 6) }, // סוכר

                new RecipeIngredient { RecipeID = fishCakes.RecipeID, IngredientID = 57, Quantity = 500, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == fishCakes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 57) }, // דג טחון  
                new RecipeIngredient { RecipeID = fishCakes.RecipeID, IngredientID = 16, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == fishCakes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 16) }, // בצל  
                new RecipeIngredient { RecipeID = fishCakes.RecipeID, IngredientID = 1, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == fishCakes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 1) }, // ביצים  
                new RecipeIngredient { RecipeID = fishCakes.RecipeID, IngredientID = 4, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == fishCakes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 4) }, // קמח  
                new RecipeIngredient { RecipeID = fishCakes.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == fishCakes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
                new RecipeIngredient { RecipeID = fishCakes.RecipeID, IngredientID = 31, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == fishCakes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור  
                new RecipeIngredient { RecipeID = fishCakes.RecipeID, IngredientID = 30, Quantity = 3, Units = "כף", Recipe = recipes.First(r => r.RecipeID == fishCakes.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן לטיגון  


    
                new RecipeIngredient
                {
                    RecipeID = jerusalemBagel.RecipeID,
                    IngredientID = 29, // שמרים
                    Quantity = 1,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == jerusalemBagel.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 29)
                },
                new RecipeIngredient
                {
                    RecipeID = jerusalemBagel.RecipeID,
                    IngredientID = 4, // קמח
                    Quantity = 500,
                    Units = "גרם",
                    Recipe = recipes.First(r => r.RecipeID == jerusalemBagel.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 4)
                },
                new RecipeIngredient
                {
                    RecipeID = jerusalemBagel.RecipeID,
                    IngredientID = 6, // סוכר
                    Quantity = 2,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == jerusalemBagel.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 6)
                },
                new RecipeIngredient
                {
                    RecipeID = jerusalemBagel.RecipeID,
                    IngredientID = 24, // מים
                    Quantity = 2,
                    Units = "כוסות",
                    Recipe = recipes.First(r => r.RecipeID == jerusalemBagel.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 24)
                },
                new RecipeIngredient
                {
                    RecipeID = jerusalemBagel.RecipeID,
                    IngredientID = 30, // שמן
                    Quantity = 3,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == jerusalemBagel.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 30)
                },
                new RecipeIngredient
                {
                    RecipeID = jerusalemBagel.RecipeID,
                    IngredientID = 14, // מלח
                    Quantity = 1,
                    Units = "כפית",
                    Recipe = recipes.First(r => r.RecipeID == jerusalemBagel.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 14)
                },
                new RecipeIngredient
                {
                    RecipeID = jerusalemBagel.RecipeID,
                    IngredientID = 62, // שומשום (חסר בטבלת המצרכים!)
                    Quantity = 3,
                    Units = "כף",
                    Recipe = recipes.First(r => r.RecipeID == jerusalemBagel.RecipeID),
                    Ingredient = ingredients.First(i => i.IngredientID == 62)
                },

                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 29, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 29) }, // שמרים
                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 4, Quantity = 500, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 4) }, // קמח
                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 6, Quantity = 100, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 6) }, // סוכר
                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 1, Quantity = 2, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 1) }, // ביצים
                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 2, Quantity = 1, Units = "כוס", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 2) }, // חלב
                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 17, Quantity = 100, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 17) }, // חמאה
                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 5, Quantity = 150, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 5) }, // שוקולד
                new RecipeIngredient { RecipeID = chocolateYeastCake.RecipeID, IngredientID = 18, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == chocolateYeastCake.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 18) },  // קקאו


                new RecipeIngredient { RecipeID = yogurtMuesli.RecipeID, IngredientID = 63, Quantity = 150, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == yogurtMuesli.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 63) }, // יוגורט  
                new RecipeIngredient { RecipeID = yogurtMuesli.RecipeID, IngredientID = 64, Quantity = 50, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == yogurtMuesli.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 64) }, // גרנולה  
                new RecipeIngredient { RecipeID = yogurtMuesli.RecipeID, IngredientID = 66, Quantity = 5, Units = "כף", Recipe = recipes.First(r => r.RecipeID == yogurtMuesli.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 66) }, // פירות טריים  
                new RecipeIngredient { RecipeID = yogurtMuesli.RecipeID, IngredientID = 65, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == yogurtMuesli.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 65) }, // דבש  
                new RecipeIngredient { RecipeID = yogurtMuesli.RecipeID, IngredientID = 69, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == yogurtMuesli.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 69) }, // אגוזים קצוצים


                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 8, Quantity = 400, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 8) }, // בשר טחון  
                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 16, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 16) }, // בצל  
                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 27, Quantity = 2, Units = "שיניים", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 27) }, // שום  
                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 12, Quantity = 200, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 12) }, // רסק עגבניות  
                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 11, Quantity = 500, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 11) }, // פסטה  
                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 31, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור  
                new RecipeIngredient { RecipeID = pastaBolognese.RecipeID, IngredientID = 30, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == pastaBolognese.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן  

                new RecipeIngredient { RecipeID = asianChickenSalad.RecipeID, IngredientID = 9, Quantity = 300, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == asianChickenSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 9) }, // חזה עוף  
                new RecipeIngredient { RecipeID = asianChickenSalad.RecipeID, IngredientID = 40, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == asianChickenSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 40) }, // גזר  
                new RecipeIngredient { RecipeID = asianChickenSalad.RecipeID, IngredientID = 41, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == asianChickenSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 41) }, // פלפל מתוק  
                new RecipeIngredient { RecipeID = asianChickenSalad.RecipeID, IngredientID = 47, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == asianChickenSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 47) }, // עשבי תיבול  
                new RecipeIngredient { RecipeID = asianChickenSalad.RecipeID, IngredientID = 67, Quantity = 2, Units = "כף", Recipe = recipes.First(r => r.RecipeID == asianChickenSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 67) }, // רוטב סויה  
                new RecipeIngredient { RecipeID = asianChickenSalad.RecipeID, IngredientID = 68, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == asianChickenSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 68) }, // חומץ אורז  
                new RecipeIngredient { RecipeID = asianChickenSalad.RecipeID, IngredientID = 30, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == asianChickenSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן לטיגון/צריבה  


                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 4, Quantity = 1000, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 4) }, // קמח  
                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 24, Quantity = 600, Units = "מייל", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 24) }, // מים  
                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 6, Quantity = 50, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 6) }, // סוכר  
                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 1, Quantity = 2, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 1) }, // ביצים  
                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 29, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 29) }, // שמרים  
                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 30, Quantity = 60, Units = "מייל", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן (לשימון קל)  
                new RecipeIngredient { RecipeID = homemadeChallah.RecipeID, IngredientID = 62, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == homemadeChallah.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 62) }, // שומשום  

                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 72, Quantity = 500, Units = "גרם", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 72) }, // נתח אונטריב / כתף  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 16, Quantity = 1, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 16) }, // בצל  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 27, Quantity = 2, Units = "שיניים", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 27) }, // שום  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 15, Quantity = 1, Units = "חבילה", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 15) }, // פטריות  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 31, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 12, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 12) }, // רסק עגבניות  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 24, Quantity = 1, Units = "כוס", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 24) }, // מים  
                new RecipeIngredient { RecipeID = beefMushroomStew.RecipeID, IngredientID = 71, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == beefMushroomStew.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 71) }, // טימין  

                new RecipeIngredient { RecipeID = roastedEggplantSalad.RecipeID, IngredientID = 70, Quantity = 2, Units = "יחידות", Recipe = recipes.First(r => r.RecipeID == roastedEggplantSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 70) }, // חצילים  
                new RecipeIngredient { RecipeID = roastedEggplantSalad.RecipeID, IngredientID = 27, Quantity = 1, Units = "שיניים", Recipe = recipes.First(r => r.RecipeID == roastedEggplantSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 27) }, // שום  
                new RecipeIngredient { RecipeID = roastedEggplantSalad.RecipeID, IngredientID = 30, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == roastedEggplantSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן  
                new RecipeIngredient { RecipeID = roastedEggplantSalad.RecipeID, IngredientID = 26, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == roastedEggplantSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 26) }, // מיץ לימון  
                new RecipeIngredient { RecipeID = roastedEggplantSalad.RecipeID, IngredientID = 14, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == roastedEggplantSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
                new RecipeIngredient { RecipeID = roastedEggplantSalad.RecipeID, IngredientID = 31, Quantity = 1, Units = "כפית", Recipe = recipes.First(r => r.RecipeID == roastedEggplantSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור  
                new RecipeIngredient { RecipeID = roastedEggplantSalad.RecipeID, IngredientID = 49, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == roastedEggplantSalad.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 49) }, // פטרוזיליה קצוצה  

                 
              new RecipeIngredient { RecipeID = avocadoToast.RecipeID, IngredientID = 34, Quantity = 2, Units = "פרוסות", Recipe = recipes.First(r => r.RecipeID == avocadoToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 34) }, // לחם  
              new RecipeIngredient { RecipeID = avocadoToast.RecipeID, IngredientID = 73, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == avocadoToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 73) }, // אבוקדו  
              new RecipeIngredient { RecipeID = avocadoToast.RecipeID, IngredientID = 1, Quantity = 1, Units = "יחידה", Recipe = recipes.First(r => r.RecipeID == avocadoToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 1) }, // ביצים  
              new RecipeIngredient { RecipeID = avocadoToast.RecipeID, IngredientID = 14, Quantity = 1, Units = "קורט", Recipe = recipes.First(r => r.RecipeID == avocadoToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 14) }, // מלח  
              new RecipeIngredient { RecipeID = avocadoToast.RecipeID, IngredientID = 31, Quantity = 1, Units = "קורט", Recipe = recipes.First(r => r.RecipeID == avocadoToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 31) }, // פלפל שחור  
              new RecipeIngredient { RecipeID = avocadoToast.RecipeID, IngredientID = 30, Quantity = 1, Units = "כף", Recipe = recipes.First(r => r.RecipeID == avocadoToast.RecipeID), Ingredient = ingredients.First(i => i.IngredientID == 30) }, // שמן (לטיגון קל של הביצה)











        };





            context.RecipeIngredients.AddRange(recipeIngredients);
            context.SaveChanges();
        }
    }
}